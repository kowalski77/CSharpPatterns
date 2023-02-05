namespace DesignPatterns.Behavioral.Composite;

public sealed class LinesJoiner : ITextProcessor
{
    public IEnumerable<string> Execute(IEnumerable<string> text) =>
        text.SelectMany(line => line.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
}
