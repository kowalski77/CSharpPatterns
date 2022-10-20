using System.Runtime.CompilerServices;

namespace Playground.Invariants;

public static class ArgumentExtensions
{
    public static T NonNull<T>(this T value, [CallerArgumentExpression("value")] string? paramName = null) =>
        value ?? 
        throw new ArgumentNullException(paramName);
    
    public static string NonEmpty(this string value, [CallerArgumentExpression("value")] string? paramName = null) =>
        !string.IsNullOrWhiteSpace(value) ? value
        : throw new ArgumentException(paramName);

    public static decimal NonNegative(this decimal value, string name) =>
        value >= 0 ? value
        : throw new ArgumentException(name);

    public static int NonNegative(this int value, string name) =>
        value >= 0 ? value
        : throw new ArgumentException(name);

    public static decimal NonZero(this decimal value, string name) =>
        value != 0 ? value
        : throw new ArgumentException(name);

    public static TimeSpan NonZero(this TimeSpan value, string name) =>
    value > TimeSpan.Zero ? value
    : throw new ArgumentException(name);

    public static int InRange(this int value, int minInclusive, int maxExclusive, string name) =>
        value >= minInclusive && value < maxExclusive ? value
        : throw new IndexOutOfRangeException($"'{name}' is outside of range {minInclusive} thru {maxExclusive - 1}.");
}
