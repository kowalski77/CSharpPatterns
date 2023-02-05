using DesignPatterns.Behavioral.Composite;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class CompositeTests
{
    [Fact]
    public void Lines_are_joined_and_trimmed()
    {
        ITextProcessor pipeline = new Pipeline(
            new LinesJoiner(),
            new LinesTrimmer());

        var text = new[] { "  Hello, World!  ", " How are you? " };
        var result = pipeline.Execute(text);

        result.Should().BeEquivalentTo(new[] { "Hello, World!", "How are you?" });
    }
}
