namespace DesignPatterns.RulesEngine;

public class NumberHandler
{
    private readonly IEnumerable<IHandler<Number>> handlers;

    public NumberHandler(IEnumerable<IHandler<Number>> handlers)
    {
        this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    }

    public string Handle(Number number)
    {
        ArgumentNullException.ThrowIfNull(number);

        var result = string.Empty;
        foreach (var handler in this.handlers)
        {
            result = handler.Handle(number);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
        }

        return result;
    }
}