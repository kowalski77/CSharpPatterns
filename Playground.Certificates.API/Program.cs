using Microsoft.AspNetCore.Server.Kestrel.Core;
using Playground.Certificates.API.Support;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KestrelServerOptions>(options =>
{
    var hostConfig = builder.Configuration.GetSection(nameof(HostConfig)).Get<HostConfig>();

    options.ListenAnyIP(5001, listenOpt =>
    {
        listenOpt.UseHttps(
          hostConfig.CertificateFileLocation,
          hostConfig.CertificatePassword);
    });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ICertificateValidationService, SampleCertificateValidationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
