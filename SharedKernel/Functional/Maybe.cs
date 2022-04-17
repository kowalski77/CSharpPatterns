namespace SharedKernel.Functional;

[Serializable]
public readonly struct Maybe<T> : IEquatable<Maybe<T>>
{
    private readonly T value = default!;

    private Maybe(T value)
    {
        this.value = value;
        this.HasValue = true;
    }

    public T Value => this.ValueOrThrow();

    public bool HasValue { get; }

    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return this.HasValue ? some(this.value) : none();
    }

    public static implicit operator Maybe<T>(T value)
    {
        return value == null ? new Maybe<T>() : new Maybe<T>(value);
    }

    public static implicit operator Maybe<T>(Maybe value)
    {
        return None;
    }

    public static Maybe<T> None => new();

    public Maybe<TResult> Map<TResult>(Func<T, TResult> convert)
    {
        return !this.HasValue ? new Maybe<TResult>() : convert(this.value);
    }

    public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> convert)
    {
        return !this.HasValue ? new Maybe<TResult>() : convert(this.value);
    }

    public Maybe<TResult> SelectMany<T2, TResult>(
        Func<T, Maybe<T2>> convert,
        Func<T, T2, TResult> finalSelect)
    {
        if (!this.HasValue)
        {
            return new Maybe<TResult>();
        }

        var converted = convert(this.value);

        return !converted.HasValue ? new Maybe<TResult>() : finalSelect(this.value, converted.value);
    }

    public Maybe<T> Where(Func<T, bool> predicate)
    {
        if (!this.HasValue)
        {
            return new Maybe<T>();
        }

        return predicate(this.value) ? this : new Maybe<T>();
    }

    public T ValueOr(T defaultValue)
    {
        return this.HasValue ? this.value : defaultValue;
    }

    public T ValueOr(Func<T> defaultValueFactory)
    {
        return this.HasValue ? this.value : defaultValueFactory();
    }

    public Maybe<T> ValueOrMaybe(Maybe<T> alternativeValue)
    {
        return this.HasValue ? this : alternativeValue;
    }

    public Maybe<T> ValueOrMaybe(Func<Maybe<T>> alternativeValueFactory)
    {
        return this.HasValue ? this : alternativeValueFactory();
    }

    public T ValueOrThrow(string? errorMessage = null)
    {
        if (this.HasValue)
        {
            return this.value;
        }

        throw new InvalidOperationException(errorMessage);
    }

    public Maybe<T> ToMaybe()
    {
        throw new NotImplementedException();
    }

    public bool Equals(Maybe<T> other)
    {
        return this.HasValue == other.HasValue && EqualityComparer<T>.Default.Equals(this.value, other.value);
    }

    public override bool Equals(object? obj)
    {
        return obj is Maybe<T> other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.HasValue, this.value);
    }

    public static bool operator ==(Maybe<T> left, Maybe<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Maybe<T> left, Maybe<T> right)
    {
        return !left.Equals(right);
    }
}

public struct Maybe
{
    public static Maybe None => new();
}