using Microsoft.EntityFrameworkCore;

namespace Playground.Minimal.API.Products;

public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = default!;
}
