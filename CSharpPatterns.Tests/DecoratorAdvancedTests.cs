using DesignPatterns.Structural.DecoratorAdvanced;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class DecoratorAdvancedTests
{
    [Fact]
    public void Reverse_comparer_reverse_the_initial_list()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var comparer = Comparer<int>.Default;
        
        // Act
        list.Sort(comparer.Reverse());

        // Assert
        list.Should().BeInDescendingOrder();
    }

    [Fact]
    public void Two_chained_calls_to_reverse_comparer_reverse_the_initial_list()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var comparer = Comparer<int>.Default;

        // Act
        list.Sort(comparer.Reverse().Reverse());

        // Assert
        list.Should().BeInAscendingOrder();
    }

    [Fact]
    public void Three_chained_calls_to_reverse_comparer_reverse_the_initial_list()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var comparer = Comparer<int>.Default;

        // Act
        list.Sort(comparer.Reverse().Reverse().Reverse());

        // Assert
        list.Should().BeInDescendingOrder();
    }
}
