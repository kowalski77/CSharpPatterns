﻿using FunctionalProgramming.Models;

namespace FunctionalProgramming.Caches;

public static class MemoizedCache
{
    public static IReadOnlyList<Currency> Create(IEnumerable<string> currencyCodes, int size)
    {
        ArgumentNullException.ThrowIfNull(currencyCodes);

        Dictionary<string, Currency> knownCurrencies = new(new CurrencyCodeEqualityComparer());
        var currencies = new Currency[size];

        using var code = currencyCodes.GetEnumerator();
        for (var i = 0; i < currencies.Length; i++)
        {
            code.MoveNext();
            if (!knownCurrencies.TryGetValue(code.Current, out var currency))
                knownCurrencies[code.Current] = currencies[i] = new Currency(code.Current);
            else
                currencies[i] = currency;
        }

        return currencies;
    }
}
