namespace FunctionalProgramming;

public readonly record struct Currency : IComparable<Currency>
{
    private readonly string code = default!;

    public Currency(string code)
    {
        Code = code;
    }

    public Currency() : this(default!)
    {
    }

    public string Code
    {
        get => code;
        init => code = value.NonEmpty(nameof(Code));
    }

    public int CompareTo(Currency other) => Code.CompareTo(other.Code);

    public override string ToString() => Code;

    public Money Of(decimal amount) => Money.Create(amount, this);
}
