using System;
using FluentAssertions;
using SharedKernel;
using Xunit;

namespace CSharpPatterns.Tests;

public class GuardsTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Guard_throws_ArgumentOutOfRangeException_when_invalid_input_parameter(int number)
    {
        // Act
        var action = () => Guards.ThrowIfLessOrEqualThan(number, 0);

        // Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Guard_does_not_throws_ArgumentOutOfRangeException_with_valid_input_parameter()
    {
        // Arrange
        const int number = 1;

        // Act
        var action = () => Guards.ThrowIfLessOrEqualThan(number, 0);

        // Assert
        action.Should().NotThrow<ArgumentOutOfRangeException>();
        action.Invoke().Should().Be(number);
    }
}