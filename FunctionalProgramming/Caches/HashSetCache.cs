using FunctionalProgramming.Models;

namespace FunctionalProgramming.Caches;

public static class HashSetCache
{
    // Share references in collections to avoid presure in CPU
    public static IReadOnlyList<Currency> Create(IEnumerable<string> currencyCodes, int size)
    {
        ArgumentNullException.ThrowIfNull(currencyCodes);

        HashSet<Currency> knownCurrencies = new();
        var currencies = new Currency[size];

        using var code = currencyCodes.GetEnumerator();
        for (var i = 0; i < currencies.Length; i++)
        {
            code.MoveNext();
            Currency currency = new(code.Current);
            if (knownCurrencies.TryGetValue(currency, out var known))
            {
                currency = known;
            }
            else
            {
                knownCurrencies.Add(currency);
            }
            currencies[i] = currency;
        }
        return currencies;
    }
}
