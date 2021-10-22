using System;
using System.Linq;
using ChainOfResponsibility.Implementation;

namespace ChainOfResponsibility
{
    internal class Program
    {
        private static void Main()
        {
            var handler = new MultipleOfThreeHandler();
            handler
                .Next(new MultipleOfFiveHandler())
                .Next(new NoMultipleHandler());

            var range = Enumerable.Range(1, 10).ToList();
            range.ForEach(number =>
            {
                var result = handler.Run(number);
                Console.WriteLine(result);
            });

            Console.ReadKey();
        }
    }
}