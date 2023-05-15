using System.Buffers;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Nanorm.Npgsql;
using Npgsql;

namespace Nanorm.Sqlite;

/// <summary>
/// Custom interpolated string handler for Npgsql queries.
/// </summary>
[InterpolatedStringHandler]
public ref struct NpgsqlInterpolatedStringHandler
{
    private readonly StringBuilder _sb;
    private readonly NpgsqlParameter[]? _parameters;
    private readonly int _parameterCount;
    private int _parameterIndex;

    /// <summary>
    /// Creates a new <see cref="NpgsqlInterpolatedStringHandler"/> instance.
    /// </summary>
    /// <param name="literalLength">The length of the interpolated string literal.</param>
    /// <param name="formattedCount">The count of formatted placeholders.</param>
    public NpgsqlInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        _sb = StringBuilderPool.Acquire(literalLength);
        _parameterCount = formattedCount;
        _parameters = formattedCount > 0 ? ArrayPool<NpgsqlParameter>.Shared.Rent(_parameterCount) : null;
        _parameterIndex = 0;
    }

    /// <summary>
    /// Append string literal.
    /// </summary>
    /// <param name="value">The string literal to append.</param>
    public readonly void AppendLiteral(string value)
    {
        _sb.Append(value);
    }

    /// <summary>
    /// Append a parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value to append.</param>
    public void AppendFormatted<T>(T value)
    {
        var parameterPlaceholderIndex = _parameterIndex + 1;
        _parameters![_parameterIndex] = new NpgsqlParameter<T> { Value = value };
        _parameterIndex++;

        Span<char> parameterPlaceholder = stackalloc char[5]; // $ + max of 9999 parameters
        parameterPlaceholder[0] = '$';
        if (!parameterPlaceholderIndex.TryFormat(parameterPlaceholder[1..], out var charsWritten, default, CultureInfo.InvariantCulture))
        {
            throw new InvalidOperationException("Could not format parameter placeholder.");
        }
        _sb.Append(parameterPlaceholder[..(charsWritten + 1)]);
    }

    internal readonly NpgsqlCommand GetCommand(NpgsqlConnection connection)
    {
        var command = connection.CreateCommand(StringBuilderPool.GetStringAndRelease(_sb));
        if (_parameterCount > 0)
        {
            for (int i = 0; i < _parameterCount; i++)
            {
                command.Parameters.Add(_parameters![i]);
            }
        }
        return command;
    }

#if NET7_0_OR_GREATER
    internal readonly NpgsqlCommand GetCommand(NpgsqlDataSource npgsqlDataSource)
    {
        var command = npgsqlDataSource.CreateCommand(StringBuilderPool.GetStringAndRelease(_sb));
        if (_parameterCount > 0)
        {
            for (int i = 0; i < _parameterCount; i++)
            {
                command.Parameters.Add(_parameters![i]);
            }
            ArrayPool<NpgsqlParameter>.Shared.Return(_parameters!);
        }
        return command;
    }
#endif
}
