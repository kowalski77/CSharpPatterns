using DesignPatterns.Strategy.Support;

namespace DesignPatterns.Strategy.WithContext;

public interface IWithContextStrategy
{
    Type Type { get; }

    IMessage Create();
}