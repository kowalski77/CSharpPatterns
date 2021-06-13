using ChainOfResponsibility.Abstraction;

namespace ChainOfResponsibility.Implementation
{
    public class MultipleOfThree : HandlerBase<int, string>
    {
        public override string Run(int request)
        {
            return request.IsDivisibleBy(3) ? 
                $"The number: {request} is divisible by 3" : 
                base.Run(request);
        }
    }
}