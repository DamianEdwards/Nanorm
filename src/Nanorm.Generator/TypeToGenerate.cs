using Microsoft.CodeAnalysis;

namespace Nanorm.Generator;

internal readonly struct TypeToGenerate(string? @namespace, string identifer, string name, TypeKind typeKind, List<(string Name, string ColumnName, ITypeSymbol Type)> members)
{
    public readonly string? Namespace = @namespace;

    public readonly string Identifier = identifer;

    public readonly string Name = name;

    public readonly TypeKind Kind = typeKind;

    public readonly List<(string Name, string ColumnName, ITypeSymbol Type)> Members = members;
}
