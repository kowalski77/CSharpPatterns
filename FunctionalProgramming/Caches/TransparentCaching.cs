namespace FunctionalProgramming.Caches;

public static class TransparentCaching
{
    [ThreadStatic] private static TransparentCache cache = new();

    public static IEnumerable<T> Cached<T>(this IEnumerable<T> items)
        where T : IEquatable<T> => cache.GetCached(items);
}
