using System;
using BenchmarkDotNet.Running;

namespace Factory
{
    internal static class Program
    {
        private static void Main()
        {
            var summary = BenchmarkRunner.Run<FactoryBenchmark>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Benchmark finished!. Press any key to close");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}