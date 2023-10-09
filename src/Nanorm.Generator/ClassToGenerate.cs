using Microsoft.CodeAnalysis;

namespace Nanorm.Generator;

internal readonly struct ClassToGenerate
{
    public readonly string? Namespace;

    public readonly string Name;

    public readonly List<(string Name, string ColumnName, ITypeSymbol Type)> Members;

    public ClassToGenerate(string? @namespace, string name, List<(string Name, string ColumnName, ITypeSymbol Type)> members)
    {
        Namespace = @namespace;
        Name = name;
        Members = members;
    }
}
