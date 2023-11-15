namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="IAsyncEnumerable{T}"/> from the <c>Nanorm</c> package.
/// </summary>
public static class AsyncEnumerableExtensions
{
    /// <summary>
    /// Asynchronously converts an <see cref="IAsyncEnumerable{T}"/> to a <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable">The <see cref="IAsyncEnumerable{T}"/>.</param>
    /// <param name="initialCapacity">An optional initial capacity for the returned <see cref="List{T}"/>.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The <see cref="List{T}"/>.</returns>
    public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> enumerable, int? initialCapacity = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(enumerable);

        var list = initialCapacity.HasValue ? new List<T>(initialCapacity.Value) : [];

        await foreach (var item in enumerable.WithCancellation(cancellationToken))
        {
            list.Add(item);
        }

        return list;
    }
}
