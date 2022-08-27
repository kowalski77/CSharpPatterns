namespace FunctionalProgramming.EnumerableImp;

public readonly record struct Currency : IComparable<Currency>
{
    private readonly string code = default!;

    public Currency(string code)
    {
        this.Code = code;
    }

    public Currency() : this(default!)
    {
    }

    public string Code
    {
        get => this.code;
        init => this.code = value.NonEmpty(nameof(this.Code));
    }

    public int CompareTo(Currency other) => this.Code.CompareTo(other.Code);

    public override string ToString() => this.Code;

    public Money Of(decimal amount) => Money.Create(amount, this);
}
