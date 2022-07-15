using DesignPatterns.Strategy.Support;

namespace DesignPatterns.Strategy.Classic;

public interface IMessageStrategy
{
    IMessage Create(string text);
}