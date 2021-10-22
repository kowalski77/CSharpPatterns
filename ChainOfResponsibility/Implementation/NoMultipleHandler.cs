using ChainOfResponsibility.Abstraction;

namespace ChainOfResponsibility.Implementation
{
    public class NoMultipleHandler : HandlerBase<int, string>
    {
        public override string Run(int request)
        {
            return $"The Number: {request} has no defined multiples";
        }
    }
}