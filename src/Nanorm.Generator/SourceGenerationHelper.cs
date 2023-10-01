using System.Text;
using Microsoft.CodeAnalysis;

namespace Nanorm.Generator;

internal static class SourceGenerationHelper
{
    public const string DataRecordMapperAttribute = """
        namespace Nanorm
        {
            /// <summary>Indicates the partial class should have an implementation of <see cref="Nanorm.IDataRecordMapper{T}" /> generated.</summary>
            [System.AttributeUsage(System.AttributeTargets.Class)]
            internal class DataRecordMapperAttribute : System.Attribute
            {
            }
        }
        """;

    public static readonly Dictionary<string, string> GetMethodsMap = new()
    {
        { "byte", "GetByte" },
        { "short", "GetInt16" },
        { "int", "GetInt32" },
        { "long", "GetInt64" },
        { "float", "GetFloat" },
        { "double", "GetDouble" },
        { "decimal", "GetDecimal" },
        { "string", "GetString" },
        { "bool", "GetBoolean" },
        { "System.Guid", "GetGuid" },
        { "System.Char", "GetChar" },
    };

    public static bool IsMappableType(ITypeSymbol typeSymbol) => GetMethodsMap.ContainsKey(typeSymbol.ToString());

    public static string GenerateExtensionClass(List<ClassToGenerate> classesToGenerate)
    {
        var sb = new StringBuilder();
        sb.AppendLine("using Nanorm;");

        foreach (var classToGenerate in classesToGenerate)
        {
            if (!string.IsNullOrEmpty(classToGenerate.Namespace))
            {
                sb.AppendLine($$"""
            namespace {{classToGenerate.Namespace}}
            {
            """);
            }

            sb.AppendLine($$"""
                public partial class {{classToGenerate.Name}} : IDataRecordMapper<{{classToGenerate.Name}}>
                {
                    public static {{classToGenerate.Name}} Map(System.Data.IDataRecord dataRecord) =>
                        new()
                        {
            """);

            sb.AppendLine($$"""
                            // {{classToGenerate.Members.Count}} members
            """);

            foreach (var member in classToGenerate.Members)
            {
                sb.AppendLine($"""
                            {member.Name} = dataRecord.{GetMethodsMap[member.Type.ToString()]}("{member.Name}"),
            """);
            }

            // Close the Map method
            sb.AppendLine("""
                        };
            """);

            // Close the class
            sb.AppendLine("""
                }
            """);

            if (!string.IsNullOrEmpty(classToGenerate.Namespace))
            {
                // Close the namespace
                sb.AppendLine("""
            }
            """);
            }
        }

        return sb.ToString();
    }
}
