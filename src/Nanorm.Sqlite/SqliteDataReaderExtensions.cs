using System.Runtime.CompilerServices;
#if NET7_0_OR_GREATER
using Nanorm.Sqlite;
#endif

namespace Microsoft.Data.Sqlite;

/// <summary>
/// Extension methods for <see cref="SqliteDataReader"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static class SqliteDataReaderExtensions
{
#if NET7_0_OR_GREATER
    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader)
        where T : IDataReaderMapper<T>
        => MapSingleAsync(reader, T.Map);

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
        => MapSingleAsync(reader, T.Map, cancellationToken);
#endif

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static async Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper)
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
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static async Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, CancellationToken cancellationToken)
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

#if NET7_0_OR_GREATER
    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader)
        where T : IDataReaderMapper<T>
        => MapAsync(reader, T.Map);

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
        => MapAsync(reader, T.Map, cancellationToken);
#endif

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static async IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper)
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
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static async IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, [EnumeratorCancellation] CancellationToken cancellationToken)
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
