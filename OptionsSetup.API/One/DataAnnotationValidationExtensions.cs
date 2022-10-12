using Microsoft.Extensions.Options;

namespace OptionsSetup.API.One;

public static class DataAnnotationValidationExtensions
{
    public static OptionsBuilder<TOptions> AddWithDataAnnotationValidation<TOptions>(this IServiceCollection services, string configurationSection)
        where TOptions : class
    {
        return services.AddOptions<TOptions>()
                .BindConfiguration(configurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }
}
