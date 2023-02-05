using DesignPatterns.Behavioral.RulesEngine;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class RulesEngineTests
{
    [Theory]
    [InlineData(15, "Is divisible by 3 and 5")]
    [InlineData(3, "Is divisible by 3")]
    [InlineData(5, "Is divisible by 5")]
    [InlineData(7, "")]
    public void Number_handler_returns_results_accordingly_to_the_number(int number, string result)
    {
        // Arrange
        var numberHandler = new NumberHandler(new IHandler<Number>[]
        {
            new MultipleOfThreeAndFiveHandler(), 
            new MultipleOfThreeHandler(), 
            new MultipleOfFiveHandler()
        });

        // Act
        var text = numberHandler.Handle(Number.CreateInstance(number));

        // Assert
        text.Should().Be(result);
    }
}