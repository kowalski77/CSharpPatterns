using Microsoft.Extensions.Options;
using OptionsSetup.API.One;
using OptionsSetup.API.Three;
using OptionsSetup.API.Two;

var builder = WebApplication.CreateBuilder(args);

// option old --> Validation startup filter + data annotations
//builder.Services.ConfigureOptions<FooOptionsSetup>();
//or
//builder.Services.Configure<FooOptions>(builder.Configuration.GetSection(nameof(FooOptions)));
//builder.Services.AddTransient<IStartupFilter, SettingValidationStartupFilter>();
// builder.Services.AddSingleton<IValidatable>(resolver =>
//resolver.GetRequiredService<IOptions<FooOptions>>().Value);

// option one
//builder.Services.AddOptions<FooOptions>()
//    .Bind(builder.Configuration.GetSection(nameof(FooOptions)))
//    .ValidateDataAnnotations()
//    .ValidateOnStart();

// option one with extension 
builder.Services.AddWithDataAnnotationValidation<FooOptions>(nameof(FooOptions));

// option Two (validation when resolving!)
builder.Services.AddWithValidateOptions<BarOptions, BarOptionsValidation>(nameof(BarOptions));

// option three (with fluent validation!)
builder.Services.AddWithFluentValidation<Settings, SettingsValidator>(nameof(Settings));

// (optional, if you want to avoid IOptions when resolving)
//builder.Services.AddSingleton(resolver =>
//    resolver.GetRequiredService<IOptions<FooOptions>>().Value);

var app = builder.Build();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (IOptionsMonitor<FooOptions> fooOptions, IOptions<BarOptions> barOptions) =>
{
    var foo = fooOptions.CurrentValue;
    var bar = barOptions.Value;

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);
}