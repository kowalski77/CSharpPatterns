namespace Playground.Endpoints.API.Support;

public static class ServiceRequestExtensions
{
    public static IServiceCollection AddServiceRequestsFromAssembly<T>(this IServiceCollection services)
    {
        var concretes = typeof(T).Assembly.GetTypes()
                .Where(p => p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IServiceRequest<,>)));

        foreach (var concrete in concretes)
        {
            var interfaceType = concrete.GetInterfaces().First();
            services.AddScoped(interfaceType, concrete);
        }

        return services;
    }
}
