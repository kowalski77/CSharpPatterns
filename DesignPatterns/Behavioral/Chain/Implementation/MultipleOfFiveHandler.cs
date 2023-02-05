using DesignPatterns.Behavioral.Chain.Abstraction;

namespace DesignPatterns.Behavioral.Chain.Implementation
{
    public class MultipleOfFiveHandler : HandlerBase<int, string>
    {
        public override string? Run(int request)
        {
            return request.IsDivisibleBy(5) ?
                $"The number: {request} is divisible by 5" :
                base.Run(request);
        }
    }
}