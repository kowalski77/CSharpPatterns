namespace FunctionalProgramming.ChainComparer;

file sealed class ComparerChainNode<T> : IComparer<T>
{
    private IComparer<T> First { get; }
    
    private IComparer<T> Next { get; }

    public ComparerChainNode(IComparer<T> first, IComparer<T> next) => (this.First, this.Next) = (first, next);

    public int Compare(T? x, T? y) => this.First.Compare(x, y) is int decision && decision != 0 ? decision : this.Next.Compare(x, y);
}

public static class ComparerChainNode
{
    public static IComparer<T> Then<T>(this IComparer<T> first, IComparer<T> next) => new ComparerChainNode<T>(first, next);
}
