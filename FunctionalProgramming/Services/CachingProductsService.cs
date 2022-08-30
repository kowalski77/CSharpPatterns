using FunctionalProgramming.Caches;
using FunctionalProgramming.Models;

namespace FunctionalProgramming.Services;

public class CachingProductsService : IProductsService
{
    private readonly IProductsService productsService;
    
    public CachingProductsService(IProductsService productsService, int capacity)
    {
        this.productsService = productsService;
        this.Cache = new(capacity, this.productsService.Find);
    }

    private LruCache<Guid, Product> Cache { get; }

    public int Capacity => this.Cache.Capacity;

    public Product Find(Guid id) => this.Cache.Read(id);

    public IEnumerable<Product> GetAll() => this.productsService.GetAll();
}
