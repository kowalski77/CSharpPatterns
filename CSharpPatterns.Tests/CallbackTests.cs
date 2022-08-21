using FluentAssertions;
using Playground.Callbacks;

namespace CSharpPatterns.Tests;

public class CallbackTests
{
    [Fact]
    public void Callback_on_action_string_provides_reference_to_the_action_context()
    {
        // Arrange
        var result = string.Empty;
        var foo = new Foo
        {
            SimpleAction = (s) =>
        {
            result = s;
        }
        };

        // Act
        foo.RunSimpleAction();

        // Assert
        result.Should().Be("Hello World!");
    }
}
