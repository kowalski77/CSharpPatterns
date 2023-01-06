namespace FunctionalProgramming.Decomposition;

public sealed class DiscountOptions
{
    public IReadOnlyCollection<DiscountFormat> Discounts { get; init; } = new List<DiscountFormat>
    {
        new DiscountFormat
        {
            DiscountType = DiscountType.Prefered,
            Value = 0.1m
        },
        new DiscountFormat
        {
            DiscountType = DiscountType.None,
            Value = 0.0m
        }
    };
}

public sealed class DiscountFormat
{
    public required DiscountType DiscountType { get; init; }

    public required decimal Value { get; init; }
}
