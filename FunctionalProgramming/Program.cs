using System.Diagnostics;
using FunctionalProgramming.Caches;
using FunctionalProgramming.Models;
using FunctionalProgramming.Services;
using FunctionalProgramming.Support;

//TransparentCache();
//ServiceWithDelay();
CachedService();    

Console.ReadKey();

static void ServiceWithDelay()
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
        Console.WriteLine($"Cache[{capacity,2}]: Processed {batchSize} item(s) in {time.Elapsed}");
    }
}

static void CachedService()
{
    IProductsService productsService = new DelayingProductsService(TimeSpan.FromMilliseconds(100));

    var batchSize = 1000;
    for (var capacity = 0; capacity < 10; capacity++)
    {
        IProductsService cached = productsService.Cached(capacity);
        var time = Stopwatch.StartNew();
        foreach (var product in productsService.GetAll().Take(batchSize))
        {
            _ = cached.Find(product.Id);
        }
        Console.WriteLine($"Cache[{capacity,2}]: Processed {batchSize} item(s) in {time.Elapsed}");
    }
}

static void TransparentCache()
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