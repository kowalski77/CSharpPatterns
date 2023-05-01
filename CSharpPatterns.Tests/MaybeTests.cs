using System;
using FluentAssertions;
using FunctionalProgramming.Optional;
using Xunit;

namespace CSharpPatterns.Tests;

public class MaybeTests
{
    [Fact]
    public void Constructor_defaults()
    {
        // Arrange
        var maybe = new Maybe<Product>();

        // Act
        var getValue = () => maybe.Value;

        // Assert
        getValue.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void None_defaults()
    {
        // Arrange
        Maybe<Product> maybe = Maybe.None;

        // Act
        var getValue = () => maybe.Value;

        // Assert
        getValue.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Value_return_value_when_set()
    {
        // Arrange
        var product = new Product();
        Maybe<Product> maybeProduct = product;

        // Act
        var value = maybeProduct.Value;

        // Assert
        maybeProduct.HasValue.Should().BeTrue();
        value.Should().Be(product);
    }

    [Fact]
    public void Match_unfolds_the_value()
    {
        // Arrange
        var product = new Product();
        var maybe = (Maybe<Product>)product;

        // Act
        var dto = maybe.Match(item => new ProductDto
        {
            Id = item.Id,
            Name = item.Name
        }, () => new ProductDto());

        // Assert
        dto.Id.Should().Be(product.Id);
        dto.Name.Should().Be(product.Name);
    }

    [Fact]
    public void Match_returns_other_value_when_null_value()
    {
        // Arrange
        const int id = 2;
        const string name = "none product";

        Maybe<Product> maybe = null!;

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
        var product = new Product();
        var maybeProduct = (Maybe<Product>)product;

        static ProductDto ToProductDto(Product item) => new()
        {
            Id = item.Id, Name = item.Name
        };

        // Act
        var maybeProductDto = maybeProduct.Map(ToProductDto);

        // Assert
        maybeProductDto.Should().BeOfType<Maybe<ProductDto>>();
        var value = maybeProductDto.Value;
        value.Id.Should().Be(product.Id);
        value.Name.Should().Be(product.Name);
    }

    [Fact]
    public void Bind_wraps_to_another_maybe()
    {
        // Arrange
        var product = new Product();
        var maybeProduct = (Maybe<Product>)product;

        static Maybe<ProductDto> ToProductDto(Product item) => new ProductDto
        {
            Id = item.Id, Name = item.Name
        };

        // Act
        var maybeProductDto = maybeProduct.Bind(ToProductDto);

        // Assert
        maybeProductDto.Should().BeOfType<Maybe<ProductDto>>();
        var value = maybeProductDto.Value;
        value.Id.Should().Be(product.Id);
        value.Name.Should().Be(product.Name);
    }
}

public class Product
{
    public int Id { get; set; } = 1;

    public string? Name { get; set; } = "Product";
}

public class ProductDto
{
    public int Id { get; set; }

    public string? Name { get; set; }
}