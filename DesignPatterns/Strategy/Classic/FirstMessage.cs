using DesignPatterns.Strategy.Support;

namespace DesignPatterns.Strategy.Classic;

public class FirstMessage : IMessageStrategy
{
    public IMessage Create(string text)
    {
        return new First
        {
            Text = text
        };
    }
}