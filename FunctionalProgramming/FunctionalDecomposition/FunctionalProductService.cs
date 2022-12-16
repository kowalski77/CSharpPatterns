using FunctionalProgramming.Constructors.SequenceFactoryMethods;

namespace FunctionalProgramming.FunctionalDecomposition;

// Functional style
public class FunctionalProductService
{
    private readonly CommerceContext context;
    private readonly DiscountGeneratorFactory discountGeneratorFactory;

    public FunctionalProductService(CommerceContext context, DiscountGeneratorFactory discountGeneratorFactory)
    {
        this.context = context;
        this.discountGeneratorFactory = discountGeneratorFactory;
    }

    public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPrefered) =>
        this.context.Products
            .Where(p => p.IsFeatured)
            .WithDiscount(this.GetDiscount(isCustomerPrefered));

    private Discount GetDiscount(bool isCustomerPrefered) => isCustomerPrefered ?
        this.discountGeneratorFactory.Prefered() :
        this.discountGeneratorFactory.NotPrefered();
}
