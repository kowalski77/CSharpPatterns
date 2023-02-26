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

// Explanation: The DiscountGeneratorFactory class is a factory that creates a DiscountGenerator delegate for each DiscountType.
// This technique is called the Factory Method pattern and is a creational pattern. It's useful when you don't have the cases on hand,
// but you know how to create them. In this case, the DiscountGeneratorFactory class knows how to create a DiscountGenerator delegate.
