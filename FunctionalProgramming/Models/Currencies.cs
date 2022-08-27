using FunctionalProgramming.Support;

namespace FunctionalProgramming.Models;

public static class Currencies
{
    public static Currency Dolar => new("USD");

    public static Currency Euro => new("EUR");

    public static Currency Yen => new("JPY");

    public static IEnumerable<Currency> TestCurrencies =>
        ReplicatingOperators.GetRandomEnglishStrings(3)
            .Select(code => new Currency(code));

    public static IEnumerable<string> TestCurrencyCodes =>
        TestCurrencies.Select(currency => currency.Code);

    public static IEnumerable<string> Codes(this IEnumerable<Currency> currencies) =>
        currencies.Select(currency => new string(currency.Code));
}
