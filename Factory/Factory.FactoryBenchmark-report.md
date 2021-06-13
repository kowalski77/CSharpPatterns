``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.18363.1556 (1909/November2019Update/19H2)
Intel Xeon CPU E3-1505M v6 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


```
|                        Method |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------ |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
|   StrategyExamProviderFactory |    12.75 ns |  0.283 ns |  0.291 ns |    1 | 0.0057 |     - |     - |      24 B |
|     SimpleExamProviderFactory |    19.20 ns |  0.422 ns |  1.111 ns |    2 | 0.0172 |     - |     - |      72 B |
| ReflectionExamProviderFactory | 2,242.21 ns | 28.100 ns | 23.465 ns |    3 | 0.2785 |     - |     - |   1,168 B |
