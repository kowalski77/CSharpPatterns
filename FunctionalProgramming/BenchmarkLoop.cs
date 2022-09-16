using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using FunctionalProgramming.Models;
using FunctionalProgramming.Services;

namespace FunctionalProgramming;

[MemoryDiagnoser]
public class BenchmarkLoop
{
    private List<Product> productList = default!;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        this.productList = ProductSeedData.GetRawProducts.Take(10_000).ToList();
    }

    [Benchmark]
    public void Foreach()
    {
        foreach (var item in this.productList)
        {
        }
    }

    [Benchmark]
    public void ForeachSpan()
    {
        foreach (var item in CollectionsMarshal.AsSpan(this.productList))
        {
        }
    }
}
