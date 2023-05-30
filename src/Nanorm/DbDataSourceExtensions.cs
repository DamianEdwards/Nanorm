#if NET7_0_OR_GREATER
using System.Runtime.CompilerServices;
using Nanorm;

namespace System.Data.Common;

/// <summary>
/// Extension methods for <see cref="DbDataSource"/> from the <c>Nanorm</c> package.
/// </summary>
public static partial class DbDataSourceExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(default); ;
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteScalarAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteScalarAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteScalarAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsyncImpl(default);
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
    public static Task<object?> ExecuteScalarAsync(this DbDataSource dataSource, string commandText, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteScalarAsyncImpl(cancellationToken);
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
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

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
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.QuerySingleAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
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
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
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
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

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
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.QueryAsyncImpl<T>(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
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
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
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
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="DbParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values to <see cref="DbParameter"/>, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params DbPlaceholderParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="DbDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="DbDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="DbParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="DbDataReader"/>.</returns>
    public static Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
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
    public static Task<DbDataReader> QueryAsync(this DbDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<DbParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbDataSource dataSource, SqlInterpolatedStringHandler commandTextHandler) =>
        commandTextHandler.GetCommand(dataSource);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbDataSource dataSource, string commandText, params DbPlaceholderParameter[] parameters) =>
        dataSource.CreateCommand(commandText).AddParametersImpl(parameters);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DbCommand CreateCommand(this DbDataSource dataSource, string commandText, Action<DbParameterCollection>? configureParameters = null) =>
        dataSource.CreateCommand(commandText).Configure(configureParameters);
}
#endif
