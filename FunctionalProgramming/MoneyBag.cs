using System.Collections;

namespace FunctionalProgramming;

public class MoneyBag : IEnumerable<Money>
{
    public MoneyBag(IEnumerable<Money> moneys)
    {
        CurrencyToBalance = new();
        foreach (Money money in moneys) Add(money);
    }

    private SortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public bool IsZero => CurrencyToBalance.Count == 0;

    public Money this[Currency currency] => CurrencyToBalance[currency];

    public void Add(Money money) => Set(FindOrZero(money.Currency).Add(money));

    public void Subtract(Money money) => Set(FindOrZero(money.Currency).Substract(money));

    private IEnumerable<Money> Values => CurrencyToBalance.Values;

    public IEnumerator<Money> GetEnumerator() => Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Set(Money balance)
    {
        if (CurrencyToBalance.TryGetValue(balance.Currency, out var _))
            CurrencyToBalance[balance.Currency] = balance;
        else
            CurrencyToBalance.Add(balance.Currency, balance);
    }

    private Money FindOrZero(Currency currency) =>
        CurrencyToBalance.TryGetValue(currency, out var money) ?
        money :
        currency.Of(0);
}
