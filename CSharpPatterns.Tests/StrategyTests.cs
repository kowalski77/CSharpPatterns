using System;
using System.Collections.Generic;
using FluentAssertions;
using Strategy.Classic;
using Strategy.Support;
using Strategy.WithContext;
using Xunit;

namespace CSharpPatterns.Tests;

public class StrategyTests
{
    [Fact]
    public void Strategy_pattern_returns_object_accordingly()
    {
        // Arrange
        Dictionary<Type, IMessageStrategy> strategies = new()
        {
            { typeof(FirstMessage), new FirstMessage() },
            { typeof(SecondMessage), new SecondMessage() }
        };
        var sut = new MessageProvider(strategies);

        // Act
        var message = sut.Create<FirstMessage>("message");

        // Assert
        message.Should().BeOfType<First>();
    }

    [Fact]
    public void Strategy_pattern_with_context_returns_object_accordingly()
    {
        // Arrange
        IWithContextStrategy[] strategies =
        {
            new FirstWithContextStrategy(), 
            new SecondWithContextStrategy()
        };
        var sut = new Context(strategies);

        // Act
        var message = sut.Create<First>();

        // Assert
        message.Should().BeOfType<First>();
    }
}