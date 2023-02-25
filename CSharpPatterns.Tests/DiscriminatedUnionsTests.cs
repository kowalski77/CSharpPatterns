using FluentAssertions;
using FunctionalProgramming.DiscriminatedUnions;

namespace CSharpPatterns.Tests;

public class DiscriminatedUnionsTests
{
    [Fact]
    public void DiscreteMeasure_is_calculated_accordingly()
    {
        var m = new DiscreteMeasure("cm", 10);
        var (a, b) = m.SplitInHalves();

        a.Should().BeEquivalentTo(new DiscreteMeasure("cm", 5));
        b.Should().BeEquivalentTo(new DiscreteMeasure("cm", 5));
    }

    [Fact]
    public void ContinuousMeasure_is_calculated_accordingly()
    {
        var m = new ContinuousMeasure("cm", 10);
        var (a, b) = m.SplitInHalves();

        a.Should().BeEquivalentTo(new ContinuousMeasure("cm", 5));
        b.Should().BeEquivalentTo(new ContinuousMeasure("cm", 5));
    }
}
