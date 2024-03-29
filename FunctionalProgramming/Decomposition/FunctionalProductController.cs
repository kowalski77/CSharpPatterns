﻿using FunctionalProgramming.Constructors.SequenceFactoryMethods;

namespace FunctionalProgramming.Decomposition;

// Functional style
public class FunctionalProductController
{
    private readonly CommerceContext context;
    private readonly DiscountGeneratorFactory discountGeneratorFactory;

    public FunctionalProductController(
        CommerceContext context,
        DiscountGeneratorFactory discountGeneratorFactory)
    {
        this.context = context;
        this.discountGeneratorFactory = discountGeneratorFactory;
    }

    public IEnumerable<Product> GetFeaturedProducts(DiscountType discountType) =>
        this.context.Products
            .Where(p => p.IsFeatured)
            .WithDiscount(this.discountGeneratorFactory.GetDiscountGenerator(discountType)());
}
