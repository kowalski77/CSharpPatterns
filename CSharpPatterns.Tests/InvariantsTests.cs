using FluentAssertions;
using Playground.Invariants;

namespace CSharpPatterns.Tests;

public class InvariantsTests
{
    [Fact]
    public void Instantiate_class_breaking_invariant_throws_an_exception()
    {
        // Act
        var action = () => new Currency(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Update_property_breaking_invariant_throws_an_exception()
    {
        // Arrange
        var currency = new Currency("EUR");

        // Act
        var action = () => currency.Code = string.Empty;

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
