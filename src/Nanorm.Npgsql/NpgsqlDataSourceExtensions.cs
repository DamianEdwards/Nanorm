#if NET7_0_OR_GREATER
using System.Data;
using System.Runtime.CompilerServices;
using Nanorm.Npgsql;

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="NpgsqlDataSource"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static partial class NpgsqlDataSourceExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteNonQueryAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteNonQueryAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(default);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteScalarAsyncImpl(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler, CancellationToken cancellationToken)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.QueryAsyncImpl<T>(cancellationToken);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
    }

#if NET7_0_OR_GREATER
    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandTextHandler">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(dataSource);

        var cmd = dataSource.CreateCommand(commandTextHandler);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
    }
#endif

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, parameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<NpgsqlParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, default);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);

        var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return cmd.ExecuteReaderAsyncImpl(commandBehavior, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static NpgsqlCommand CreateCommand(this NpgsqlDataSource dataSource, NpgsqlInterpolatedStringHandler commandTextHandler) =>
        commandTextHandler.GetCommand(dataSource);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static NpgsqlCommand CreateCommand(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters) =>
        dataSource.CreateCommand(commandText).AddParametersImpl(parameters);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static NpgsqlCommand CreateCommand(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection>? configureParameters = null) =>
        dataSource.CreateCommand(commandText).Configure(configureParameters);
}
#endif
