using DesignPatterns.Behavioral.Strategy.Support;

namespace DesignPatterns.Behavioral.Strategy.Classic;

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