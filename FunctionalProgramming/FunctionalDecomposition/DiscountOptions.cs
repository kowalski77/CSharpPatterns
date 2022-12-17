namespace FunctionalProgramming.FunctionalDecomposition;

public sealed class DiscountOptions
{
    public const string CustomerPrefered = "Prefered";
    public const string CustomerNotPrefered = "NotPrefered";

    public IReadOnlyCollection<DiscountFormat> Discounts { get; init; } = new List<DiscountFormat>
    {
        new DiscountFormat
        {
            Prefered = true,
            Name = CustomerPrefered,
            Value = 0.1m
        },
        new DiscountFormat
        {
            Prefered = false,
            Name = CustomerNotPrefered,
            Value = 0.0m
        }
    };
}

public sealed class DiscountFormat
{
    public required bool Prefered { get; init; }

    public required string Name { get; init; }

    public required decimal Value { get; init; }
}
