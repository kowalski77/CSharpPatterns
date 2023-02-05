using DesignPatterns.Behavioral.Chain.Abstraction;

namespace DesignPatterns.Behavioral.Chain.Implementation;

public class MultipleOfThreeAndFiveHandler : HandlerBase<int, string>
{
    public override string? Run(int request)
    {
        return request.IsDivisibleBy(3) && request.IsDivisibleBy(5) ?
            $"The number: {request} is divisible by 3 and 5" :
            base.Run(request);
    }
}