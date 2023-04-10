using System.Linq;
using System.Runtime.CompilerServices;
using Nanorm.Npgsql;

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="NpgsqlDataReaderExtensions"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static class NpgsqlDataReaderExtensions
{
    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader)
        where T : IDataReaderMapper<T>
        => MapSingleAsync(reader, T.Map);

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
        => MapSingleAsync(reader, T.Map, cancellationToken);

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static async Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        if (!reader.HasRows)
        {
            return default;
        }

        await reader.ReadAsync();

        return mapper(reader);
    }

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static async Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        if (!reader.HasRows)
        {
            return default;
        }

        await reader.ReadAsync(cancellationToken);

        return mapper(reader);
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader)
        where T : IDataReaderMapper<T>
        => MapAsync(reader, T.Map);

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
        => MapAsync(reader, T.Map, cancellationToken);

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static async IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync())
        {
            yield return mapper(reader);
        }
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static async IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync(cancellationToken))
        {
            yield return mapper(reader);
        }
    }
}
