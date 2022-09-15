using BenchmarkDotNet.Attributes;
using FunctionalProgramming.Models;
using FunctionalProgramming.Services;

namespace FunctionalProgramming;

public class Benchmarky
{
    private List<Product> productList = default!;
    private HashSet<Product> productSet = default!;
    private Product targetProduct = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.productList = ProductSeedData.GetRawProducts.Take(10_000).ToList();
        this.productSet = new HashSet<Product>(this.productList);
        this.targetProduct = this.productList[4567];
    }

    [Benchmark]
    public Product ListFindProduct()
    {
        return this.productList.First(x => x.Id == this.targetProduct.Id);
    }

    [Benchmark]
    public Product HashSetFindProduct()
    {
        Product product;
        this.productSet.TryGetValue(this.targetProduct, out product!);

        return product;
    }
}
