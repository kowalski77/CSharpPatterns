using FunctionalProgramming.Caches;
using FunctionalProgramming.Models;
using FunctionalProgramming.Support;

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
