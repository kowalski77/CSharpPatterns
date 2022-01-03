using Strategy.Support;

namespace Strategy.WithContext;

public class SecondWithContextStrategy : IWithContextStrategy
{
    public Type Type => typeof(Second);

    public IMessage Create()
    {
        return new Second
        {
            Text = "Second message"
        };
    }
}