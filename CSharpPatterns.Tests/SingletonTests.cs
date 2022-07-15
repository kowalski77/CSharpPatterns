using DesignPatterns.Singleton;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class SingletonTests
{
    [Fact]
    public void Call_two_times_singleton_instance_returns_the_same_instance()
    {
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        logger1.Should().Be(logger2);
    }
}
