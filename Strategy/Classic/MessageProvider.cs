using System;
using System.Collections.Generic;
using Strategy.Support;

namespace Strategy.Classic
{
    public class MessageProvider
    {
        private readonly Dictionary<Type, IMessageStrategy> strategies;

        public MessageProvider(Dictionary<Type, IMessageStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IMessage Create<T>(string text)
            where T : IMessageStrategy
        {
            if (this.strategies.TryGetValue(typeof(T), out var strategy))
            {
                return strategy.Create(text);
            }

            throw new InvalidOperationException($"No strategy registered for type: {typeof(T)}");
        }
    }
}