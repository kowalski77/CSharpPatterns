using Comparisons;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class ValueObjectTests
{
    [Fact]
    public void Same_values_are_equal()
    {
        var id = Guid.NewGuid();

        OrderId orderId = new(id);
        OrderId orderId1 = new(id);

        orderId.Equals(orderId1).Should().BeTrue();
    }

    [Fact]
    public void Different_values_are_not_equal()
    {
        OrderId orderId = new(Guid.NewGuid());
        OrderId orderId1 = new(Guid.NewGuid());

        orderId.Equals(orderId1).Should().BeFalse();
    }

    [Fact]
    public void Different_types_are_not_equal()
    {
        var id = Guid.NewGuid();

        OrderId orderId = new(id);
        UserId userId = new(id);

        orderId.Equals(userId).Should().BeFalse();
    }

    [Fact]
    public void Operators_works_correctly()
    {
        var id = Guid.NewGuid();
        OrderId orderId = new(id);
        OrderId orderId1 = new(id);

        (orderId == orderId1).Should().BeTrue();    
        (orderId != orderId1).Should().BeFalse();
    }
}

file class OrderId : ValueObject2
{
    public Guid Id { get; }

    public OrderId(Guid id)
    {
        this.Id = id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Id;
    }
}

file class UserId : ValueObject2
{
    public Guid Id { get; }

    public UserId(Guid id)
    {
        this.Id = id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Id;
    }
}