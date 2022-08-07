using Microsoft.EntityFrameworkCore;

namespace Playground.Minimal.API.Products;

public class ProductsService
{
    private readonly ProductsContext context;

    public ProductsService(ProductsContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyList<Product>> GetAllProductsAsync() => await this.context.Products.ToListAsync();

    public async Task<Product> AddAsync(Product product)
    {
        var newlyProduct = this.context.Add(product).Entity;
        await this.context.SaveChangesAsync();

        return newlyProduct;
    }
}
