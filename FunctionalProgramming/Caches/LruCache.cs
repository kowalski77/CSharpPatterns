﻿using FunctionalProgramming.Support;

namespace FunctionalProgramming.Caches;

// read-though cache, last recently used
public class LruCache<TKey, TValue> where TKey : IEquatable<TKey>
{
    public LruCache(int capacity, Func<TKey, TValue> fetch)
    {
        this.Capacity = capacity.NonNegative(nameof(capacity));
        this.Fetch = fetch;
    }

    public int Capacity { get; private set; }

    private Func<TKey, TValue> Fetch { get; }

    private LinkedList<(TKey, TValue)> LruList { get; } = new();

    private Dictionary<TKey, LinkedListNode<(TKey, TValue)>> Items { get; } = new();

    public TValue Read(TKey key)
    {
        if (this.Items.TryGetValue(key, out LinkedListNode<(TKey _, TValue value)>? node))
        {
            this.LruList.Remove(node);
            this.Items[key] = this.LruList.AddLast(node.Value);
            
            return node.Value.value;
        }
        else
        {
            var value = this.Fetch(key);
            this.Items[key] = this.LruList.AddLast((key, value));
            this.Purge();

            return value;
        }
    }

    public void Resize(int capacity)
    {
        this.Capacity = capacity.NonNegative(nameof(capacity));
        this.Purge();
    }

    private void Purge()
    {
        while (this.Items.Count > this.Capacity)
        {
            (var key, _) = this.LruList.First();
            this.LruList.RemoveFirst();
            this.Items.Remove(key);
        }
    }
}
