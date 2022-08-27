using System.Collections;
using System.Collections.Immutable;

namespace FunctionalProgramming.EnumerableImp;

// only use immutable collections when it's a requirement
public class ImmutableMoneyBag : IEnumerable<Money>
{
    // --> coding pattern for immutable collections
    private ImmutableMoneyBag(ImmutableSortedDictionary<Currency, Money> balances)
    {
        this.CurrencyToBalance = balances;
    }

    // --> coding pattern for immutable collections
    public static ImmutableMoneyBag Empty => new(ImmutableSortedDictionary<Currency, Money>.Empty);

    private ImmutableSortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public ImmutableMoneyBag Add(Money other) =>
    this.With(this.FindOrZero(other.Currency).Add(other));

    public ImmutableMoneyBag Subtract(Money other) =>
        this.With(this.FindOrZero(other.Currency).Subtract(other));

    public bool CanSubtract(Money other) =>
        this.FindOrZero(other.Currency).CanSubtract(other);

    // --> coding pattern for immutable collections
    private ImmutableMoneyBag With(Money balance) => new(this.Set(balance));

    private ImmutableSortedDictionary<Currency, Money> Set(Money balance) =>
        balance.IsZero ? this.CurrencyToBalance.Remove(balance.Currency)
        : this.CurrencyToBalance.SetItem(balance.Currency, balance);

    private Money FindOrZero(Currency currency) =>
        this.CurrencyToBalance.TryGetValue(currency, out var known) ? known
        : currency.Of(0);

    public Money this[Currency currency] => this.CurrencyToBalance[currency];

    public IEnumerator<Money> GetEnumerator() => this.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private IEnumerable<Money> Values => this.CurrencyToBalance.Values;
}
