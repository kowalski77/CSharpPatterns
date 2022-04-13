using DesignPatterns.State;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class StateTests
{
    [Fact]
    public void Account_with_balance_higher_than_1000_has_gold_state()
    {
        // Arrange
        var sut = new Account("Mike Meyers");

        // Act
        sut.Deposit(10);
        sut.Deposit(20);
        sut.PayInterest();
        sut.Withdraw(5);
        sut.Deposit(1000);

        // Assert
        sut.Balance.Should().Be(1025);
        sut.State.Should().BeOfType<GoldState>();
    }
}