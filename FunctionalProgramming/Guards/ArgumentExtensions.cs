using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FunctionalProgramming.Guards;

public static class ArgumentExtensions
{
    public static T NonNull<T>([NotNull] this T value, [CallerArgumentExpression("value")] string? paramName = null) =>
        value ??
        throw new ArgumentNullException(paramName);
}
