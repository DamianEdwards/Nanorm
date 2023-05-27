using System.Data;
using System.Runtime.CompilerServices;
using Nanorm.Sqlite;

namespace Microsoft.Data.Sqlite;

/// <summary>
/// Extension methods for <see cref="SqliteConnection"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static class SqliteConnectionExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync();

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var command = connection.CreateCommand(commandTextHandler);

        return ExecuteNonQueryAsync(connection, command, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return ExecuteNonQueryAsync(connection, cmd, cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync();

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    private static async Task<int> ExecuteNonQueryAsync(SqliteConnection connection, SqliteCommand command, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            return await command.ExecuteNonQueryAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync();

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return ExecuteScalarAsync(connection, cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return ExecuteScalarAsync(connection, cmd, cancellationToken);
    }

    private static async Task<object?> ExecuteScalarAsync(SqliteConnection connection, SqliteCommand command, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            return await command.ExecuteScalarAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync();

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync();

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return QuerySingleAsync<T>(connection, cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return QuerySingleAsync<T>(connection, cmd, cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync();

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    private static async Task<T?> QuerySingleAsync<T>(SqliteConnection connection, SqliteCommand command, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            await using var reader = await command.QuerySingleAsync(cancellationToken);

            return await reader.MapSingleAsync<T>(cancellationToken);
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync();

        await using var reader = await cmd.QueryAsync();

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return QueryAsync<T>(connection, cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QueryAsync(cancellationToken);

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return QueryAsync<T>(connection, cmd, cancellationToken);
    }

    private static async IAsyncEnumerable<T> QueryAsync<T>(SqliteConnection connection, SqliteCommand command, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            await using var reader = await command.QueryAsync(cancellationToken);

            await foreach (var item in reader.MapAsync<T>())
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();

        await using var reader = await cmd.QueryAsync();

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, [EnumeratorCancellation] CancellationToken cancellationToken, params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QueryAsync(cancellationToken);

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync();

        await using var reader = await cmd.QueryAsync();

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync(cancellationToken);

        await using var reader = await cmd.QueryAsync(cancellationToken);

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static async Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();

        return await cmd.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static async Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static async Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync();

        return await cmd.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static async Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        await using var cmd = connection.CreateCommand(commandText, configureParameters);
        await connection.OpenAsync(cancellationToken);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static SqliteCommand CreateCommand(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler) =>
        commandTextHandler.GetCommand(connection);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static SqliteCommand CreateCommand(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters) =>
        connection.CreateCommand(commandText).AddParameters(parameters);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static SqliteCommand CreateCommand(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection>? configureParameters = null)
    {
        var command = connection.CreateCommand(commandText);
        command.Configure(configureParameters);
        return command;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static SqliteCommand CreateCommand(this SqliteConnection connection, string commandText)
    {
        var command = connection.CreateCommand();
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
        command.CommandText = commandText;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
        return command;
    }
}
