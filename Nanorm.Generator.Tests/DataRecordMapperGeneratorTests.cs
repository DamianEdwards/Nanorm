using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nanorm.Generator.Tests;

public class DataRecordMapperGeneratorTests
{
    //lang=cs
    private const string SampleCode = """
                                      using System;

                                      namespace TestNamespace

                                      [Nanorm.DataRecordMapperAttribute]
                                      public sealed partial class Sample
                                      {
                                          public byte A { get; set; }
                                          public short B { get; set; }
                                          public int C { get; set; }
                                          public long D { get; set; }
                                          public float E { get; set; }
                                          public double F { get; set; }
                                          public decimal G { get; set; }
                                          public string H { get; set; }
                                          public bool I { get; set; }
                                          public Guid J { get; set; }
                                          public char K { get; set; }
                                          
                                          public byte? L { get; set; }
                                          public short? M { get; set; }
                                          public int? N { get; set; }
                                          public long? O { get; set; }
                                          public float? P { get; set; }
                                          public double? Q { get; set; }
                                          public decimal? R { get; set; }
                                          public string? S { get; set; }
                                          public bool? T { get; set; }
                                          public Guid? U { get; set; }
                                          public char? V { get; set; }
                                      }
                                      """;

    //lang=cs
    private const string Expected = """
                                    using global::Nanorm;
                                    namespace TestNamespace
                                    {
                                        partial class Sample : IDataRecordMapper<global::TestNamespace.Sample>
                                        {
                                            public static global::TestNamespace.Sample Map(global::System.Data.IDataRecord dataRecord) =>
                                                new()
                                                {
                                                    // 22 members
                                                    A = dataRecord.GetByte("A"),
                                                    B = dataRecord.GetInt16("B"),
                                                    C = dataRecord.GetInt32("C"),
                                                    D = dataRecord.GetInt64("D"),
                                                    E = dataRecord.GetFloat("E"),
                                                    F = dataRecord.GetDouble("F"),
                                                    G = dataRecord.GetDecimal("G"),
                                                    H = dataRecord.GetString("H"),
                                                    I = dataRecord.GetBoolean("I"),
                                                    J = dataRecord.GetGuid("J"),
                                                    K = dataRecord.GetChar("K"),
                                                    L = dataRecord.GetNullableByte("L"),
                                                    M = dataRecord.GetNullableInt16("M"),
                                                    N = dataRecord.GetNullableInt32("N"),
                                                    O = dataRecord.GetNullableInt64("O"),
                                                    P = dataRecord.GetNullableFloat("P"),
                                                    Q = dataRecord.GetNullableDouble("Q"),
                                                    R = dataRecord.GetNullableDecimal("R"),
                                                    S = dataRecord.GetNullableString("S"),
                                                    T = dataRecord.GetNullableBoolean("T"),
                                                    U = dataRecord.GetNullableGuid("U"),
                                                    V = dataRecord.GetNullableChar("V"),
                                                };
                                        }
                                    }

                                    """;

    [Fact]
    public void TestGenerator()
    {
        var driver = CSharpGeneratorDriver.Create(new DataRecordMapperGenerator());

        var compilation = CSharpCompilation.Create(
            nameof(DataRecordMapperGeneratorTests),
            [CSharpSyntaxTree.ParseText(SampleCode)],
            [
                // To support 'System.Attribute' inheritance, add reference to 'System.Private.CoreLib'
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                // and to 'System.Runtime'
                MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
                // and to the Attribute class
                MetadataReference.CreateFromFile(typeof(DataRecordMapperAttribute).Assembly.Location)
            ]
        );

        var runResult = driver.RunGenerators(compilation).GetRunResult();

        var generatedFileSyntax = runResult.GeneratedTrees.Single(
            tree => tree.FilePath.EndsWith("DataRecordMapperPartialTypes.g.cs")
        );
        var generatedCode = generatedFileSyntax.GetText().ToString();

        Assert.Equal(
            Expected,
            generatedCode,
            ignoreLineEndingDifferences: true,
            ignoreWhiteSpaceDifferences: true,
            ignoreAllWhiteSpace: true
        );
    }
}