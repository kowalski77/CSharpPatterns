namespace DesignPatterns.Behavioral.RulesEngine;

public class MultipleOfThreeHandler : IHandler<Number>
{
    public string Handle(Number request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.IsDivisibleBy(3))
            return "Is divisible by 3";

        return string.Empty;
    }
}