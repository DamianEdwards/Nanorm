using System.Runtime.CompilerServices;

namespace Microsoft.Data.Sqlite;

/// <summary>
/// Extension methods related to working with <see cref="SqliteParameter"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static class SqliteParameterExtensions
{
    /// <summary>
    /// Creates a <see cref="SqliteParameter"/> from the value.
    /// </summary>
    /// <param name="value">The parameter value.</param>
    /// <param name="name">The parameter name.</param>
    /// <returns>The parameter.</returns>
    public static SqliteParameter AsDbParameter(this object? value, [CallerArgumentExpression(nameof(value))] string? name = null)
    {
        return new SqliteParameter(CleanParameterName(name), value);
    }

    private static string? CleanParameterName(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        var lastIndexOfPeriod = name.LastIndexOf('.');
        if (lastIndexOfPeriod > 0)
        {
            return name[(lastIndexOfPeriod + 1)..];
        }
        return name;
    }

    /// <summary>
    /// Creates an array of <see cref="SqliteParameter"/> from the value
    /// </summary>
    /// <param name="value">An array of parameter values</param>
    /// <returns>An array of parameters</returns>
    public static SqliteParameter[] AsDbParameter(this object[]? value)
    {
        var parameters = new SqliteParameter[value.Length];

        ExceptionHelpers.ThrowIfNullOrEmpty(value);

        for (var i = 0; i < value.Length; i++)
            parameters[i] = new SqliteParameter($"param{i+1}", value[i]);

        return parameters;
    }
}
