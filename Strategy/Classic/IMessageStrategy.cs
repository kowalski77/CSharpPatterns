using Strategy.Support;

namespace Strategy.Classic;

public interface IMessageStrategy
{
    IMessage Create(string text);
}