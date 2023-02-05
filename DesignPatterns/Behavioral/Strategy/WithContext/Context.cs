using DesignPatterns.Behavioral.Strategy.Support;

namespace DesignPatterns.Behavioral.Strategy.WithContext;

public class Context
{
    private readonly IWithContextStrategy[] strategies;

    public Context(IWithContextStrategy[] strategies)
    {
        this.strategies = strategies;
    }

    public IMessage Create<T>()
        where T : IMessage
    {
        var strategy = this.strategies.Single(x => x.Type == typeof(T));

        return strategy.Create();
    }
}