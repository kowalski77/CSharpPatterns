using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Options;

namespace OptionsSetup.API.NamedOptions;

public sealed class ConfigureSampleKeyOptions : IConfigureNamedOptions<SampleKeyOptions>
{
    private readonly IConfiguration configuration;
    private readonly IHostEnvironment hostEnvironment;

    public ConfigureSampleKeyOptions(IConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        this.configuration = configuration;
        this.hostEnvironment = hostEnvironment;
    }

    public void Configure(string? name, SampleKeyOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        options.TokenCredential = this.GetTokenCredential();
    }

    public void Configure(SampleKeyOptions options) => this.Configure(Options.DefaultName, options);

    private TokenCredential GetTokenCredential() =>
            this.hostEnvironment.IsDevelopment() ?
                new VisualStudioCredential() :
                new ManagedIdentityCredential();
}