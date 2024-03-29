﻿using FunctionalProgramming.Constructors.SequenceFactoryMethods;
using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Decomposition;

public static class ProductDiscountExtensions
{
    public static IEnumerable<Product> WithDiscount(this IEnumerable<Product> products, Discount discount) =>
        products.Select(p => p.ApplyDiscount(discount));

    private static Product ApplyDiscount(this Product product, Discount discount) =>
        new(product.NonNull().Name, product.Price * (1 - discount.Value));
}
