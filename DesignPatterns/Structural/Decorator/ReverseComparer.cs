namespace DesignPatterns.Structural.Decorator;

file sealed class ReverseComparer<T> : IComparer<T>
{
    public readonly IComparer<T> other;

    public ReverseComparer(IComparer<T> other) => this.other = other;

    public int Compare(T? x, T? y) => this.other.Compare(y, x);
}

public static class ComparerFactory
{
    public static IComparer<T> Reverse<T>(this IComparer<T> other) =>
        other is ReverseComparer<T> rc ?
        rc.other :
        new ReverseComparer<T>(other);
}
