using DesignPatterns.Behavioral.Chain.Functional;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class MultipleChainNodeTests
{
    [Fact]
    public void Multiple_chain_node_returns_results_accordingly_to_the_number()
    {
        Divisible number2 = new(2);
        Divisible number5 = new(5);

        IDivisible divisible = number2.Then(number5);

        divisible.Of(2).Should().Be("2");
    }

    [Fact]
    public void Multiple_chain_node_returns_results_accordingly_to_the_number_2()
    {
        Divisible number2 = new(2);
        Divisible number5 = new(5);

        IDivisible divisible = number2.Then(number5);

        divisible.Of(5).Should().Be("5");
    }

    [Fact]
    public void Multiple_chain_node_returns_results_accordingly_to_the_number_3()
    {
        Divisible number2 = new(2);
        Divisible number5 = new(5);
        Divisible number10 = new(10);

        IDivisible divisible = number2.Then(number5).Then(number10);

        divisible.Of(10).Should().Be("10");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void Multiple_chain_node_returns_null_when_the_number_is_not_divisible_by_the_divisor(int number)
    {
        Divisible number2 = new(2);
        Divisible number5 = new(5);

        IDivisible divisible = number2.Then(number5);

        divisible.Of(number).Should().BeNull();
    }
}
