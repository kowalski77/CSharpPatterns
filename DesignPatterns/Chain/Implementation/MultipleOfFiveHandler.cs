using DesignPatterns.Chain.Abstraction;

namespace DesignPatterns.Chain.Implementation
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