using BenchmarkDotNet.Running;
using DataRetrieval.Client;

//await Scroll.RunAsync();

var summary = BenchmarkRunner.Run<FindBenchmark>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Benchmark finished!. Press any key to close");
Console.ResetColor();
Console.ReadKey();