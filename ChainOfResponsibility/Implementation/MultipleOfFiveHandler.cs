using ChainOfResponsibility.Abstraction;

namespace ChainOfResponsibility.Implementation
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