using FunctionalProgramming.Guards;

namespace FunctionalProgramming.FunctionalDecomposition;

public delegate Discount DiscountGenerator();

public class DiscountGeneratorFactory
{
    private readonly IDictionary<bool, DiscountGenerator> generators;

    public DiscountGeneratorFactory(DiscountOptions options) => 
        this.generators = options.NonNull().Discounts.ToDictionary(format => format.Prefered, this.CreateDiscountGenerator);

    private DiscountGenerator CreateDiscountGenerator(DiscountFormat d) => () => new Discount(d.Value);

    public DiscountGenerator GetDiscountGenerator(bool option) =>
        this.generators.TryGetValue(option, out var generator) ?
            generator :
            throw new ArgumentException($"Invalid option {option}", nameof(option));
}
