using FunctionalProgramming.Models;

namespace FunctionalProgramming.Caches;

public static class SimpleCache
{
    public static IReadOnlyList<Currency> Create(IEnumerable<string> currencyCodes, int size)
    {
        ArgumentNullException.ThrowIfNull(currencyCodes);

        var currencies = new List<Currency>(size);

        using var code = currencyCodes.GetEnumerator();
        for (var i = 0; i < size; i++)
        {
            code.MoveNext();
            Currency currency = new(code.Current);
            currencies.Add(currency);
        }

        return currencies;
    }
}
