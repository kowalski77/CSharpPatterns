using FluentAssertions;
using FunctionalProgramming;

namespace CSharpPatterns.Tests;

public class MemoizedCacheTests
{
    [Fact]
    public void MemoizedCache_creates_currencies_accordingly()
    {
        // Arrange
        const int size = 1000;
        const int currencyTypes = 10;

        var currencyCodes = Currencies.TestCurrencies.Take(currencyTypes).RepeatRandomly().Codes();

        // Act
        var currenciescollection = MemoizedCache.Create(currencyCodes, size);

        // Assert
        currenciescollection.Count.Should().Be(size);
        currenciescollection.Distinct().Count().Should().Be(currencyTypes);
    }
}
