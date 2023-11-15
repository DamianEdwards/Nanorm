using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="IDataRecord"/> from the <c>Nanorm</c> package.
/// </summary>
public static class IDataRecordExtensions
{
    /// <summary>
    /// Gets the value of the specified column as a <see cref="Boolean"/>.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The value of the column.</returns>
    public static bool GetBoolean(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetBoolean(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 8-bit unsigned integer value of the specified column.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The value of the column.</returns>
    public static byte GetByte(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetByte(record.GetOrdinal(name));
    }

    /// <summary>
    /// Reads a stream of bytes from the specified column offset into the buffer as an array, starting at the given buffer offset.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <param name="dataOffset">The index within the field from which to start the read operation.</param>
    /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
    /// <param name="bufferOffset">The index for buffer to start the read operation.</param>
    /// <param name="length">The number of bytes to read.</param>
    /// <returns>The actual number of bytes read.</returns>
    public static long GetBytes(this IDataRecord record, string name, long dataOffset, byte[] buffer, int bufferOffset, int length)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetBytes(record.GetOrdinal(name), dataOffset, buffer, bufferOffset, length);
    }

    /// <summary>
    /// Gets the character value of the specified column.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The value of the column.</returns>
    public static char GetChar(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetChar(record.GetOrdinal(name));
    }

    /// <summary>
    /// Reads a stream of characters from the specified column offset into the buffer as an array, starting at the given buffer offset.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <param name="dataOffset">The index within the row from which to start the read operation.</param>
    /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
    /// <param name="bufferOffset">The index for buffer to start the read operation.</param>
    /// <param name="length">The number of bytes to read.</param>
    /// <returns>The number of bytes to read.</returns>
    public static long GetChars(this IDataRecord record, string name, long dataOffset, char[] buffer, int bufferOffset, int length)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetChars(record.GetOrdinal(name), dataOffset, buffer, bufferOffset, length);
    }

    /// <summary>
    /// Returns an <see cref="IDataReader"/> for the specified column ordinal.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The <see cref="IDataReader"/> for the specified column ordinal.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IDataRecord GetData(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetData(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the data type information for the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The data type information for the specified field.</returns>
    public static string GetDataTypeName(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDataTypeName(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the date and time data value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The date and time data value of the specified field.</returns>
    public static DateTime GetDateTime(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDateTime(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the fixed-position numeric value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The fixed-position numeric value of the specified field.</returns>
    public static decimal GetDecimal(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDecimal(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the double-precision floating point number of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The double-precision floating point number of the specified field.</returns>
    public static double GetDouble(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetDouble(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the <see cref="Type" /> information corresponding to the type of <see cref="Object"/> that would be
    /// returned from <see cref="GetValue(IDataRecord, string)"/>.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>
    /// The <see cref="Type" /> information corresponding to the type of <see cref="Object"/> that would
    /// be returned from <see cref="GetValue(IDataRecord, string)"/>.
    /// </returns>
    [return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)]
    public static Type GetFieldType(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetFieldType(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the single-precision floating point number of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The single-precision floating point number of the specified field.</returns>
    public static float GetFloat(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetFloat(record.GetOrdinal(name));
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The <see cref="Guid"/> value of the specified field.</returns>
    public static Guid GetGuid(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetGuid(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 16-bit signed integer value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The 16-bit signed integer value of the specified field.</returns>
    public static short GetInt16(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt16(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 32-bit signed integer value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The 32-bit signed integer value of the specified field.</returns>
    public static int GetInt32(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt32(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 64-bit signed integer value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The 64-bit signed integer value of the specified field.</returns>
    public static long GetInt64(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetInt64(record.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the <see cref="string"/> value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The <see cref="string"/> value of the specified field.</returns>
    public static string GetString(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetString(record.GetOrdinal(name));
    }

    /// <summary>
    /// Return the value of the specified field.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>The <see cref="object"/> which will contain the field value upon return.</returns>
    public static object GetValue(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.GetValue(record.GetOrdinal(name));
    }

    /// <summary>
    /// Return whether the specified field is set to null.
    /// </summary>
    /// <param name="record">The <see cref="IDataRecord"/>.</param>
    /// <param name="name">The column name.</param>
    /// <returns>
    /// <see langword="true"/> if the specified field is set to <see langword="null"/> otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool IsDBNull(this IDataRecord record, string name)
    {
        ArgumentNullException.ThrowIfNull(record);

        return record.IsDBNull(record.GetOrdinal(name));
    }
}
