namespace DesignPatterns.Behavioral.Composite;

public interface ITextProcessor
{
    IEnumerable<string> Execute(IEnumerable<string> text);
}
