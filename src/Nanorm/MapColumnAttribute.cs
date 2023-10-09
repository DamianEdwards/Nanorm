namespace Nanorm;

#if NET7_0_OR_GREATER
/// <summary>
/// Indicates the property or field should be mapped to the specified column in the database.<br />
/// Use in conjunction with <see cref="DataRecordMapperAttribute"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class MapColumnAttribute(string columnName) : Attribute
{
    /// <summary>
    /// The name of the column in the database.
    /// </summary>
    public string ColumnName { get; } = columnName;
}
#endif
