using System.Buffers;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Nanorm;

/// <summary>
/// Custom interpolated string handler for Sqlite queries.
/// </summary>
[InterpolatedStringHandler]
public ref struct SqlInterpolatedStringHandler
{
    private const string _parameterMarker = "@";
    // !! This must be kept in sync with length of const string above !!
    private const int _parameterMarkerLength = 1;

    private static readonly string[] _parameterNamesCache = Enumerable.Range(1, 9).Select(i => FormattableString.Invariant($"{_parameterMarker}{i}")).ToArray();
    private static readonly ConcurrentDictionary<int, string> _generatedQueryCache = new(Environment.ProcessorCount, 10);

    private readonly DbPlaceholderParameter[] _parameters;
    private readonly int _parameterCount;
    private readonly string[] _builder;
    private int _parameterIndex;
    private int _builderIndex;
    private int _totalLength;
    private int _hashCode;

    /// <summary>
    /// Creates a new <see cref="SqlInterpolatedStringHandler"/> instance.
    /// </summary>
    /// <param name="literalLength">The length of the interpolated string literal.</param>
    /// <param name="formattedCount">The count of formatted placeholders.</param>
    public SqlInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        // Total number of string fragments
        _builder = ArrayPool<string>.Shared.Rent(literalLength + formattedCount);
        _parameterCount = formattedCount;
        _parameters = formattedCount > 0 ? ArrayPool<DbPlaceholderParameter>.Shared.Rent(_parameterCount) : Array.Empty<DbPlaceholderParameter>();
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
        var parameterName = GetParameterName(_parameterIndex);

        _parameters[_parameterIndex] = new DbPlaceholderParameter(parameterName, value);
        _builder[_builderIndex] = _parameterMarker;

        _parameterIndex++;
        _builderIndex++;

        // Increase by length of parameter placeholder (marker char + count of digits in parameter index)
        _totalLength += _parameterMarkerLength + (int)Math.Floor(Math.Log10(_parameterIndex) + 1);
    }

    internal readonly DbCommand GetCommand(DbConnection connection)
    {
        var command = connection.CreateCommand(GetCommandText());

        ApplyParameters(command);
        return command;
    }

#if NET7_0_OR_GREATER
    internal readonly DbCommand GetCommand(DbDataSource dataSource)
    {
        var command = dataSource.CreateCommand(GetCommandText());

        ApplyParameters(command);
        return command;
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void ApplyParameters(DbCommand command)
    {
        if (_parameterCount > 0)
        {
            for (int i = 0; i < _parameterCount; i++)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = _parameters[i].Name;
                parameter.Value = _parameters[i].Value;
                command.Parameters.Add(parameter);
            }
            ArrayPool<DbPlaceholderParameter>.Shared.Return(_parameters);
        }
    }

    private readonly string GetCommandText()
    {
        var commandText = _generatedQueryCache.GetOrAdd(_hashCode, static (key, getOrAddData) =>
        {
            return string.Create(getOrAddData._totalLength, getOrAddData, static (span, data) =>
            {
                var (_, array, count, parameters) = data;

                var index = 0;
                var parameterIndex = 1;
                var parameterMarker = _parameterMarker.AsSpan();
                Span<char> parameterPlaceholder = stackalloc char[5]; // max of 99999 parameters, SQLite max is actually 32766 https://www.sqlite.org/limits.html#max_variable_number

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string GetParameterName(int _parameterIndex)
    {
        // Not all database providers support unnamed parameters so we have to generate a name
        var parameterName = _parameterIndex < _parameterNamesCache.Length
            ? _parameterNamesCache[_parameterIndex]
            // TODO: Optimize parameter name generation for names beyond initial cache
            : _parameterMarker + (_parameterIndex + 1).ToString(CultureInfo.InvariantCulture);
        return parameterName;
    }
}
