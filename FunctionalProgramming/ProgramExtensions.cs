using System.Diagnostics;
using FunctionalProgramming.Caches;
using FunctionalProgramming.Collections;
using FunctionalProgramming.Models;
using FunctionalProgramming.Pagination;
using FunctionalProgramming.Services;
using FunctionalProgramming.Support;

namespace FunctionalProgramming;

public static class ProgramExtensions
{
    public static void ServiceWithDelay()
    {
        IProductsService productsService = new DelayingProductsService(TimeSpan.FromMilliseconds(100));

        var batchSize = 1000;
        for (var capacity = 0; capacity < 10; capacity++)
        {
            var time = Stopwatch.StartNew();
            foreach (var product in productsService.GetAll().Take(batchSize))
            {
                _ = productsService.Find(product.Id);
            }
            Console.WriteLine($"Cache[{capacity}]: Processed {batchSize} item(s) in {time.Elapsed}");
        }
    }

    public static void CachedService()
    {
        IProductsService delayingProductsService = new DelayingProductsService(TimeSpan.FromMilliseconds(100));
        IProductsService cachingProductService = new CachingProductsService(delayingProductsService, 10);

        var batchSize = 1000;
        for (var capacity = 0; capacity < 10; capacity++)
        {
            var time = Stopwatch.StartNew();
            foreach (var product in cachingProductService.GetAll().Take(batchSize))
            {
                _ = cachingProductService.Find(product.Id);
            }
            Console.WriteLine($"Cache[{capacity}]: Processed {batchSize} item(s) in {time.Elapsed}");
        }
    }

    public static void TransparentCache()
    {
        var codes = Currencies.TestCurrencies.Take(10).RepeatRandomly().Codes().Take(1_000_000);

        List<Currency> currencies = new();

        foreach (var code in codes) currencies.Add(new(code));
        currencies.TrimExcess();
        var nonCachedMemory = GC.GetTotalAllocatedBytes(true);

        var cached = currencies.Cached().ToList();
        var cachedMemory = GC.GetTotalAllocatedBytes(true) - nonCachedMemory;

        GC.KeepAlive(cached);
        GC.KeepAlive(currencies);

        Console.WriteLine($"No caching: {nonCachedMemory:#,##0} bytes");
        Console.WriteLine($"    Cached: {cachedMemory:#,##0} bytes");
    }

    public static void SimpleSortedList()
    {
        _ = ProductSeedData.GetRawProducts.Take(100)
            .ToFullySortedList(Product.CostComparer)
            .GetRange(10, 20);
    }

    public static void Pagination()
    {
        var paginatedProducts = ProductSeedData.GetRawProducts.Take(15).Paginate(Product.CostComparer, 5);
        var page = paginatedProducts[2];
        foreach (var item in page)
        {
            Console.WriteLine(item);
        }
    }
}
