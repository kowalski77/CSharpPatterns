namespace SharedKernel.Functional;

public class Maybe<T>
{
    private readonly bool hasValue;

    private readonly T value = default!;

    protected Maybe()
    {
    }

    private Maybe(T value)
    {
        this.value = value;
        this.hasValue = true;
    }

    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        return this.hasValue ? some(this.value) : none();
    }

    public static implicit operator Maybe<T>(T value)
    {
        return value == null ? new Maybe<T>() : new Maybe<T>(value);
    }

    public bool TryGetValue(out T tryValue)
    {
        if (this.hasValue)
        {
            tryValue = this.value;
            return true;
        }

        tryValue = default!;

        return false;
    }

    public Maybe<TResult> Map<TResult>(Func<T, TResult> convert)
    {
        return !this.hasValue ? new Maybe<TResult>() : convert(this.value);
    }

    public Maybe<TResult> Bind<TResult>(Func<T, Maybe<TResult>> convert)
    {
        return !this.hasValue ? new Maybe<TResult>() : convert(this.value);
    }

    public Maybe<TResult> SelectMany<T2, TResult>(
        Func<T, Maybe<T2>> convert,
        Func<T, T2, TResult> finalSelect)
    {
        if (!this.hasValue)
        {
            return new Maybe<TResult>();
        }

        var converted = convert(this.value);

        return !converted.hasValue ? new Maybe<TResult>() : finalSelect(this.value, converted.value);
    }

    public Maybe<T> Where(Func<T, bool> predicate)
    {
        if (!this.hasValue)
        {
            return new Maybe<T>();
        }

        return predicate(this.value) ? this : new Maybe<T>();
    }

    public T ValueOr(T defaultValue)
    {
        return this.hasValue ? this.value : defaultValue;
    }

    public T ValueOr(Func<T> defaultValueFactory)
    {
        return this.hasValue ? this.value : defaultValueFactory();
    }

    public Maybe<T> ValueOrMaybe(Maybe<T> alternativeValue)
    {
        return this.hasValue ? this : alternativeValue;
    }

    public Maybe<T> ValueOrMaybe(Func<Maybe<T>> alternativeValueFactory)
    {
        return this.hasValue ? this : alternativeValueFactory();
    }

    public T ValueOrThrow(string errorMessage)
    {
        if (this.hasValue)
        {
            return this.value;
        }

        throw new InvalidOperationException(errorMessage);
    }

    public Maybe<T> ToMaybe()
    {
        throw new NotImplementedException();
    }

    public class None : Maybe<T>
    {
    }
}