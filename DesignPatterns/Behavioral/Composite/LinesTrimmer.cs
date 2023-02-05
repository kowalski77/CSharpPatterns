namespace DesignPatterns.Behavioral.Composite;

public sealed class LinesTrimmer : ITextProcessor
{
    public IEnumerable<string> Execute(IEnumerable<string> text) => text.Select(line => line.Trim());
}
