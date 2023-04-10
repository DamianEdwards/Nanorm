using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Nanorm;

/// <summary>
/// Extension methods related to working with <see cref="DbParameter"/> from the <c>Nanorm</c> package.
/// </summary>
public static class DbParameterExtensions
{
    /// <summary>
    /// Creates a strong a strongly-typed parameter from the value.
    /// </summary>
    /// <param name="value">The parameter value.</param>
    /// <param name="name">The parameter name.</param>
    /// <returns>The strongly-typed parameter.</returns>
    public static DbPlaceholderParameter AsDbParameter(this object? value, [CallerArgumentExpression(nameof(value))] string? name = null)
    {
        return new DbPlaceholderParameter(name, value);
    }
}

/// <summary>
/// Represents a database command parameter which will be used to create a <see cref="DbParameter" /> by calling <see cref="DbCommand.CreateParameter" />.
/// </summary>
public record struct DbPlaceholderParameter(string? Name, object? Value);
