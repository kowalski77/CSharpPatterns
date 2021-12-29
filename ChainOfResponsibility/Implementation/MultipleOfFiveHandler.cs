using ChainOfResponsibility.Abstraction;

namespace ChainOfResponsibility.Implementation
{
    public class MultipleOfFiveHandler : HandlerBase<int, string>
    {
        public override string? Run(int request)
        {
            if (request.IsDivisibleBy(5))
            {
                return $"The number: {request} is divisible by 5";
            }

            return base.Run(request); ;
        }
    }
}