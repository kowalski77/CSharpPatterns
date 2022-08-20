using AsyncPatterns.AsyncInitialization;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class AsyncInitializationTests
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
}
