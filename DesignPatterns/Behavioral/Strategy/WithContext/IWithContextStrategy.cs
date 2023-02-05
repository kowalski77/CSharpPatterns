using DesignPatterns.Behavioral.Strategy.Support;

namespace DesignPatterns.Behavioral.Strategy.WithContext;

public interface IWithContextStrategy
{
    Type Type { get; }

    IMessage Create();
}