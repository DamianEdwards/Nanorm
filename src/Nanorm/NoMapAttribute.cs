namespace Nanorm;

#if NET7_0_OR_GREATER
/// <summary>
/// Indicates the property or field should not be mapped to a column in the database.<br />
/// Use in conjunction with <see cref="DataRecordMapperAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class NoMapAttribute : Attribute
{

}
#endif
