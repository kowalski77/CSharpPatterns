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
        var result = MemoizedCache.Create(currencyCodes, size);

        // Assert
        result.Count().Should().Be(size);
        result.Distinct().Count().Should().Be(currencyTypes);
    }
}
