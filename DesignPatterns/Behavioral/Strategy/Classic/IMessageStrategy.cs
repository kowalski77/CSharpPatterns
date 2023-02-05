using DesignPatterns.Behavioral.Strategy.Support;

namespace DesignPatterns.Behavioral.Strategy.Classic;

public interface IMessageStrategy
{
    IMessage Create(string text);
}