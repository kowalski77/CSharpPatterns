using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Decomposition;

public delegate Discount DiscountGenerator();

public class DiscountGeneratorFactory
{
    private readonly IDictionary<DiscountType, DiscountGenerator> generators;

    public DiscountGeneratorFactory(DiscountOptions options) =>
        this.generators = options.NonNull().Discounts.ToDictionary(
            format => format.DiscountType,
            this.CreateDiscountGenerator);

    public DiscountGenerator GetDiscountGenerator(DiscountType discountType) =>
        this.generators.TryGetValue(discountType, out var generator) ?
            generator :
            throw new ArgumentException($"Invalid option {discountType}", nameof(discountType));

    private DiscountGenerator CreateDiscountGenerator(DiscountFormat d) => () => new Discount(d.Value);
}
