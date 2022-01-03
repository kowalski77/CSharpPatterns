using Strategy.Support;

namespace Strategy.WithContext;

public class FirstWithContextStrategy : IWithContextStrategy
{
    public Type Type => typeof(First);

    public IMessage Create()
    {
        return new First
        {
            Text = "First message"
        };
    }
}