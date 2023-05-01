namespace FunctionalProgramming.Optional;

public abstract class Option<T>
{
    public static implicit operator Option<T>(None _) => new None<T>();
    public static implicit operator Option<T>(T value) => value is null ? new None<T>() : new Some<T>(value);

    public Option<T> ToMaybe() => throw new NotImplementedException();
}

public sealed class Some<T> : Option<T>
{
    public T Content { get; }

    public Some(T content) => Content = content;

    public override string ToString() => $"Some {Content?.ToString() ?? "<null>"}";
}

public sealed class None<T> : Option<T>
{
    public override string ToString() => $"None";
}

public sealed class None
{
    public static None Value { get; } = new();

    public static None<T> Of<T>() => new();
}