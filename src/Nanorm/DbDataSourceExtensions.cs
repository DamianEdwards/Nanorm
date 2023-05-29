#if NET7_0_OR_GREATER
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Nanorm;

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="DbDataSource"/> from the <c>Nanorm</c> package.
/// </summary>
public static class DbDataSourceExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.QuerySingleAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.QuerySingleAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.QuerySingleAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.QueryAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.QueryAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.QueryAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.QueryAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(default);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(cancellationToken);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static async Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static async Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static async Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static async Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters) =>
        dataSource.CreateCommand(commandText).AddParameters(parameters);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbDataSource dataSource, string commandText, Action<DbParameterCollection>? configureParameters = null) =>
        dataSource.CreateCommand(commandText).Configure(configureParameters);
}
#endif
