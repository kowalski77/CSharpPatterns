using BenchmarkDotNet.Running;
using FunctionalProgramming;
using FunctionalProgramming.Caches;
using FunctionalProgramming.Models;
using FunctionalProgramming.Services;
using FunctionalProgramming.Support;

//TransparentCache();
//ServiceWithDelay();
//CachedService();    
//SimpleSortedList
//Pagination();

//const int count = 100;
//var currencyCodes = Currencies.TestCurrencies.Take(10).RepeatRandomly().Codes().Take(count).ToList();
//var hashSetCacheCurrencies = HashSetCache.Create(currencyCodes, count);
//var simpleCacheCurrencies = SimpleCache.Create(currencyCodes, count);

//var productList = ProductSeedData.GetRawProducts.Take(10_000).ToList();
//var productsHashSet = new HashSet<Product>(productList);
//var productId = productList[4567].Id;

//var productFromList = productList.First(x => x.Id == productId);
//var productFromHashSet = productsHashSet.First(x => x.Id == productId);

//Console.ReadKey();

BenchmarkRunner.Run<BenchmarkLoop>();
