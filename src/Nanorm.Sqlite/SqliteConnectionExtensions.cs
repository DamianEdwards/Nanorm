using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="SqliteConnection"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static partial class SqliteConnectionExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
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

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
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

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
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
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
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
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteScalarAsync(connection, default);
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

        return cmd.ExecuteScalarAsync(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteScalarAsync(connection, cancellationToken);
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

        return cmd.ExecuteScalarAsync(connection, cancellationToken);
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
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsync(connection, default);
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
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsync(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsync(connection, default);
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
    public static Task<object?> ExecuteScalarAsync(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsync(connection, cancellationToken);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.QuerySingleAsyncImpl<T>(connection, default);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.QuerySingleAsyncImpl<T>(connection, default);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.QuerySingleAsyncImpl<T>(connection, cancellationToken);
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
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.QuerySingleAsyncImpl<T>(connection, cancellationToken);
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
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.QuerySingleAsyncImpl<T>(connection, default);
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
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.QuerySingleAsyncImpl<T>(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.QuerySingleAsyncImpl<T>(connection, default);
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
    public static Task<T?> QuerySingleAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.QuerySingleAsyncImpl<T>(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.QueryAsyncImpl<T>(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.QueryAsyncImpl<T>(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.QueryAsyncImpl<T>(connection, cancellationToken);
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
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.QueryAsyncImpl<T>(connection, cancellationToken);
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
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.QueryAsyncImpl<T>(connection, default);
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
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, CancellationToken cancellationToken, params SqliteParameter[] parameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.QueryAsyncImpl<T>(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(connection, default);
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
    public static IAsyncEnumerable<T> QueryAsync<T>(this SqliteConnection connection, string commandText, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(connection, cancellationToken);
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
    public static Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
    }
#endif

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
    public static Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="SqliteConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="SqliteParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, Action<SqliteParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
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
    public static Task<SqliteDataReader> QueryAsync(this SqliteConnection connection, string commandText, CommandBehavior commandBehavior, Action<SqliteParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static SqliteCommand CreateCommand(this SqliteConnection connection, SqliteInterpolatedStringHandler commandTextHandler) =>
        commandTextHandler.GetCommand(connection);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static SqliteCommand CreateCommand(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters) =>
        connection.CreateCommand(commandText).AddParametersImpl(parameters);

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
