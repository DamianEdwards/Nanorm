using System.Runtime.CompilerServices;
#if NET7_0_OR_GREATER
using Nanorm.Npgsql;
#endif

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="NpgsqlDataReader"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static class NpgsqlDataReaderExtensions
{
#if NET7_0_OR_GREATER
    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return MapSingleAsyncImpl<T>(reader, default);
    }

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return MapSingleAsyncImpl<T>(reader, cancellationToken);
    }
#endif

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return MapSingleAsyncImpl(reader, mapper, default);
    }

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return MapSingleAsyncImpl(reader, mapper, cancellationToken);
    }

#if NET7_0_OR_GREATER
    internal static async Task<T?> MapSingleAsyncImpl<T>(this NpgsqlDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        if (!reader.HasRows)
        {
            return default;
        }

        await reader.ReadAsync(cancellationToken);

        return T.Map(reader);
    }
#endif

    internal static async Task<T?> MapSingleAsyncImpl<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, CancellationToken cancellationToken)
    {
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
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return MapAsyncImpl<T>(reader, default);
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return MapAsyncImpl<T>(reader, cancellationToken);
    }
#endif

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return MapAsyncImpl(reader, mapper, default);
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="NpgsqlDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return MapAsyncImpl(reader, mapper, cancellationToken);
    }

#if NET7_0_OR_GREATER
    internal static async IAsyncEnumerable<T> MapAsyncImpl<T>(this NpgsqlDataReader reader, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync(cancellationToken))
        {
            yield return T.Map(reader);
        }
    }
#endif

    internal static async IAsyncEnumerable<T> MapAsyncImpl<T>(this NpgsqlDataReader reader, Func<NpgsqlDataReader, T> mapper, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
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
