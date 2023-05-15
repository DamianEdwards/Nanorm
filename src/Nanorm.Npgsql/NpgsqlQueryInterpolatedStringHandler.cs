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
public readonly ref struct NpgsqlInterpolatedStringHandler
{
    private readonly StringBuilder _sb;
    private readonly List<NpgsqlParameter> _parameters;

    /// <summary>
    /// Creates a new <see cref="NpgsqlInterpolatedStringHandler"/> instance.
    /// </summary>
    /// <param name="literalLength">The length of the interpolated string literal.</param>
    /// <param name="formattedCount">The count of formatted placeholders.</param>
    public NpgsqlInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        _sb = StringBuilderPool.Acquire(literalLength);
        _parameters = new(formattedCount);
    }

    /// <summary>
    /// Append string literal.
    /// </summary>
    /// <param name="value">The string literal to append.</param>
    public void AppendLiteral(string value)
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
        _parameters.Add(new NpgsqlParameter<T> { Value = value });

        Span<char> parameterPlaceholder = stackalloc char[5]; // $ + max of 9999 parameters
        parameterPlaceholder[0] = '$';
        if (!_parameters.Count.TryFormat(parameterPlaceholder[1..], out var charsWritten, default, CultureInfo.InvariantCulture))
        {
            throw new InvalidOperationException("Could not format parameter placeholder.");
        }
        _sb.Append(parameterPlaceholder[..(charsWritten + 1)]);
    }

    /// <summary>
    /// Gets the SQL command text.
    /// </summary>
    /// <returns>The SQL command text.</returns>
    public string GetSqlCommandText() => StringBuilderPool.GetStringAndRelease(_sb);

    /// <summary>
    /// Gets the parameters for the SQL command.
    /// </summary>
    /// <returns>The list of parameters for the SQL command.</returns>
    public List<NpgsqlParameter> GetParameters() => _parameters;
}
