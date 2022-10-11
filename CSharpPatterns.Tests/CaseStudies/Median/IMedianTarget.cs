namespace CSharpPatterns.Tests.CaseStudies.Median;

public interface IMedianTarget<T> where T : IComparable<T>
{
    T GetMedian();
}

public class ListMedian<T> : IMedianTarget<T> where T : IComparable<T>
{
    public ListMedian(IEnumerable<T> content)
    {
        this.Content = content.ToList();
        this.Sorted = new Lazy<List<T>>(() =>
        {
            this.Content.Sort();
            return this.Content;
        });
    }

    private List<T> Content { get; }

    private Lazy<List<T>> Sorted { get; }

    public T GetMedian() => this.Sorted.Value[this.Content.Count / 2];
}
