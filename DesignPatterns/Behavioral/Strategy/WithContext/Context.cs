using DesignPatterns.Strategy.Support;

namespace DesignPatterns.Strategy.WithContext;

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