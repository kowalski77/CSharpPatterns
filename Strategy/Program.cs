using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Strategy.Classic;
using Strategy.Support;
using Strategy.WithContext;

namespace Strategy
{
    internal static class Program
    {
        private static IServiceProvider serviceProvider;

        private static void Main()
        {
            ConfigureServices();

            // classic
            var messageProvider = serviceProvider.GetRequiredService<MessageProvider>();
            var message = messageProvider.Create<SecondMessage>("Hi");
            Console.WriteLine(message.Text);

            // with context
            var context = serviceProvider.GetRequiredService<Context>();
            var firstMessage = context.Create<First>();
            Console.WriteLine(firstMessage.Text);

            Console.ReadKey();

            DisposeServices();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            var messageStrategies = new Dictionary<Type, IMessageStrategy>
            {
                {typeof(FirstMessage), new FirstMessage()}, 
                {typeof(SecondMessage), new SecondMessage()}
            };
            services.AddTransient(_ => new MessageProvider(messageStrategies));

            services.AddTransient(_ => new Context(new IWithContextStrategy[]
            {
                new FirstWithContextStrategy(),
                new SecondWithContextStrategy()
            }));

            serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            switch (serviceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}