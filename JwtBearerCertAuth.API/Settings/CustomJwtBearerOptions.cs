using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearerCertAuth.API.Settings;

public sealed class CustomJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>, IDisposable
{
    private readonly RSA rsa;
    private readonly ILogger<CustomJwtBearerOptions> logger;

    public CustomJwtBearerOptions(ILogger<CustomJwtBearerOptions> logger)
    {
        this.rsa = RSA.Create();
        this.rsa.ImportFromPem(File.ReadAllText("public-key.pem"));
        this.logger = logger;
    }

    public void Configure(string? name, JwtBearerOptions options) => this.Configure(options);

    public void Configure(JwtBearerOptions options)
    {
        //IdentityModelEventSource.ShowPII = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new RsaSecurityKey(this.rsa),
            ValidateIssuer = true,
            ValidIssuer = "cert-auth.com2",
            ValidateAudience = true,
            ValidAudience = "JwtBearerCertAuth.API",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                this.logger.LogError(context.Exception.Message);
                return Task.CompletedTask;
            }
        };
    }

    public void Dispose() => this.rsa.Dispose();
}

