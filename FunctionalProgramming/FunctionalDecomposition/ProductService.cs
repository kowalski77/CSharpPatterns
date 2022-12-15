using FunctionalProgramming.Constructors.SequenceFactoryMethods;

namespace FunctionalProgramming.FunctionalDecomposition;

// NOTE: this is not correct
public class ProductService
{
    private readonly CommerceContext context;

    public ProductService(CommerceContext context)
    {
        this.context = context;
    }

    public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPrefered)
    {
        var discount = isCustomerPrefered ? 0.1m : 0.0m;

        var featuredProducts = this.context.Products.Where(p => p.IsFeatured).ToList();

        return featuredProducts.Select(p => new Product(p.Name, p.Price * (1 - discount)));
    }
}
