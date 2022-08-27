using System.Collections;

namespace FunctionalProgramming;

public class MoneyBag : IEnumerable<Money>
{
    public MoneyBag(IEnumerable<Money> moneys)
    {
        this.CurrencyToBalance = new();
        foreach (var money in moneys) this.Add(money);
    }

    private SortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public bool IsZero => this.CurrencyToBalance.Count == 0;

    public Money this[Currency currency] => this.CurrencyToBalance[currency];

    public void Add(Money money) => this.Set(this.FindOrZero(money.Currency).Add(money));

    public void Subtract(Money money) => this.Set(this.FindOrZero(money.Currency).Subtract(money));

    public bool CanSubctract(Money money) => this.FindOrZero(money.Currency).CanSubtract(money);

    private IEnumerable<Money> Values => this.CurrencyToBalance.Values;

    public IEnumerator<Money> GetEnumerator() => this.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

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
