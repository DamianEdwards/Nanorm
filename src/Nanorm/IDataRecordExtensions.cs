using System.ComponentModel;
using System.Data;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="IDataRecord"/> from the <c>Nanorm</c> package.
/// </summary>
public static class IDataRecordExtensions
{
    public static bool GetBoolean(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetBoolean(record.GetOrdinal(name));
    }

    public static byte GetByte(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetByte(record.GetOrdinal(name));
    }

    public static long GetBytes(this IDataRecord record, string name, long dataOffset, byte[] buffer, int bufferOffset, int length)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetBytes(record.GetOrdinal(name), dataOffset, buffer, bufferOffset, length);
    }

    public static char GetChar(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetChar(record.GetOrdinal(name));
    }

    public static long GetChars(this IDataRecord record, string name, long dataOffset, char[] buffer, int bufferOffset, int length)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetChars(record.GetOrdinal(name), dataOffset, buffer, bufferOffset, length);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IDataRecord GetData(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetData(record.GetOrdinal(name));
    }

    public static string GetDataTypeName(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDataTypeName(record.GetOrdinal(name));
    }

    public static DateTime GetDateTime(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDateTime(record.GetOrdinal(name));
    }

    public static decimal GetDecimal(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDecimal(record.GetOrdinal(name));
    }

    public static double GetDouble(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDouble(record.GetOrdinal(name));
    }

    public static Type GetFieldType(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetFieldType(record.GetOrdinal(name));
    }

    public static float GetFloat(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetFloat(record.GetOrdinal(name));
    }

    public static Guid GetGuid(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetGuid(record.GetOrdinal(name));
    }

    public static short GetInt16(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt16(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 32-bit signed integer value of the specified field.
    /// </summary>
    /// <param name="record">The record.</param>
    /// <param name="name">The name of the field.</param>
    /// <returns>The 32-bit signed integer value of the specified field.</returns>
    public static int GetInt32(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt32(record.GetOrdinal(name));
    }

    public static long GetInt64(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt64(record.GetOrdinal(name));
    }

    public static string GetString(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetString(record.GetOrdinal(name));
    }

    public static object GetValue(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetValue(record.GetOrdinal(name));
    }

    public static bool IsDBNull(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.IsDBNull(record.GetOrdinal(name));
    }
}
