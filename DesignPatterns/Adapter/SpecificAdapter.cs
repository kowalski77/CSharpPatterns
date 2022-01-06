namespace DesignPatterns.Adapter;

public interface ISpecificAdapter
{
    IEnumerable<Example> GetExamples();
}

public class SpecificAdapter : ISpecificAdapter
{
    private readonly IAdaptee adaptee;

    public SpecificAdapter(IAdaptee adaptee)
    {
        this.adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
    }

    public IEnumerable<Example> GetExamples()
    {
        return this.adaptee.GetExamples();
    }
}