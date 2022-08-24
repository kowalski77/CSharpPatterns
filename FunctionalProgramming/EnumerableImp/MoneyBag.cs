using System.Collections;

namespace FunctionalProgramming.EnumerableImp;

public class MoneyBag : IEnumerable<Money>
{
    public MoneyBag(IEnumerable<Money> moneys)
    {
        CurrencyToBalance = new();
        foreach (var money in moneys) Add(money);
    }

    private SortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public bool IsZero => CurrencyToBalance.Count == 0;

    public Money this[Currency currency] => CurrencyToBalance[currency];

    public void Add(Money money) => Set(FindOrZero(money.Currency).Add(money));

    public void Subtract(Money money) => Set(FindOrZero(money.Currency).Substract(money));

    private IEnumerable<Money> Values => CurrencyToBalance.Values;

    public IEnumerator<Money> GetEnumerator() => Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Set(Money money)
    {
        if (money.IsZero)
            this.CurrencyToBalance.Remove(money.Currency);
        else
            this.CurrencyToBalance[money.Currency] = money;
    }

    private Money FindOrZero(Currency currency) =>
        this.CurrencyToBalance.TryGetValue(currency, out var money) ?
        money :
        currency.Of(0);
}
