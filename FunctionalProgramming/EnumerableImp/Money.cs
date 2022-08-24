namespace FunctionalProgramming.EnumerableImp;

public record Money : IComparable<Money>
{
    private readonly decimal amount;

    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, Currency currency)
    {
        return new Money(amount, currency);
    }

    public decimal Amount
    {
        get => amount;
        init => amount = value.NonNegative(nameof(Amount));
    }

    public Currency Currency { get; init; }

    public bool IsZero => Amount == 0;

    public bool CanAdd(Money other) => IsCompatible(other);

    public Money Add(Money other) => this with { Amount = Amount + Compatible(other).Amount };

    public bool CanSubstract(Money other) => IsCompatible(other);

    public Money Substract(Money other) => this with { Amount = Amount - Compatible(other).Amount };

    private Money Compatible(Money other) =>
        IsCompatible(other) ?
        other :
        throw new ArgumentException($"Cannot combine currencies");

    private bool IsCompatible(Money other) => Currency.Equals(other.Currency);

    public int CompareTo(Money? other) => amount.CompareTo(other?.amount);

    public override string ToString() => $"Currency: {Currency} - Amount: {Amount}";
}
