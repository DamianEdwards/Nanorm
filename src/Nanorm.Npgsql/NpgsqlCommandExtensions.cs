using System.Data;

namespace Npgsql;

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

        return QueryAsync(command, CommandBehavior.SingleResult | CommandBehavior.SingleRow);
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
        return QueryAsync(command, CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return QueryAsync(command, CommandBehavior.Default);
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

        return QueryAsync(command, CommandBehavior.Default, cancellationToken);
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

        if (parameters is null || parameters.Length == 0)
        {
            return command;
        }

        return command.Configure(parameterCollection =>
        {
            for (var i = 0; i < parameters.Length; i++)
            {
                parameterCollection.Add(parameters[i]);
            }
        });
    }


    /// <summary>
    /// Adds the specified parameters to the command's <see cref="NpgsqlParameterCollection"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>The command.</returns>
    public static NpgsqlCommand AddParameters(this NpgsqlCommand command, IList<NpgsqlParameter> parameters)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (parameters is null || parameters.Count == 0)
        {
            return command;
        }

        return command.Configure(parameterCollection =>
        {
            for (var i = 0; i < parameters.Count; i++)
            {
                parameterCollection.Add(parameters[i]);
            }
        });
    }
    /// <summary>
    /// Configures the command using the specified delegate.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="configureParameters">A delegate to configure the parameters.</param>
    /// <returns>The command.</returns>
    public static NpgsqlCommand Configure(this NpgsqlCommand command, Action<NpgsqlParameterCollection>? configureParameters = null)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (configureParameters is not null)
        {
            configureParameters(command.Parameters);
        }

        return command;
    }
}
