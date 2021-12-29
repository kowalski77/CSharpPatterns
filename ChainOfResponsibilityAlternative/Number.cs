namespace ChainOfResponsibilityAlternative;

public class Number
{
    private Number(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        this.Value = value;
    }

    public int Value { get; }

    public static Number CreateInstance(int value)
    {
        return new Number(value);
    }

    public bool IsDivisibleBy(int value)
    {
        return this.Value % value == 0;
    }
}