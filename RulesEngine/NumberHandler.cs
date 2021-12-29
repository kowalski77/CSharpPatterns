namespace RulesEngine;

public class NumberHandler
{
    private readonly IEnumerable<IHandler<Number>> handlers;

    public NumberHandler(IEnumerable<IHandler<Number>> handlers)
    {
        this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    }

    public void Handle(Number number)
    {
        ArgumentNullException.ThrowIfNull(number);

        Console.WriteLine($"Number: {number.Value}");

        foreach (var handler in this.handlers)
        {
            handler.Handle(number);
        }
    }
}