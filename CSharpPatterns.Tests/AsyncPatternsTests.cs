using AsyncPatterns.AsyncInitialization;
using AsyncPatterns.AsyncLazy;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class AsyncPatternsTests
{
    [Fact]
    public async Task AsyncInitialization_returns_instance_initialized()
    {
        // Arrange
        var asyncInitialization = new AsyncInitialization();
        var someService = await asyncInitialization.Initialization;

        // Act
        var result = someService.DoStuff();

        // Assert
        result.Should().Be("Stuff done!");
    }

    [Fact]
    public async Task AsyncLazy_returns_instance_initialized()
    {
        // Arrange
        var someClass = new SomeClass();

        // Act
        var result = await someClass.UseSomeServiceAsync();

        // Assert
        result.Should().Be("Stuff done!");
    }
}
