using FluentValidation;
using Microsoft.Extensions.Options;

namespace OptionsSetup.API.Three;

public static class FluentValidationOptionsExtensions
{
    public static OptionsBuilder<TOptions> AddWithFluentValidation<TOptions, TValidator>(this IServiceCollection services, string configurationSection)
        where TOptions : class
        where TValidator : class, IValidator<TOptions>
    {
        services.AddScoped<IValidator<TOptions>, TValidator>();

        return services.AddOptions<TOptions>()
            .BindConfiguration(configurationSection)
            .ValidateFluentValidation()
            .ValidateOnStart();
    }

    private static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) 
        where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(provider =>
            new FluentValidationOptions<TOptions>(optionsBuilder.Name, provider));

        return optionsBuilder;
    }
}