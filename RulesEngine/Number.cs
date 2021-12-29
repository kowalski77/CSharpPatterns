using SharedKernel;

namespace RulesEngine;

public class Number
{
    private Number(int value)
    {
        this.Value = Guards.ThrowIfLessOrEqualThan(value, 0);
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