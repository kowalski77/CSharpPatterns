namespace DesignPatterns.Structural.Adapter;

public interface ISpecificAdapter
{
    IEnumerable<string> GetExamples();
}

public class SpecificAdapter : ISpecificAdapter
{
    private readonly IAdaptee adaptee;

    public SpecificAdapter(IAdaptee adaptee)
    {
        this.adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
    }

    public IEnumerable<string> GetExamples()
    {
        foreach (var example in this.adaptee.GetExamples())
            yield return example.Text;
    }
}