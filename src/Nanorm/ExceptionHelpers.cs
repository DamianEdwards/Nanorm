using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System;

internal static class ExceptionHelpers
{
    public static void ThrowIfNullOrEmpty([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
#if NET6_0
        if (string.IsNullOrEmpty(argument))
        {
            ThrowNullOrEmptyException(argument, paramName);
        }
#else
        ArgumentException.ThrowIfNullOrEmpty(argument, paramName);
#endif
    }

#if NET6_0
    [DoesNotReturn]
    private static void ThrowNullOrEmptyException(string? argument, string? paramName)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);
        throw new ArgumentException("The value cannot be an empty string.", paramName);
    }
#endif

    public static void ThrowIfNullOrEmpty(object[] argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
            throw new ArgumentException("Array cannot be null", paramName);
        else if (argument.Length == 0)
                throw new ArgumentException("Array cannot be empty", paramName);
    }
}
