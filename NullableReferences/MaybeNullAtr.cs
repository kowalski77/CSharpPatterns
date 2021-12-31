namespace NullableReferences;

// TODO: need to study this attribute when declaring generics T?
public class MaybeNullAtr
{
    public void Run()
    {

    }
}

public static class StuffSupport
{
    public static void UseDictionary(string key, IDictionary<string, string> dictionary)
    {
        ArgumentNullException.ThrowIfNull(dictionary);

        if (dictionary.TryGetValue(key, out var value)) // --> //     bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
        {
            Console.WriteLine("String length:" + value.Length);
        }
    }

    // public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string? value);
}