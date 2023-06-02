using System.Data;
using System.Runtime.CompilerServices;
using Npgsql;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="NpgsqlCommand"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static class NpgsqlCommandExtensions
{
    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QuerySingleAsync(this NpgsqlCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
    }

    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QuerySingleAsync(this NpgsqlCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync();
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlCommand command, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Adds the specified parameters to the command's <see cref="NpgsqlParameterCollection"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>The command.</returns>
    public static NpgsqlCommand AddParameters(this NpgsqlCommand command, NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.AddParametersImpl(parameters);
    }

    /// <summary>
    /// Configures the command using the specified delegate.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="configureParameters">A delegate to configure the parameters.</param>
    /// <returns>The command.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static NpgsqlCommand Configure(this NpgsqlCommand command, Action<NpgsqlParameterCollection>? configureParameters = null)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (configureParameters is not null)
        {
            configureParameters(command.Parameters);
        }

        return command;
    }

    internal static NpgsqlCommand AddParametersImpl(this NpgsqlCommand command, NpgsqlParameter[] parameters)
    {
        if (parameters is null || parameters.Length == 0)
        {
            return command;
        }

        for (int i = 0; i < parameters.Length; i++)
        {
            command.Parameters.Add(parameters[i]);
        }

        return command;
    }

    internal static async Task<int> ExecuteNonQueryAsyncImpl(this NpgsqlCommand command, NpgsqlConnection connection, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        return await command.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    internal static async Task<int> ExecuteNonQueryAsyncImpl(this NpgsqlCommand command, CancellationToken cancellationToken)
    {
        await using (command)
        {
            return await command.ExecuteNonQueryAsync(cancellationToken);
        }
    }

    internal static async Task<object?> ExecuteScalarAsyncImpl(this NpgsqlCommand command, NpgsqlConnection connection, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        return await command.ExecuteScalarAsyncImpl(cancellationToken);
    }

    internal static async Task<object?> ExecuteScalarAsyncImpl(this NpgsqlCommand command, CancellationToken cancellationToken)
    {
        await using (command)
        {
            return await command.ExecuteScalarAsync(cancellationToken);
        }
    }

    internal static async Task<NpgsqlDataReader> ExecuteReaderAsyncImpl(this NpgsqlCommand command, NpgsqlConnection connection, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        return await command.ExecuteReaderAsyncImpl(commandBehavior, cancellationToken);
    }

    internal static async Task<NpgsqlDataReader> ExecuteReaderAsyncImpl(this NpgsqlCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        await using (command)
        {
            return await command.ExecuteReaderAsync(commandBehavior, cancellationToken);
        }
    }

#if NET7_0_OR_GREATER
    internal static async Task<T?> QuerySingleAsyncImpl<T>(this NpgsqlCommand command, NpgsqlConnection connection, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        return await command.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    internal static async Task<T?> QuerySingleAsyncImpl<T>(this NpgsqlCommand command, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);

            return await reader.MapSingleAsyncImpl<T>(cancellationToken);
        }
    }

    internal static async IAsyncEnumerable<T> QueryAsyncImpl<T>(this NpgsqlCommand command, NpgsqlConnection connection, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            await foreach (var item in reader.MapAsyncImpl<T>(cancellationToken))
            {
                yield return item;
            }
        }
    }

    internal static async IAsyncEnumerable<T> QueryAsyncImpl<T>(this NpgsqlCommand command, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            await foreach (var item in reader.MapAsyncImpl<T>(cancellationToken))
            {
                yield return item;
            }
        }
    }
#endif
}
