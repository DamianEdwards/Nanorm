using System.Runtime.CompilerServices;
using Nanorm;

namespace System.Data.Common;

/// <summary>
/// Extension methods for <see cref="DbCommand"/> from the <c>Nanorm</c> package.
/// </summary>
public static class DbCommandExtensions
{
    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QuerySingleAsync(this DbCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
    }

    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QuerySingleAsync(this DbCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync();
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbCommand command, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Adds the specified parameters to the command's <see cref="DbParameterCollection"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>The command.</returns>
    public static DbCommand AddParameters(this DbCommand command, DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (parameters is null || parameters.Length == 0)
        {
            return command;
        }

        for (var i = 0; i < parameters.Length; i++)
        {
            var dbParameter = command.CreateParameter();
            dbParameter.ParameterName = parameters[i].Name;
            dbParameter.Value = parameters[i].Value;
            command.Parameters.Add(dbParameter);
        }

        return command;
    }

    /// <summary>
    /// Configures the command using the specified delegate.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="configureParameters">A delegate to configure the parameters.</param>
    /// <returns>The command.</returns>
    public static DbCommand Configure(this DbCommand command, Action<DbParameterCollection>? configureParameters = null)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (configureParameters is not null)
        {
            configureParameters(command.Parameters);
        }

        return command;
    }

#if NET7_0_OR_GREATER
    internal static async Task<T?> QuerySingleAsyncImpl<T>(this DbCommand command, DbConnection connection, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        return await command.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    internal static async Task<T?> QuerySingleAsyncImpl<T>(this DbCommand command, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);

            return await reader.MapSingleAsyncImpl<T>(cancellationToken);
        }
    }

    internal static async IAsyncEnumerable<T> QueryAsyncImpl<T>(this DbCommand command, DbConnection connection, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
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

    internal static async IAsyncEnumerable<T> QueryAsyncImpl<T>(this DbCommand command, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
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
