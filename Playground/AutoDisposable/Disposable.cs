namespace Playground.AutoDisposable;

public class Disposable<T>
    where T : IDisposable
{
    private Func<T> Factory { get; }

    internal Disposable(Func<T> factory)
    {
        this.Factory = factory;
    }

    public void Use(Action<T> action)
    {
        using var target = this.Factory();
        action(target);
    }

    public TResult Use<TResult>(Func<T, TResult> map)
    {
        using var target = this.Factory();
        return map(target);
    }
}

public static class Disposable
{
    public static Disposable<T> Of<T>(Func<T> factory)
      where T : IDisposable
      => new(factory);
}

