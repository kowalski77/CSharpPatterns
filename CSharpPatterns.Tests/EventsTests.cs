using FluentAssertions;
using Playground;
using Xunit;

namespace CSharpPatterns.Tests;

public class EventsTests
{
    [Fact]
    public void Callback_on_event_provides_reference_to_the_event_context()
    {
        // Arrange
        const int id = 1;
        var result = 0;

        var bar = new Bar();
        bar.BarExecuted += (sender, args) =>
        {
            result = args.Id;
        };

        // Act
        bar.Execute(id);

        // Assert
        result.Should().Be(id);
    }
}
