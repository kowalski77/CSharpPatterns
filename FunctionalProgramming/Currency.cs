namespace FunctionalProgramming;

public readonly record struct Currency : IComparable<Currency>
{
    private readonly string code = default!;

    public Currency(string code)
    {
        this.Code = code;
    }

    public string Code
    {
        get => this.code;
        init => this.code = value.NonEmpty(nameof(Code)).ToUpper();
    }

    public int CompareTo(Currency other) => this.code.CompareTo(other.code);

    public override string ToString() => this.Code;

    //public Money Of(decimal amount, int precision) => new(amount, this, precision);
}