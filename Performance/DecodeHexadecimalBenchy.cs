using BenchmarkDotNet.Attributes;

namespace Performance;

[MemoryDiagnoser]
public class DecodeHexadecimalBenchy
{
    private const string hexadecimalValue = "6AD8694EC8414ABB81487A891C7ADB9DE742BF854F32721B157A9E459D96BE10";

    [Benchmark]
    public byte[] DecodeHexadecimalStandard()
    {
        static int GetHexValue(char v) => v - (v < 58 ? 48 : 55);

        var result = new byte[hexadecimalValue.Length / 2];
        for (var i = 0; i < hexadecimalValue.Length / 2; i++)
        {
            result[i] = (byte)((GetHexValue(hexadecimalValue[i * 2]) << 4) + GetHexValue(hexadecimalValue[(i * 2) + 1]));
        }
        return result;
    }

    [Benchmark]
    public byte[] DecodeHexadecimalFunctional()
    {
        var result = Enumerable.Range(0, hexadecimalValue.Length / 2)
            .Select(x => Convert.ToByte(hexadecimalValue.Substring(x * 2, 2), 16))
            .ToArray();
    
        return result;
    }
}
