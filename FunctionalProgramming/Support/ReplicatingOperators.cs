using System.Text;

namespace FunctionalProgramming.Support;

public static class ReplicatingOperators
{
    public static IEnumerable<T> RepeatRandomly<T>(this IEnumerable<T> sequence)
    {
        var data = sequence.ToArray();
        Random numbersGenerator = new(42);

        while (true)
            yield return data[numbersGenerator.Next(data.Length)];
    }

    internal static IEnumerable<char> GetRandomEnglishLetters() =>
        GetRandomNumericValues(rng => rng.Next(26)).Select(i => (char)('a' + i));

    private static IEnumerable<T> GetRandomNumericValues<T>(Func<Random, T> getNext)
    {
        Random numbersGenerator = new(42);
        while (true) yield return getNext(numbersGenerator);
    }

    internal static IEnumerable<byte[]> GetRandomByteArrays(int length)
    {
        List<byte> pending = new();

        foreach (var b in GetRandomBytes())
        {
            pending.Add(b);
            if (pending.Count == length)
            {
                yield return pending.ToArray();
                pending.Clear();
            }
        }
    }

    internal static IEnumerable<byte> GetRandomBytes() =>
        GetRandomNumericValues(rng => rng.Next(256)).Select(i => (byte)i);

    internal static IEnumerable<string> GetRandomEnglishStrings(int length)
    {
        StringBuilder result = new();

        foreach (var c in GetRandomEnglishLetters())
        {
            _ = result.Append(c);
            if (result.Length == length)
            {
                yield return result.ToString();
                _ = result.Clear();
            }
        }
    }
}