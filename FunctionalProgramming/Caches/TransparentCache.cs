namespace FunctionalProgramming.Caches;

public class TransparentCache<T> where T : IEquatable<T>
{
    private HashSet<T> KnownObjects { get; } = new();

    public T GetCached(T obj)
    {
        // HACK: technique to share references of objects to avoid preassure in CPU
        if (!this.KnownObjects.TryGetValue(obj, out var result)) 
        {
            this.KnownObjects.Add(obj);
            result = obj;
        }
        return result;
    }
}

public class TransparentCache
{
    private Dictionary<Type, object> KnownCaches { get; } = new();

    public T GetCached<T>(T item) where T : IEquatable<T> =>
        this.GetCache<T>().GetCached(item);

    public IEnumerable<T> GetCached<T>(IEnumerable<T> items) where T : IEquatable<T> =>
        items.Select(this.GetCached);

    private TransparentCache<T> GetCache<T>() where T : IEquatable<T>
    {
        if (this.KnownCaches.TryGetValue(typeof(T), out var known) &&
            known is TransparentCache<T> existing)
            return existing;

        TransparentCache<T> cache = new();
        this.KnownCaches[typeof(T)] = cache;

        return cache;
    }
}
