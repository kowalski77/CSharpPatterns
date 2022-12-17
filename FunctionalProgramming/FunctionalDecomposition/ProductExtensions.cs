using FunctionalProgramming.Constructors.SequenceFactoryMethods;
using FunctionalProgramming.Guards;

namespace FunctionalProgramming.FunctionalDecomposition;

public static class ProductExtensions
{
    public static IEnumerable<Product> WithDiscount(
        this IEnumerable<Product> products,
        DiscountGeneratorFactory discountGeneratorFactory,
        bool isCustomerPrefered) =>
            products.WithDiscount(GetDiscountGenerator(discountGeneratorFactory.NonNull(), isCustomerPrefered)());

    public static IEnumerable<Product> WithDiscount(this IEnumerable<Product> products, Discount discount) =>
        products.Select(p => p.ApplyDiscount(discount));

    private static Product ApplyDiscount(this Product product, Discount discount) =>
        new(product.NonNull().Name, product.Price * (1 - discount.Value));

    private static DiscountGenerator GetDiscountGenerator(DiscountGeneratorFactory discountGeneratorFactory, bool isCustomerPrefered) =>
        isCustomerPrefered ?
            discountGeneratorFactory.Prefered :
            discountGeneratorFactory.NotPrefered;
}
