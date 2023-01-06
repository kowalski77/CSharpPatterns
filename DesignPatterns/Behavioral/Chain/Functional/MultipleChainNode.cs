using System.Globalization;

namespace DesignPatterns.Behavioral.Chain.Functional;

public record Divisible(int Number) : IDivisible
{
    public string? Of(int number) => this.Number % number == 0 ? number.ToString(CultureInfo.InvariantCulture) : null;
}

public interface IDivisible
{
    string? Of(int number);
}

public class MultipleChainNode : IDivisible
{
    private IDivisible First { get; }

    private IDivisible Next { get; }

    public MultipleChainNode(IDivisible first, IDivisible next) => (this.First, this.Next) = (first, next);

    public string? Of(int number) => this.First.Of(number) is not null ? 
        number.ToString(CultureInfo.InvariantCulture) : 
        this.Next.Of(number);
}

public static class MultipleChainNodeExtensions
{
    public static IDivisible Then(this IDivisible first, IDivisible next) => new MultipleChainNode(first, next);
}

