using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Factory.FactoryMethod;
using Factory.FactoryMethod.Factories;
using Factory.Models;
using Factory.Support;

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