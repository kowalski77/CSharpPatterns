using Microsoft.Extensions.Options;

namespace OptionsSetup.API.One;

public class FooOptionsSetup : IConfigureOptions<FooOptions>
{
    private readonly IConfiguration configuration;

    public FooOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(FooOptions options)
    {
        this.configuration.GetSection(nameof(FooOptions)).Bind(options);
    }
}
