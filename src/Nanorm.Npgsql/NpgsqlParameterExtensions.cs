namespace Npgsql;

/// <summary>
/// Extension methods related to working with <see cref="NpgsqlParameter"/> from the <c>Nanorm.Npgsql</c> package.
/// </summary>
public static class NpgsqlParameterExtensions
{
    /// <summary>
    /// Adds a strongly-typed parameter to the collection.
    /// </summary>
    /// <typeparam name="T">The type of the parameter value.</typeparam>
    /// <param name="parameters">The parameter collection.</param>
    /// <param name="value">The parameter value.</param>
    /// <returns>The parameter collection.</returns>
    public static NpgsqlParameterCollection AddTyped<T>(this NpgsqlParameterCollection parameters, T? value)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        parameters.Add(new NpgsqlParameter<T>
        {
            TypedValue = value
        });
        
        return parameters;
    }

    /// <summary>
    /// Creates a strong a strongly-typed parameter from the value.
    /// </summary>
    /// <typeparam name="T">The type of the parameter value.</typeparam>
    /// <param name="value">The parameter value.</param>
    /// <returns>The strongly-typed parameter.</returns>
    public static NpgsqlParameter<T> AsTypedDbParameter<T>(this T? value)
    {
        var parameter = new NpgsqlParameter<T>
        {
            TypedValue = value
        };

        return parameter;
    }
}
