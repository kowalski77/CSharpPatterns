using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Performance;

[MemoryDiagnoser]
public class EnumBenchy
{
    [Benchmark]
    public string NativeToString()
    {
        return Status.Running.ToString();
    }

    [Benchmark]
    public string NameOf()
    {
        return nameof(Status.Running);
    }
}

public enum Status
{
    None,
    Idle,
    Running,
    Stopped
}