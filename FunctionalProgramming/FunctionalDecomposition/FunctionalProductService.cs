using FunctionalProgramming.Constructors.SequenceFactoryMethods;
using FunctionalProgramming.Guards;

namespace FunctionalProgramming.FunctionalDecomposition;

// Functional style
public class FunctionalProductService
{
    private readonly CommerceContext context;

    public FunctionalProductService(CommerceContext context)
    {
        this.context = context;
    }

    public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPrefered) =>
        this.context.Products
            .Where(p => p.IsFeatured)
            .WithDiscount(GetDiscount(isCustomerPrefered));

    private static decimal GetDiscount(bool isCustomerPrefered) => isCustomerPrefered ? 0.1m : 0.0m;
}

public static class ProductExtensions
{
    public static IEnumerable<Product> WithDiscount(this IEnumerable<Product> products, decimal discount) =>
        products.Select(p => p.ApplyDiscount(discount));

    private static Product ApplyDiscount(this Product product, decimal discount) =>
        new(product.NonNull().Name, product.Price * (1 - discount));
}
