namespace RulesEngine;

public class MultipleOfFiveHandler : IHandler<Number>
{
    public string Handle(Number request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.IsDivisibleBy(5))
        {
            return "Is divisible by 5";
        }

        return string.Empty;
    }
}