using System.Data;
using System.Runtime.CompilerServices;
using Nanorm.Npgsql;

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="NpgsqlDataSource"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static class NpgsqlDataSourceExtensions
{
    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Executes a command that does not return any results.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the number of rows affected if known; -1 otherwise.</returns>
    public static async Task<int> ExecuteAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteScalarAsync();
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the first column of the first row in the first returned result set.
    /// All other columns, rows, and result sets are ignored.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the value.</returns>
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteScalarAsync();
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
    public static async Task<object?> ExecuteScalarAsync(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteScalarAsync(cancellationToken);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        await using var reader = await cmd.QuerySingleAsync();

        return await reader.MapSingleAsync<T>();
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
    public static async Task<T?> QuerySingleAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        await using var reader = await cmd.QuerySingleAsync(cancellationToken);

        return await reader.MapSingleAsync<T>();
    }

    /// <summary>
    /// Executes a command and returns the rows mapped to instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText);

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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, [EnumeratorCancellation] CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

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
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>s.</returns>
    public static async IAsyncEnumerable<T> QueryAsync<T>(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection> configureParameters, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        await using var reader = await cmd.QueryAsync(cancellationToken);

        await foreach (var item in reader.MapAsync<T>())
        {
            yield return item;
        }
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static async Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <param name="parameters">Parameters to use when executing the command text.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static async Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, CancellationToken cancellationToken, params NpgsqlParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, parameters);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="NpgsqlDataReader"/>.
    /// </summary>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior"/>.</param>
    /// <param name="configureParameters">A delegate to configured the <see cref="NpgsqlParameterCollection"/> before the command is executed.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="NpgsqlDataReader"/>.</returns>
    public static async Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<NpgsqlParameterCollection> configureParameters)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteReaderAsync(commandBehavior);
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
    public static async Task<NpgsqlDataReader> QueryAsync(this NpgsqlDataSource dataSource, string commandText, CommandBehavior commandBehavior, Action<NpgsqlParameterCollection> configureParameters, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ArgumentException.ThrowIfNullOrEmpty(commandText);

        await using var cmd = dataSource.CreateCommand(commandText, configureParameters);

        return await cmd.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    private static NpgsqlCommand CreateCommand(this NpgsqlDataSource dataSource, string commandText, params NpgsqlParameter[] parameters) =>
        dataSource.CreateCommand(commandText).AddParameters(parameters);

    private static NpgsqlCommand CreateCommand(this NpgsqlDataSource dataSource, string commandText, Action<NpgsqlParameterCollection>? configureParameters = null) =>
        dataSource.CreateCommand(commandText).Configure(configureParameters);
}
