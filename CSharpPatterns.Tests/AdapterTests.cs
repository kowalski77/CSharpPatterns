using DesignPatterns.Structural.Adapter;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class AdapterTests
{
    [Fact]
    public void Adapter_returns_the_adapted_text_from_the_source()
    {
        // Arrange
        var sut = new Client(new SpecificAdapter(new Adaptee()));

        // Act
        var result = sut.GetExamplesText();

        // Assert
        result.Should().Contain("1").And.Contain("2");
    }
}