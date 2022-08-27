using FluentAssertions;
using FunctionalProgramming.Dictionaries;
using FunctionalProgramming.Models;

namespace CSharpPatterns.Tests;

public class SortedDictionaryTests
{
    [Fact]
    public void Sorted_dictionary_orders_money_by_currencies()
    {
        // Arrange
        var moneys = new Money[] { Currencies.Yen.Of(20), Currencies.Euro.Of(10), Currencies.Dolar.Of(5) };
        var bag = moneys.ToMoneyBag();

        // Act
        var result = bag.ToList();

        // Assert
        var expected = new[] { Currencies.Dolar.Of(5), Currencies.Euro.Of(10), Currencies.Yen.Of(20) };
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Sorted_dictionary_adds_money_to_currency()
    {
        // Arrange
        var moneys = new Money[] { Currencies.Yen.Of(20), Currencies.Euro.Of(10), Currencies.Dolar.Of(5) };
        var bag = moneys.ToMoneyBag();

        // Act
        bag.Add(Currencies.Dolar.Of(10));
        var result = bag.ToList();

        // Assert
        var expected = new[] { Currencies.Dolar.Of(15), Currencies.Euro.Of(10), Currencies.Yen.Of(20) };
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Sorted_dictionary_substract_money_to_currency()
    {
        // Arrange
        var moneys = new Money[] { Currencies.Yen.Of(20), Currencies.Euro.Of(10), Currencies.Dolar.Of(10) };
        var bag = moneys.ToMoneyBag();

        // Act
        bag.Subtract(Currencies.Dolar.Of(10));
        var result = bag.ToList();

        // Assert
        var expected = new[] { Currencies.Euro.Of(10), Currencies.Yen.Of(20) };
        result.Should().BeEquivalentTo(expected);
    }
}
