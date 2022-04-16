using FluentAssertions;
using SharedKernel.Functional;
using Xunit;

namespace CSharpPatterns.Tests;

public class MaybeTests
{
    [Fact]
    public void Match_unfolds_the_value()
    {
        // Arrange
        const int id = 1;
        const string name = "first product";
        var maybe = (Maybe<Product>)new Product
        {
            Id = id,
            Name = name
        };

        // Act
        var dto = maybe.Match(item => new ProductDto
        {
            Id = item.Id,
            Name = item.Name
        }, () => new ProductDto());

        // Assert
        dto.Id.Should().Be(id);
        dto.Name.Should().Be(name);
    }

    [Fact]
    public void Match_returns_none_value_when_null_value()
    {
        // Arrange
        const int id = 2;
        const string name = "none product";

        Maybe<Product> maybe = (Product)null!;

        // Act
        var dto = maybe.Match(item => new ProductDto
        {
            Id = item.Id,
            Name = item.Name
        }, () => new ProductDto
        {
            Id = id,
            Name = name
        });

        // Assert
        dto.Id.Should().Be(id);
        dto.Name.Should().Be(name);
    }

    [Fact]
    public void Map_does_mapping()
    {
        // Arrange
        const int id = 1;
        const string name = "first product";
        Maybe<Product> maybeProduct = new Product
        {
            Id = id,
            Name = name
        };

        // Act
        var maybeProductDto = maybeProduct.Map(item => new ProductDto
        {
            Id = item.Id,
            Name = item.Name
        });

        // Assert
        maybeProductDto.Should().BeOfType<Maybe<ProductDto>>();
        var value = maybeProductDto.ValueOrThrow(string.Empty);
        value.Id.Should().Be(id);
        value.Name.Should().Be(name);
    }
}

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }
}

public class ProductDto
{
    public int Id { get; set; }

    public string? Name { get; set; }
}