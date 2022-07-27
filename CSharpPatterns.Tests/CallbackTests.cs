using FluentAssertions;
using Playground;
using Xunit;

namespace CSharpPatterns.Tests;

public class CallbackTests
{
    [Fact]
    public void Callback_on_action_string_provides_reference_to_the_action_context()
    {
        // Arrange
        var result = string.Empty;
        var foo = new Foo();
        foo.SimpleAction = (s) =>
        {
            result = s;
        };

        // Act
        foo.RunSimpleAction();

        // Assert
        result.Should().Be("Hello World!");
    }
}
