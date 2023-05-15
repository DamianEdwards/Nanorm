using System.Buffers;
using System.Collections.Concurrent;
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

    private static readonly ConcurrentDictionary<int, string> _generatedQueries = new(Environment.ProcessorCount * 2, 10);

    private string[] _builder;
    private int _builderIndex;
    private readonly NpgsqlParameter[]? _parameters;
    private readonly int _parameterCount;
    private int _parameterIndex;
    private int _totalLength;
    private int _hashCode;

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
        _hashCode = HashCode.Combine(_parameterCount);
    }

    /// <summary>
    /// Append string literal.
    /// </summary>
    /// <param name="value">The string literal to append.</param>
    public void AppendLiteral(string value)
    {
        _builder[_builderIndex++] = value;
        _totalLength += value.Length;
        _hashCode = HashCode.Combine(_hashCode, value);
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

        ApplyParameters(command);
        return command;
    }

#if NET7_0_OR_GREATER
    internal readonly NpgsqlCommand GetCommand(NpgsqlDataSource npgsqlDataSource)
    {
        var command = npgsqlDataSource.CreateCommand(GetCommandText());

        ApplyParameters(command);
        return command;
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void ApplyParameters(NpgsqlCommand command)
    {
        if (_parameterCount > 0)
        {
            for (int i = 0; i < _parameterCount; i++)
            {
                command.Parameters.Add(_parameters![i]);
            }
            ArrayPool<NpgsqlParameter>.Shared.Return(_parameters!);
        }
    }

    private readonly string GetCommandText()
    {
        var commandText = _generatedQueries.GetOrAdd(_hashCode, (key, data) =>
        {
            return string.Create(data._totalLength, data, static (span, data) =>
            {
                var (_, array, count, parameters) = data;

                var index = 0;
                var parameterIndex = 1;
                var parameterMarker = _parameterMarker.AsSpan();
                Span<char> parameterPlaceholder = stackalloc char[5]; // max of 99999 parameters

                foreach (var item in array.AsSpan(0, count))
                {
                    if (item.AsSpan().SequenceEqual(parameterMarker))
                    {
                        // Copy in the parameter marker
                        parameterMarker.CopyTo(span[index..]);
                        index += _parameterMarkerLength;

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
        }, (_totalLength, _builder, _builderIndex, _parameters));

        ArrayPool<string>.Shared.Return(_builder);
        return commandText;
    }
}
