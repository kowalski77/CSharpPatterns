using FluentAssertions;

namespace CSharpPatterns.Tests.CaseStudies.Median;

public abstract class MedianTests
{
    private static int[][] TestNumbers { get; } =
    {
        new[] { 2, 5, 1, 3, 4 }
    };

    public static IEnumerable<object[]> Data => TestNumbers.Select(args => new object[] { args });

    protected abstract Func<IEnumerable<int>, IMedianTarget<int>> SutFactory { get; }

    [Theory, MemberData(nameof(Data))]
    public void Get_median_return_existing_value(int[] numbers) => numbers.Should().Contain(this.SutFactory(numbers).GetMedian());

    [Theory, MemberData(nameof(Data))]
    public void Get_median_separates_higher_half(int[] numbers) => (numbers.Length / 2).Should().BeLessThanOrEqualTo(numbers.Count(n => n >= this.SutFactory(numbers).GetMedian()));

    [Theory, MemberData(nameof(Data))]
    public void Get_median_separates_lower_half(int[] numbers) => (numbers.Length / 2).Should().BeLessThanOrEqualTo(numbers.Count(n => n <= this.SutFactory(numbers).GetMedian()));
}

public class ListMedianTests : MedianTests
{
    protected override Func<IEnumerable<int>, IMedianTarget<int>> SutFactory => numbers => new ListMedian<int>(numbers);
}
