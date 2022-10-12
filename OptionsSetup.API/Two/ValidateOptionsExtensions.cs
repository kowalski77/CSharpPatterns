using Microsoft.Extensions.Options;

namespace OptionsSetup.API.Two;

public static class ValidateOptionsExtensions
{
    public static OptionsBuilder<TOptions> AddWithValidateOptions<TOptions, TValdiator>(this IServiceCollection services, string configurationSection)
        where TOptions : class
        where TValdiator : class, IValidateOptions<TOptions>
    {
        services.AddSingleton<IValidateOptions<TOptions>, TValdiator>();

        return services.AddOptions<TOptions>()
            .BindConfiguration(configurationSection)
            .ValidateOnStart();
    }
}
