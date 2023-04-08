using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Nanorm;

/// <summary>
/// 
/// </summary>
public static class DbConnectionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="commandText"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static async Task<int> ExecuteAsync(this DbConnection connection, string commandText, params (string Name, object? Value)[] parameters)
    {
        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="commandText"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static async Task<T?> QuerySingleAsync<T>(this DbConnection connection,
        string commandText,
        params (string Name, object? Value)[] parameters)
        where T : IDataReaderMapper<T>
    {
        var enumerable = connection.QueryAsync<T>(commandText, parameters);
        var enumerator = enumerable.GetAsyncEnumerator();

        return await enumerator.MoveNextAsync()
            ? enumerator.Current
            : default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="commandText"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static async IAsyncEnumerable<T?> QueryAsync<T>(this DbConnection connection,
        string commandText,
        params (string Name, object? Value)[] parameters)
        where T : IDataReaderMapper<T>
    {
        await using var reader = await connection.QueryAsync(commandText, parameters);

        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync())
        {
            yield return T.Map(reader);
        }
    }

    public static (string Name, object? Value) AsDbParameter(this string? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this DateTime? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this DateTimeOffset? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this bool value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static (string Name, object? Value) AsDbParameter(this bool? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this int value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static (string Name, object? Value) AsDbParameter(this int? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this long value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static (string Name, object? Value) AsDbParameter(this long? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static (string Name, object? Value) AsDbParameter(this double value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static (string Name, object? Value) AsDbParameter(this double? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    private static (string Name, object? Value) AsDbParameter(this object? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        (CleanParameterName(name), value ?? DBNull.Value);

    private static async Task<DbDataReader> QueryAsync(this DbConnection connection,
        string commandText,
        params (string Name, object? Value)[] parameters)
    {
        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();
        return await cmd.ExecuteReaderAsync();
    }

    private static DbCommand CreateCommand(this DbConnection connection, string commandText, params (string Name, object? Value)[] parameters)
    {
        using var cmd = connection.CreateCommand();
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
        cmd.CommandText = commandText;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
        for (var i = 0; i < parameters.Length; i++)
        {
            var (name, value) = parameters[i];
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            cmd.Parameters.Add(parameter);
        }
        return cmd;
    }

    private static string CleanParameterName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var lastIndexOfPeriod = name.LastIndexOf('.');
        if (lastIndexOfPeriod > 0)
        {
            return name[(lastIndexOfPeriod + 1)..];
        }
        return name;
    }
}
