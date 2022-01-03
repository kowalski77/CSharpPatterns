using Strategy.Support;

namespace Strategy.WithContext;

public interface IWithContextStrategy
{
    Type Type { get; }

    IMessage Create();
}