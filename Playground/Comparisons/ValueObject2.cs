namespace Playground.Comparisons;

public abstract class ValueObject2 : IEquatable<ValueObject2>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public virtual bool Equals(ValueObject2? other)
    {
        if (other is null)
            return false;

        return this.GetType() == other.GetType()
            && this.GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj) => this.Equals(obj as ValueObject2);

    public override int GetHashCode() => this.GetEqualityComponents()
        .Aggregate(1, (current, obj) =>
        {
            unchecked
            {
                return current * 23 + obj.GetHashCode();
            }
        });

    public static bool operator ==(ValueObject2? a, ValueObject2? b)
    {
        if (a is null && b is null)
            return true;

        return a is not null && b is not null && a.Equals(b);
    }

    public static bool operator !=(ValueObject2 a, ValueObject2? b) => !(a == b);
}
