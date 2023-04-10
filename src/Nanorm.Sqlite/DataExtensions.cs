using System.Runtime.CompilerServices;
using Nanorm.Sqlite;

namespace Microsoft.Data.Sqlite;

public static class DataExtensions
{
    public static async Task<int> ExecuteAsync(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();
        return await cmd.ExecuteNonQueryAsync();
    }

    public static async Task<T?> QuerySingleAsync<T>(this SqliteConnection connection,
        string commandText,
        params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        var enumerable = connection.QueryAsync<T>(commandText, parameters);
        var enumerator = enumerable.GetAsyncEnumerator();

        return await enumerator.MoveNextAsync()
            ? enumerator.Current
            : default;
    }

    public static async IAsyncEnumerable<T?> QueryAsync<T>(this SqliteConnection connection,
        string commandText,
        params SqliteParameter[] parameters)
        where T : IDataReaderMapper<T>
    {
        using var reader = await connection.QueryAsync(commandText, parameters);

        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync())
        {
            yield return T.Map(reader);
        }
    }

    public static SqliteParameter AsDbParameter(this string? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this DateTime? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this DateTimeOffset? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this bool value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static SqliteParameter AsDbParameter(this bool? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this int value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static SqliteParameter AsDbParameter(this int? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this long value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static SqliteParameter AsDbParameter(this long? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    public static SqliteParameter AsDbParameter(this double value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object)value, name);

    public static SqliteParameter AsDbParameter(this double? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        AsDbParameter((object?)value, name);

    private static SqliteParameter AsDbParameter(this object? value, [CallerArgumentExpression(nameof(value))] string name = null!) =>
        new(CleanParameterName(name), value ?? DBNull.Value);

    private static async Task<SqliteDataReader> QueryAsync(this SqliteConnection connection,
        string commandText,
        params SqliteParameter[] parameters)
    {
        await using var cmd = connection.CreateCommand(commandText, parameters);
        await connection.OpenAsync();
        return await cmd.ExecuteReaderAsync();
    }

    private static SqliteCommand CreateCommand(this SqliteConnection connection, string commandText, params SqliteParameter[] parameters)
    {
        var cmd = connection.CreateCommand();
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
        cmd.CommandText = commandText;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
        for (var i = 0; i < parameters.Length; i++)
        {
            var parameter = parameters[i];
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
            return name.Substring(lastIndexOfPeriod + 1);
        }
        return name;
    }
}
