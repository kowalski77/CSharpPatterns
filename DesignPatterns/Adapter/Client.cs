namespace DesignPatterns.Adapter;

public class Client
{
    private readonly ISpecificAdapter specificAdapter;

    public Client(ISpecificAdapter specificAdapter)
    {
        this.specificAdapter = specificAdapter;
    }

    public string GetExamplesText()
    {
        var examples = this.specificAdapter.GetExamples();
        return string.Join(", ", examples);
    }
}