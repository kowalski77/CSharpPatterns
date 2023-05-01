using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearerCertAuth.API.Settings;

public sealed class CustomJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>, IDisposable
{
    private readonly RSA rsa;

    public CustomJwtBearerOptions()
    {
        this.rsa = RSA.Create();
        this.rsa.ImportFromPem(File.ReadAllText("public-key.pem"));
    }

    public void Configure(string? name, JwtBearerOptions options) => this.Configure(options);

    public void Configure(JwtBearerOptions options)
    {
        IdentityModelEventSource.ShowPII = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new RsaSecurityKey(this.rsa),
            ValidateIssuer = true,
            ValidIssuer = "cert-auth.com",
            ValidateAudience = true,
            ValidAudience = "JwtBearerCertAuth.API",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine(context.Exception.Message);
                return Task.CompletedTask;
            }
        };
    }

    public void Dispose() => this.rsa.Dispose();
}

