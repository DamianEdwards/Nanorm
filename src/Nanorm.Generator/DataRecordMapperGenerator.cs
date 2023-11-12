using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Nanorm.Generator;

[Generator]
internal class DataRecordMapperGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Do a simple filter for types
        IncrementalValuesProvider<TypeDeclarationSyntax> typeDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => IsSyntaxTargetForGeneration(s), // select types with attributes
                transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx)) // select the types with the [DataRecordMapper] attribute
            .Where(static m => m is not null)!; // filter out attributed types that we don't care about

        var compilationAndTypes = context.CompilationProvider.Combine(typeDeclarations.Collect());

        context.RegisterSourceOutput(compilationAndTypes, static (spc, source) => Execute(source.Left, source.Right, spc));
    }

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node) => (node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax)
        && ((TypeDeclarationSyntax)node).AttributeLists.Count > 0;

    private static TypeDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        // we know the node is a TypeDeclarationSyntax thanks to IsSyntaxTargetForGeneration
        var typeDeclarationSyntax = (TypeDeclarationSyntax)context.Node;

        // loop through all the attributes on the method
        foreach (AttributeListSyntax attributeListSyntax in typeDeclarationSyntax.AttributeLists)
        {
            foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    // weird, we couldn't get the symbol, ignore it
                    continue;
                }

                INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();

                // Is the attribute the [DataRecordMapper] attribute?
                if (fullName == "Nanorm.DataRecordMapperAttribute")
                {
                    // return the enum
                    return typeDeclarationSyntax;
                }
            }
        }

        // we didn't find the attribute we were looking for
        return null;
    }

    private static void Execute(Compilation compilation, ImmutableArray<TypeDeclarationSyntax> types, SourceProductionContext context)
    {
        if (types.IsDefaultOrEmpty)
        {
            // nothing to do yet
            return;
        }

        // I'm not sure if this is actually necessary, but `[LoggerMessage]` does it, so seems like a good idea!
        IEnumerable<TypeDeclarationSyntax> distinctTypes = types.Distinct();

        // Convert each TypeDeclarationSyntax to a TypeToGenerate
        var typesToGenerate = GetTypesToGenerate(compilation, distinctTypes, context.CancellationToken);

        // If there were errors in the TypeDeclarationSyntax, we won't create an TypeToGenerate for it, so make sure we have
        // something to generate
        if (typesToGenerate.Count > 0)
        {
            // generate the source code and add it to the output
            string result = SourceGenerationHelper.GenerateExtensionTypes(typesToGenerate);
            context.AddSource("DataRecordMapperPartialTypes.g.cs", SourceText.From(result, Encoding.UTF8));
        }
    }

    static List<TypeToGenerate> GetTypesToGenerate(Compilation compilation, IEnumerable<TypeDeclarationSyntax> types, CancellationToken ct)
    {
        // Create a list to hold our output
        var typesToGenerate = new List<TypeToGenerate>();

        // Get the semantic representation of our marker attributes
        var mapperAttribute = compilation.GetTypeByMetadataName("Nanorm.DataRecordMapperAttribute");
        var mapColumnAttribute = compilation.GetTypeByMetadataName("Nanorm.MapColumnAttribute");
        var noMapAttribute = compilation.GetTypeByMetadataName("Nanorm.NoMapAttribute");

        if (mapperAttribute == null)
        {
            // If this is null, the compilation couldn't find the marker attribute type
            // which suggests there's something very wrong! Bail out..
            return typesToGenerate;
        }

        foreach (TypeDeclarationSyntax typeDeclarationSyntax in types)
        {
            // stop if we're asked to
            ct.ThrowIfCancellationRequested();

            // Get the semantic representation of the type syntax
            var semanticModel = compilation.GetSemanticModel(typeDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(typeDeclarationSyntax) is not INamedTypeSymbol typeSymbol)
            {
                // something went wrong, bail out
                continue;
            }

            var typeNamespace = typeSymbol.ContainingNamespace.IsGlobalNamespace
                ? null
                : typeSymbol.ContainingNamespace.ToString();

            // Get the full type name of the type e.g. Customer,
            // or OuterClass<T>.Customer if it was nested in a generic type (for example)
            var typeName = typeSymbol.ToString();

            // Get all the members in the type
            var typeMembers = typeSymbol.GetMembers();
            var members = new List<(string Name, string ColumnName, ITypeSymbol type)>(typeMembers.Length);

            // Get all the settable fields and properties from the type, and add their name and type to the list
            foreach (ISymbol member in typeMembers)
            {
                var attributes = member.GetAttributes();

                var columnName = member.Name;
                var skipMember = false;

                foreach (var attribute in attributes)
                {
                    if (attribute.AttributeClass?.Equals(noMapAttribute, SymbolEqualityComparer.Default) ?? false)
                    {
                        // Mapping disabled for this field, skip
                        skipMember = true;
                        break;
                    }
                    if (attribute.AttributeClass?.Equals(mapColumnAttribute, SymbolEqualityComparer.Default) ?? false)
                    {
                        // Custom mapping for this field, use the specified column name
                        columnName = attribute.ConstructorArguments[0].Value?.ToString() ?? member.Name;
                        break;
                    }
                }

                if (skipMember) continue;

                if (member is IFieldSymbol field && field.ConstantValue is not null && !field.IsReadOnly
                    && SourceGenerationHelper.IsMappableType(field.Type))
                {
                    members.Add((member.Name, columnName, field.Type));
                }
                else if (member is IPropertySymbol property && property.SetMethod is not null && !property.IsReadOnly && !property.IsStatic
                    && SourceGenerationHelper.IsMappableType(property.Type))
                {
                    members.Add((member.Name, columnName, property.Type));
                }
            }

            // Create a TypeToGenerate for use in the generation phase
            typesToGenerate.Add(new TypeToGenerate(typeNamespace, typeName, typeSymbol.TypeKind, members));
        }

        return typesToGenerate;
    }
}
