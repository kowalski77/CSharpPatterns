using FunctionalProgramming.Models;

namespace FunctionalProgramming.Services;

public interface IProductsService
{
    IEnumerable<Product> GetAll();

    Product Find(Guid id);

    public IProductsService Cached(int capacity) =>
        this is CachingProductsService caching && caching.Capacity >= capacity ?
        this :
        new CachingProductsService(this, capacity);
}
