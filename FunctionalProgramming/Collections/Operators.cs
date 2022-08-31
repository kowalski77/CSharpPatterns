namespace FunctionalProgramming.Collections;

public static class Operators
{
    public static IOrderedList<T> ToFullySortedList<T>(
    this IEnumerable<T> sequence, IComparer<T> comparer) =>
    new FullySortedList<T>(sequence, comparer);

    public static IOrderedList<T> ToFullySortedList<T, TKey>(
        this IEnumerable<T> sequence, Func<T, TKey> keySelector)
        where TKey : IComparable<TKey> =>
        sequence.ToFullySortedList(Comparer(keySelector));

    private static IComparer<T> Comparer<T, TKey>(Func<T, TKey> keySelector)
        where TKey : IComparable<TKey> =>
        Comparer<T>.Create((a, b) => keySelector(a).CompareTo(keySelector(b)));
}
