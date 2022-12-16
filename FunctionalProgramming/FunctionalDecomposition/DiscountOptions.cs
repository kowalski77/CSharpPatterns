namespace FunctionalProgramming.FunctionalDecomposition;

public sealed class DiscountOptions
{
    public const string CustomerPrefered = "Prefered";
    public const string CustomerNotPrefered = "NotPrefered";

    public IReadOnlyCollection<DiscountFormat> Discounts { get; init; } = new List<DiscountFormat>
    {
        new DiscountFormat
        {
            Name = CustomerPrefered,
            Value = 0.1m
        },
        new DiscountFormat
        {
            Name = CustomerNotPrefered,
            Value = 0.0m
        }
    };
}

public sealed class DiscountFormat
{
    public string Name { get; init; } = string.Empty;

    public decimal Value { get; init; }
}
