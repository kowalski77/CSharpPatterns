using System;
using System.Collections.Generic;

namespace ChainOfResponsibilityAlternative
{
    public class NumberHandler
    {
        private readonly List<IHandler<Number>> handlers;

        public NumberHandler(List<IHandler<Number>> handlers)
        {
            this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        public void Handle(Number number)
        {
            Console.WriteLine($"Number: {number.Value}");

            foreach (var handler in this.handlers)
            {
                handler.Handle(number);
            }
        }
    }
}