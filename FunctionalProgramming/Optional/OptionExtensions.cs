using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Optional;

public static class OptionExtensions
{
    public static Option<TResult> Map<T, TResult>(this Option<T> obj, Func<T, TResult> map) =>
        obj is Some<T> some ? new Some<TResult>(map.NonNull()(some.Content)) : new None<TResult>();

    public static Option<T> Filter<T>(this Option<T> obj, Func<T, bool> predicate) =>
        obj is Some<T> some && !predicate.NonNull()(some.Content) ? new None<T>() : obj;

    public static T Reduce<T>(this Option<T> obj, T substitute) =>
        obj is Some<T> some ? some.Content : substitute.NonNull();

    public static T Reduce<T>(this Option<T> obj, Func<T> substitute) =>
        obj is Some<T> some ? some.Content : substitute.NonNull()();

    public static TR Match<T, TR>(this Option<T> obj, Func<T, TR> some, Func<TR> none) =>
        obj is Some<T> someObj ? some.NonNull()(someObj.Content) : none.NonNull()();

    public static async Task<TR> Match<T, TR>(this Option<T> obj, Func<T, Task<TR>> some, Func<TR> none) =>
        obj is Some<T> someObj ?
        await some.NonNull()(someObj.Content).ConfigureAwait(false) :
        none.NonNull()();
}