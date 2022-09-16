using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using FunctionalProgramming.Models;
using FunctionalProgramming.Services;

namespace FunctionalProgramming;

public class Benchmarky
{
    private static readonly Random rng = new(80085);

    private List<Product> productList = default!;
    private HashSet<Product> productSet = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.productList = ProductSeedData.GetRawProducts.Take(10_000).ToList();
        this.productSet = new HashSet<Product>(this.productList);
    }

    [Benchmark]
    public Product ListFindProduct()
    {
        var targetProduct = this.productList[rng.Next(0, 9_999)];

        return this.productList.First(x => x.Id == targetProduct.Id);
    }

    [Benchmark]
    public Product HashSetFindProduct()
    {
        var targetProduct = this.productList[rng.Next(0, 9_999)];

        Product product;
        this.productSet.TryGetValue(targetProduct, out product!);

        return product;
    }
}
