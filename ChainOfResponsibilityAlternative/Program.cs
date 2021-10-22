using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibilityAlternative
{
    internal static class Program
    {
        private static void Main()
        {
            var handler = new NumberHandler(new List<IHandler<Number>>
            {
                new MultipleOfThreeHandler(), new MultipleOfFiveHandler(), new NoMultipleHandler()
            });

            var range = Enumerable.Range(1, 10).ToList();
            range.ForEach(n =>
            {
                handler.Handle(Number.CreateInstance(n));
            });
        }
    }
}