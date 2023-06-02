using System.Runtime.CompilerServices;
using Nanorm;

namespace System.Data.Common;

/// <summary>
/// Extension methods for <see cref="DbConnection"/> from the <c>Nanorm</c> package.
/// </summary>
public static partial class DbConnectionExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteScalarAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText);

        return cmd.ExecuteScalarAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsyncImpl(connection, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsyncImpl(connection, default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsyncImpl(connection, cancellationToken);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText, params DbPlaceholderParameter[] parameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText, params DbPlaceholderParameter[] parameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters)
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
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(connection, cancellationToken);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbConnection connection, string commandText, CommandBehavior commandBehavior, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var cmd = connection.CreateCommand(commandTextHandler);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="DbPlaceholderParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbConnection connection, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbConnection connection, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, default);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="connection">The <see cref="DbConnection"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbConnection connection, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = connection.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(connection, commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbConnection connection, SqlInterpolatedStringHandler commandTextHandler) =>
        commandTextHandler.GetCommand(connection);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DbCommand CreateCommand(this DbConnection connection, string commandText, params DbPlaceholderParameter[] parameters) =>
        connection.CreateCommand(commandText).AddParameters(parameters);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DbCommand CreateCommand(this DbConnection connection, string commandText, Action<DbParameterCollection> configureParameters)
    {
        var command = connection.CreateCommand(commandText);
        command.Configure(configureParameters);
        return command;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DbCommand CreateCommand(this DbConnection connection, string commandText)
    {
        var command = connection.CreateCommand();
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
        command.CommandText = commandText;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
        return command;
    }
}
