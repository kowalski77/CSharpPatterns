using DesignPatterns.Behavioral.Strategy.Support;

namespace DesignPatterns.Behavioral.Strategy.Classic;

public class SecondMessage : IMessageStrategy
{
    public IMessage Create(string text)
    {
        return new Second
        {
            Text = text
        };
    }
}