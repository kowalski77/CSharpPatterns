using Strategy.Support;

namespace Strategy.Classic
{
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
}