using ChainOfResponsibility.Abstraction;

namespace ChainOfResponsibility.Implementation;

public class MultipleOfThreeAndFiveHandler : HandlerBase<int, string>
{
    public override string? Run(int request)
    {
        if (request.IsDivisibleBy(3) && request.IsDivisibleBy(5))
        {
            return $"The number: {request} is divisible by 3 and 5";
        }

        return base.Run(request);
    }
}