using FunctionalProgramming.Models;
using FunctionalProgramming.Support;

namespace FunctionalProgramming.Services;

public static class ProductSeedData
{
    private static IEnumerable<(string name, decimal rate)> TestProductContent => new[]
    {
        ("Product1", 85), ("Product3", 100), ("Product2", 61), ("Product4", 124),
        ("Product5", 95), ("Product6", 72), ("Product7", 45), ("Product8", 97), ("Product9", 59),
        ("Product10", 71), ("Product11", 55), ("Product12", 98), ("Product13", 64),
        ("Product14", 5), ("Product15", 89), ("Product16", 44), ("Product17", 68m)
    };

    private static IEnumerable<Product> TestData =>
        TestProductContent.Zip(Guids.TestData, (worker, guid) =>
        new Product(guid, worker.name, Currencies.Euro.Of(worker.rate)));

    public static IEnumerable<Product> GetRawProducts
    {
        get
        {
            while (true)
                foreach (var product in TestData)
                    yield return product;
        }
    }

    private static IEnumerable<TimeSpan> WorkTimes =>
        Timers.GetRandomTimeSpans(TimeSpan.FromMinutes(30), TimeSpan.FromHours(4));
}
