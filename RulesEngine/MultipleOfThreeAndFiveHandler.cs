namespace RulesEngine;

public class MultipleOfThreeAndFiveHandler : IHandler<Number>
{
    public string Handle(Number request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.IsDivisibleBy(3) && request.IsDivisibleBy(5))
        {
            return "Is divisible by 3 and 5";
        }

        return string.Empty;
    }
}