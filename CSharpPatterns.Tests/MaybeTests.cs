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
    public void Map_wraps_to_another_maybe()
    {
        // Arrange
        const int id = 1;
        const string name = "first product";
        Maybe<Product> maybeProduct = new Product
        {
            Id = id,
            Name = name
        };

        static ProductDto ToProductDto(Product item) => new()
        {
            Id = item.Id, Name = item.Name
        };

        // Act
        var maybeProductDto = maybeProduct.Map(ToProductDto);

        // Assert
        maybeProductDto.Should().BeOfType<Maybe<ProductDto>>();
        var value = maybeProductDto.ValueOrThrow(string.Empty);
        value.Id.Should().Be(id);
        value.Name.Should().Be(name);
    }

    [Fact]
    public void Bind_wraps_to_another_maybe()
    {
        // Arrange
        const int id = 1;
        const string name = "first product";
        Maybe<Product> maybeProduct = new Product
        {
            Id = id,
            Name = name
        };

        static Maybe<ProductDto> ToProductDto(Product item) => new ProductDto
        {
            Id = item.Id, Name = item.Name
        };

        // Act
        var maybeProductDto = maybeProduct.Bind(ToProductDto);

        // Assert
        maybeProductDto.Should().BeOfType<Maybe<ProductDto>>();
        var value = maybeProductDto.ValueOrThrow(string.Empty);
        value.Id.Should().Be(id);
        value.Name.Should().Be(name);
    }

    [Fact]
    public void TryGetValue_returns_value()
    {
        // Arrange
        var product = new Product
        {
            Id = 1, Name = "product"
        };
        Maybe<Product> maybeProduct = product;

        // Act
        var maybeValue = maybeProduct.TryGetValue(out var value);

        // Assert
        maybeValue.Should().BeTrue();
        value.Should().Be(product);
    }

    [Fact]
    public void TryGetValue_returns_false_when_no_value()
    {
        // Arrange
        Maybe<Product> maybeProduct = (Product)null!;

        // Act
        var maybeValue = maybeProduct.TryGetValue(out var value);

        // Assert
        maybeValue.Should().BeFalse();
        value.Should().BeNull();
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