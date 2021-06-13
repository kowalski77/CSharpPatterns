using System;
using System.Linq;
using ChainOfResponsibility.Implementation;

namespace ChainOfResponsibility
{
    internal class Program
    {
        private static void Main()
        {
            var handler = new MultipleOfThree();
            handler
                .Next(new MultipleOfFive())
                .Next(new NoMultiple());

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