using System;

namespace ChainOfResponsibilityAlternative
{
    public class MultipleOfFiveHandler : IHandler<Number>
    {
        public void Handle(Number request)
        {
            if (request.IsDivisibleBy(5))
            {
                // DO another thing with the class Number
                Console.WriteLine("Is divisible by 5");
            }
        }
    }
}