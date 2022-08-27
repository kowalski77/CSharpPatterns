using FunctionalProgramming.Support;

namespace FunctionalProgramming.Models;

public record Money : IComparable<Money>
{
    private readonly decimal amount;

    private Money(decimal amount, Currency currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }

    public static Money Create(decimal amount, Currency currency) => new(amount, currency);

    public decimal Amount
    {
        get => this.amount;
        init => this.amount = value.NonNegative(nameof(this.Amount));
    }

    public Currency Currency { get; init; }

    public bool IsZero => this.Amount == 0;

    //public ImmutableMoneyBag Add(Money other) => ImmutableMoneyBag.Empty.Add(this).Add(other);

    public bool CanAdd(Money other) => this.IsCompatible(other);

    public Money Add(Money other) => this with { Amount = this.Amount + this.Compatible(other).Amount };

    public bool CanSubtract(Money other) => this.IsCompatible(other);

    public Money Subtract(Money other) => this with { Amount = this.Amount - this.Compatible(other).Amount };

    private Money Compatible(Money other) =>
        this.IsCompatible(other) ?
        other :
        throw new ArgumentException($"Cannot combine currencies");

    private bool IsCompatible(Money other) => this.Currency.Equals(other.Currency);

    public int CompareTo(Money? other) => this.amount.CompareTo(other?.amount);

    public override string ToString() => $"Currency: {this.Currency} - Amount: {this.Amount}";
}
