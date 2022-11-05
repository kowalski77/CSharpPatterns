using AutoFixture;
using FluentAssertions;
using FunctionalProgramming.Constructors.SequenceFactoryMethods;
using FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;
using SharedKernel.Results;
using ProductSeq = FunctionalProgramming.Constructors.SequenceFactoryMethods.Product;
using ProductSeq2 = FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult.Product2;

namespace CSharpPatterns.Tests;

public class SequenceFactoryMethodsTests
{
    private readonly IFixture fixture = new Fixture();

    [Fact]
    public void Purchase_is_done_properly()
    {
        // Arrange
        var productsCollection = this.fixture.Create<List<ProductSeq>>();
        var vendor = new Vendor(this.fixture.Create<string>(), productsCollection);
        var customer = new Customer(this.fixture.Create<string>(), 1000);
        Order order = vendor.PlaceOrder(productsCollection[0]);

        // Act
        OrderPurchase sut = customer.Purchase(order);

        // Assert
        sut.Customer.Should().Be(customer);
        sut.Order.Should().Be(order);
    }

    [Fact]
    public void Purchase_cannot_be_done_when_customer_has_insufficient_credit()
    {
        // Arrange
        var productsCollection = this.fixture.Create<List<ProductSeq>>();
        var vendor = new Vendor(this.fixture.Create<string>(), productsCollection);
        var customer = new Customer(this.fixture.Create<string>(), 0);
        Order order = vendor.PlaceOrder(productsCollection[0]);

        // Act
        Action sut = () => customer.Purchase(order);

        // Assert
        sut.Should().Throw<ArgumentException>();
    }


    [Fact]
    public void Purchase_is_done_properly_with_results()
    {
        // Arrange
        var productsCollection = this.fixture.Create<List<ProductSeq2>>();
        var vendor = new Vendor2(this.fixture.Create<string>(), productsCollection);
        var customer = new Customer2(this.fixture.Create<string>(), 1000);

        // Act
        Result<OrderPurchase2> result = vendor
            .PlaceOrder(productsCollection[0])
            .OnSuccess(order => customer.Purchase(order));

        // Assert
        result.Value.Customer.Should().Be(customer);
        result.Value.Order.Should().NotBeNull();
    }

    [Fact]
    public void Purchase_cannot_be_done_when_customer_has_insufficient_credit_with_results()
    {
        // Arrange
        var productsCollection = this.fixture.Create<List<ProductSeq2>>();
        var vendor = new Vendor2(this.fixture.Create<string>(), productsCollection);
        var customer = new Customer2(this.fixture.Create<string>(), 0);

        // Act
        Result<OrderPurchase2> result = vendor
            .PlaceOrder(productsCollection[0])
            .OnSuccess(order => customer.Purchase(order));

        // Assert
        result.Error.Should().NotBeNull();
        result.Error!.Code.Should().Be("insufficient.cretit");
    }
}
