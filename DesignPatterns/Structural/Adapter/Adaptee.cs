namespace DesignPatterns.Structural.Adapter;

public interface IAdaptee
{
    IEnumerable<Example> GetExamples();
}

public class Adaptee : IAdaptee
{
    public IEnumerable<Example> GetExamples()
    {
        return new[]
        {
            new Example
            {
                Id = Guid.NewGuid(),
                Text = "Example 1"
            },
            new Example
            {
                Id = Guid.NewGuid(),
                Text = "Example 2"
            }
        };
    }
}