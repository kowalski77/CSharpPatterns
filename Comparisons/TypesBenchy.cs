using BenchmarkDotNet.Attributes;

namespace Comparisons;

[MemoryDiagnoser]
public class TypesBenchy
{
    [Benchmark]
    public Coordinates CreateCoordinatesClass()
    {
        return new Coordinates(10, 10);
    }

    [Benchmark]
    public CoordinatesRecord CreateCoordinatesRecord()
    {
        return new CoordinatesRecord(10, 10);
    }

    [Benchmark]
    public CoordinatesStruct CreateCoordinatesStruct()
    {
        return new CoordinatesStruct(10, 10);
    }

    [Benchmark]
    public CoordinatesRecordStruct CreateCoordinatesRecordStruct()
    {
        return new CoordinatesRecordStruct(10, 10);
    }
}