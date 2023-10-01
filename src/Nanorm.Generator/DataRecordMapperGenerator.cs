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
        // Do a simple filter for classes
        IncrementalValuesProvider<ClassDeclarationSyntax> classDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => IsSyntaxTargetForGeneration(s), // select classes with attributes
                transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx)) // select the class with the [DataRecordMapper] attribute
            .Where(static m => m is not null)!; // filter out attributed classes that we don't care about

        var compilationAndClasses = context.CompilationProvider.Combine(classDeclarations.Collect());

        context.RegisterSourceOutput(compilationAndClasses, static (spc, source) => Execute(source.Left, source.Right, spc));
    }

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node) =>
        node is ClassDeclarationSyntax c && c.AttributeLists.Count > 0;

    private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        // we know the node is a ClassDeclarationSyntax thanks to IsSyntaxTargetForGeneration
        var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

        // loop through all the attributes on the method
        foreach (AttributeListSyntax attributeListSyntax in classDeclarationSyntax.AttributeLists)
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
                    return classDeclarationSyntax;
                }
            }
        }

        // we didn't find the attribute we were looking for
        return null;
    }

    private static void Execute(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes, SourceProductionContext context)
    {
        if (classes.IsDefaultOrEmpty)
        {
            // nothing to do yet
            return;
        }

        // I'm not sure if this is actually necessary, but `[LoggerMessage]` does it, so seems like a good idea!
        IEnumerable<ClassDeclarationSyntax> distinctClasses = classes.Distinct();

        // Convert each ClassDeclarationSyntax to a ClassToGenerate
        var classesToGenerate = GetTypesToGenerate(compilation, distinctClasses, context.CancellationToken);

        // If there were errors in the ClassDeclarationSyntax, we won't create an ClassToGenerate for it, so make sure we have
        // something to generate
        if (classesToGenerate.Count > 0)
        {
            // generate the source code and add it to the output
            string result = SourceGenerationHelper.GenerateExtensionClass(classesToGenerate);
            context.AddSource("DataRecordMapperPartialClasses.g.cs", SourceText.From(result, Encoding.UTF8));
        }
    }

    static List<ClassToGenerate> GetTypesToGenerate(Compilation compilation, IEnumerable<ClassDeclarationSyntax> classes, CancellationToken ct)
    {
        // Create a list to hold our output
        var classesToGenerate = new List<ClassToGenerate>();

        // Get the semantic representation of our marker attribute 
        var mapperAttribute = compilation.GetTypeByMetadataName("Nanorm.DataRecordMapperAttribute");

        if (mapperAttribute == null)
        {
            // If this is null, the compilation couldn't find the marker attribute type
            // which suggests there's something very wrong! Bail out..
            return classesToGenerate;
        }

        foreach (ClassDeclarationSyntax classDeclarationSyntax in classes)
        {
            // stop if we're asked to
            ct.ThrowIfCancellationRequested();

            // Get the semantic representation of the class syntax
            var semanticModel = compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(classDeclarationSyntax) is not INamedTypeSymbol classSymbol)
            {
                // something went wrong, bail out
                continue;
            }

            var classNamespace = classSymbol.ContainingNamespace.IsGlobalNamespace
                ? null
                : classSymbol.ContainingNamespace.ToString();

            // Get the full type name of the class e.g. Customer,
            // or OuterClass<T>.Customer if it was nested in a generic type (for example)
            var className = classSymbol.ToString();

            // Get all the members in the class
            var classMembers = classSymbol.GetMembers();
            var members = new List<(string Name, ITypeSymbol type)>(classMembers.Length);

            // Get all the settable fields and properties from the class, and add their name and type to the list
            foreach (ISymbol member in classMembers)
            {
                if (member is IFieldSymbol field && field.ConstantValue is not null && !field.IsReadOnly
                    && SourceGenerationHelper.IsMappableType(field.Type))
                {
                    members.Add((member.Name, field.Type));
                }
                else if (member is IPropertySymbol property && property.SetMethod is not null && !property.IsReadOnly && !property.IsStatic
                    && SourceGenerationHelper.IsMappableType(property.Type))
                {
                    members.Add((member.Name, property.Type));
                }
            }

            // Create an EnumToGenerate for use in the generation phase
            classesToGenerate.Add(new ClassToGenerate(classNamespace, className, members));
        }

        return classesToGenerate;
    }
}
