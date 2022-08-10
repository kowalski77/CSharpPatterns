namespace Playground.Endpoints.API.Support;

public static class RequestExtensions
{
    public static IServiceCollection AddRequestsFromAssembly<T>(this IServiceCollection services)
    {
        var concretes = typeof(T).Assembly.GetTypes()
                .Where(p => p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestService<,>)));

        foreach (var concrete in concretes)
        {
            var interfaceType = concrete.GetInterfaces().First();
            services.AddScoped(interfaceType, concrete);
        }

        return services;
    }
}
