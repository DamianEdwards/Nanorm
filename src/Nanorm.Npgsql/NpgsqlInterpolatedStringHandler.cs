using System.Buffers;
using System.Globalization;
using System.Runtime.CompilerServices;
using Npgsql;

namespace Nanorm.Sqlite;

/// <summary>
/// Custom interpolated string handler for Npgsql queries.
/// </summary>
[InterpolatedStringHandler]
public ref struct NpgsqlInterpolatedStringHandler
{
    private const string _parameterMarker = "$";
    // !! This must be kept in sync with length of const string above !!
    private const int _parameterMarkerLength = 1;
    private string[] _builder;
    private int _builderIndex;
    private readonly NpgsqlParameter[]? _parameters;
    private readonly int _parameterCount;
    private int _parameterIndex;
    private int _totalLength;

    /// <summary>
    /// Creates a new <see cref="NpgsqlInterpolatedStringHandler"/> instance.
    /// </summary>
    /// <param name="literalLength">The length of the interpolated string literal.</param>
    /// <param name="formattedCount">The count of formatted placeholders.</param>
    public NpgsqlInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        // Total number of string fragments
        _builder = ArrayPool<string>.Shared.Rent(literalLength + formattedCount);
        _parameterCount = formattedCount;
        _parameters = formattedCount > 0 ? ArrayPool<NpgsqlParameter>.Shared.Rent(_parameterCount) : null;
    }

    /// <summary>
    /// Append string literal.
    /// </summary>
    /// <param name="value">The string literal to append.</param>
    public void AppendLiteral(string value)
    {
        _builder[_builderIndex++] = value;
        _totalLength += value.Length;
    }

    /// <summary>
    /// Append a parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value to append.</param>
    public void AppendFormatted<T>(T value)
    {
        _parameters![_parameterIndex++] = new NpgsqlParameter<T> { Value = value };
        _builder[_builderIndex++] = _parameterMarker;

        // Increase by length of parameter placeholder (marker char + count of digits in parameter index)
        _totalLength += _parameterMarkerLength + (int)Math.Floor(Math.Log10(_parameterIndex) + 1);
    }

    internal readonly NpgsqlCommand GetCommand(NpgsqlConnection connection)
    {
        var command = connection.CreateCommand(GetCommandText());

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

#if NET7_0_OR_GREATER
    internal readonly NpgsqlCommand GetCommand(NpgsqlDataSource npgsqlDataSource)
    {
        var command = npgsqlDataSource.CreateCommand(GetCommandText());

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

    private readonly string GetCommandText()
    {
        var commandText = string.Create(_totalLength, (_builder, _builderIndex, _parameters), static (span, data) =>
        {
            var (array, count, parameters) = data;

            var index = 0;
            var parameterIndex = 1;
            var parameterMarker = _parameterMarker.AsSpan();
            Span<char> parameterPlaceholder = stackalloc char[5]; // max of 99999 parameters

            foreach (var item in array.AsSpan(0, count))
            {
                if (item.AsSpan().SequenceEqual(parameterMarker))
                {
                    // Copy in the parameter marker
                    span[index..][0] = parameterMarker[0];
                    index++;

                    // Copy in the parameter index
                    if (!parameterIndex.TryFormat(parameterPlaceholder, out var charsWritten, default, CultureInfo.InvariantCulture))
                    {
                        throw new InvalidOperationException("Could not format parameter placeholder.");
                    }
                    parameterPlaceholder[..charsWritten].CopyTo(span[index..]);
                    parameterIndex++;
                    index += charsWritten;
                }
                else
                {
                    item.AsSpan().CopyTo(span[index..]);

                    index += item.Length;
                }
            }
        });
        ArrayPool<string>.Shared.Return(_builder);
        return commandText;
    }
}
