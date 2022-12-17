using FunctionalProgramming.Guards;

namespace FunctionalProgramming.FunctionalDecomposition;

public delegate Discount DiscountGenerator();

public class DiscountGeneratorFactory
{
    private readonly IDictionary<string, DiscountGenerator> generators;

    public DiscountGeneratorFactory(DiscountOptions options) => 
        this.generators = options.NonNull().Discounts.ToDictionary(d => d.Name, this.CreateDiscountGenerator);

    public DiscountGenerator Prefered => this.GetDiscountGenerator(DiscountOptions.CustomerPrefered);

    public DiscountGenerator NotPrefered => this.GetDiscountGenerator(DiscountOptions.CustomerNotPrefered);

    private DiscountGenerator CreateDiscountGenerator(DiscountFormat d) => () => new Discount(d.Value);

    private DiscountGenerator GetDiscountGenerator(string option) =>
        this.generators.TryGetValue(option, out var generator) ?
            generator :
            throw new ArgumentException($"Invalid option {option}", nameof(option));
}
