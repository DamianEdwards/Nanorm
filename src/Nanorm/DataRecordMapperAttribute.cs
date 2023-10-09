namespace Nanorm;

#if NET7_0_OR_GREATER
/// <summary>
/// Indicates the partial class should have an implementation of <see cref="IDataRecordMapper{T}" /> generated.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class DataRecordMapperAttribute : Attribute
{

}
#endif
