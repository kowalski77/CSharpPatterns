using DesignPatterns.Behavioral.Chain.Abstraction;

namespace DesignPatterns.Behavioral.Chain.Implementation
{
    public class NoMultipleHandler : HandlerBase<int, string>
    {
        public override string Run(int request)
        {
            return $"The Number: {request} has no defined multiples";
        }
    }
}