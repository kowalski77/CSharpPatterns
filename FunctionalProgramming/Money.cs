namespace FunctionalProgramming;

public record Money : IComparable<Money>
{
    public int CompareTo(Money? other)
    {
        throw new NotImplementedException();
    }
}
