using System.Text;

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
        var sb = new StringBuilder();
        foreach (var example in this.specificAdapter.GetExamples())
        {
            sb.AppendLine(example.Text);
        }

        return sb.ToString();
    } 
}