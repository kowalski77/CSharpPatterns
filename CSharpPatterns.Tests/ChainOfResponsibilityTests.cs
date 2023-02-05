using DesignPatterns.Behavioral.Chain.Implementation;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class ChainOfResponsibilityTests
{
    [Theory]
    [InlineData(15, "The number: 15 is divisible by 3 and 5")]
    [InlineData(3, "The number: 3 is divisible by 3")]
    [InlineData(5, "The number: 5 is divisible by 5")]
    [InlineData(7, "The Number: 7 has no defined multiples")]
    public void Number_handler_returns_results_accordingly_to_the_number(int number, string result)
    {
        // Arrange
        var handler = new MultipleOfThreeAndFiveHandler();
        handler.SetNext(new MultipleOfFiveHandler())
            .SetNext(new MultipleOfThreeHandler())
            .SetNext(new NoMultipleHandler());

        // Act
        var text = handler.Run(number);

        // Assert
        text.Should().Be(result);
    }
}