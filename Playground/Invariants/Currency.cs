namespace Playground.Invariants;

public class Currency
{
    private string code = default!;

    public Currency(string code)
    {
        Code = code;
    }

    public string Code
    {
        get => code;
        set => code = value.NonEmpty(nameof(Code)).ToUpper();
    }
}
