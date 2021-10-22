using System;

namespace ChainOfResponsibilityAlternative
{
    public class MultipleOfThreeHandler : IHandler<Number>
    {
        public void Handle(Number request)
        {
            if (request.IsDivisibleBy(3))
            {
                // DO another thing with the class Number
                Console.WriteLine("Is divisible by 3");
            }
        }
    }
}