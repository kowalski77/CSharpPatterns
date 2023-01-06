using FluentAssertions;
using FunctionalProgramming.Decomposition;

namespace CSharpPatterns.Tests;

public class FunctionalDecompositionTests
{
    [Fact]
    public void Discount_is_applied_to_featured_products_when_is_customer_prefered()
    {
        // Arrange
        var context = new CommerceContext();
        var discountGeneratorFactory = new DiscountGeneratorFactory(new DiscountOptions());
        var productService = new FunctionalProductController(context, discountGeneratorFactory);

        // Act
        var featuredProducts = productService.GetFeaturedProducts(DiscountType.Prefered);

        // Assert
        var prices = context.Products.Where(x => x.IsFeatured).Select(p => p.Price).ToList();
        var featuredPrices = featuredProducts.Select(p => p.Price).ToList();
        featuredPrices.Should().BeEquivalentTo(prices.Select(p => p * 0.9m));
    }

    [Fact]
    public void Discount_is_not_applied_to_featured_products_when_is_customer_not_prefered()
    {
        // Arrange
        var context = new CommerceContext();
        var discountGeneratorFactory = new DiscountGeneratorFactory(new DiscountOptions());
        var productService = new FunctionalProductController(context ,discountGeneratorFactory);

        // Act
        var featuredProducts = productService.GetFeaturedProducts(DiscountType.None);

        // Assert
        var prices = context.Products.Where(x => x.IsFeatured).Select(p => p.Price).ToList();
        var featuredPrices = featuredProducts.Select(p => p.Price).ToList();
        featuredPrices.Should().BeEquivalentTo(prices);
    }
}
