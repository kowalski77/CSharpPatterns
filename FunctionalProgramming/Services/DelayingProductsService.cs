using System.Diagnostics;
using FunctionalProgramming.Models;

namespace FunctionalProgramming.Services;

public class DelayingProductsService : IProductsService
{
    private readonly TimeSpan searchDelay;
    private readonly Dictionary<Guid, Product> IdToProduct;

    public DelayingProductsService(TimeSpan searchDelay)
    {
        this.searchDelay = searchDelay;
        this.IdToProduct = ProductSeedData.GetRawProducts.Take(10).ToDictionary(p => p.Id);
    }

    public Product Find(Guid id) => Delay(this.IdToProduct[id], this.searchDelay);

    private static T Delay<T>(T item, TimeSpan delay)
    {
        var currentTime = Stopwatch.StartNew();
        while (currentTime.Elapsed < delay) _ = Thread.Yield();
        
        return item;
    }

    public IEnumerable<Product> GetAll() => this.IdToProduct.Values;
}
