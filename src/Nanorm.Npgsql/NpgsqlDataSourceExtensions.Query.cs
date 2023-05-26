﻿#if NET7_0_OR_GREATER
using System.CodeDom.Compiler;
using Nanorm.Npgsql;

namespace Npgsql;

/// <summary>
/// Extension methods for <see cref="NpgsqlDataSource"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
[GeneratedCode("TextTemplatingFileGenerator", "1.0.0.0")]
public static partial class NpgsqlDataSourceExtensions
{
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3, 
        NpgsqlParameter param4
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        NpgsqlParameter param4,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3, 
        NpgsqlParameter param4, 
        NpgsqlParameter param5
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        NpgsqlParameter param4,
        NpgsqlParameter param5,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3, 
        NpgsqlParameter param4, 
        NpgsqlParameter param5, 
        NpgsqlParameter param6
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        NpgsqlParameter param4,
        NpgsqlParameter param5,
        NpgsqlParameter param6,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param7">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3, 
        NpgsqlParameter param4, 
        NpgsqlParameter param5, 
        NpgsqlParameter param6, 
        NpgsqlParameter param7
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);
        ArgumentNullException.ThrowIfNull(param7);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param7">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        NpgsqlParameter param4,
        NpgsqlParameter param5,
        NpgsqlParameter param6,
        NpgsqlParameter param7,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);
        ArgumentNullException.ThrowIfNull(param7);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param7">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param8">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1, 
        NpgsqlParameter param2, 
        NpgsqlParameter param3, 
        NpgsqlParameter param4, 
        NpgsqlParameter param5, 
        NpgsqlParameter param6, 
        NpgsqlParameter param7, 
        NpgsqlParameter param8
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);
        ArgumentNullException.ThrowIfNull(param7);
        ArgumentNullException.ThrowIfNull(param8);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);
        cmd.Parameters.Add(param8);

        return QuerySingleAsync<T>(cmd, CancellationToken.None);
    }

    /// <summary>
    /// Executes a command maps the first row returned to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type the result is being map to.</typeparam>
    /// <param name="dataSource">The <see cref="NpgsqlDataSource"/>.</param>
    /// <param name="commandText">The SQL command text.</param>
    /// <param name="param1">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param2">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param3">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param4">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param5">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param6">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param7">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="param8">
    /// A parameter to use when executing the command text. Use the <see cref="NpgsqlParameterExtensions.AsTypedDbParameter{T}(T)"/>
    /// method to convert values to <see cref="NpgsqlParameter{T}"/>, e.g. <c>myValue.AsTypedDbParameter()</c>.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the mapped <typeparamref name="T"/>.</returns>
    public static Task<T?> QuerySingleAsync<T>(
        this NpgsqlDataSource dataSource,
        string commandText,
        NpgsqlParameter param1,
        NpgsqlParameter param2,
        NpgsqlParameter param3,
        NpgsqlParameter param4,
        NpgsqlParameter param5,
        NpgsqlParameter param6,
        NpgsqlParameter param7,
        NpgsqlParameter param8,
        CancellationToken cancellationToken
        )
        where T : IDataReaderMapper<T>
    {
        ArgumentNullException.ThrowIfNull(dataSource);
        ExceptionHelpers.ThrowIfNullOrEmpty(commandText);
        ArgumentNullException.ThrowIfNull(param1);
        ArgumentNullException.ThrowIfNull(param2);
        ArgumentNullException.ThrowIfNull(param3);
        ArgumentNullException.ThrowIfNull(param4);
        ArgumentNullException.ThrowIfNull(param5);
        ArgumentNullException.ThrowIfNull(param6);
        ArgumentNullException.ThrowIfNull(param7);
        ArgumentNullException.ThrowIfNull(param8);

        var cmd = dataSource.CreateCommand(commandText);
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);
        cmd.Parameters.Add(param8);

        return QuerySingleAsync<T>(cmd, cancellationToken);
    }
}
#endif