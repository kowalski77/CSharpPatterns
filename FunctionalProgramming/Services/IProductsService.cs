using FunctionalProgramming.Models;

namespace FunctionalProgramming.Services;

public interface IProductsService
{
    IEnumerable<Product> GetAll();

    Product Find(Guid id);
}
