using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddCookie("local")
    .AddCookie("ext-oauth-cookie")
    // this saves the auth token into the cookie in a safe manner
    .AddOAuth("ext-oauth-provider", o =>
    {
        o.SignInScheme = "ext-oauth-cookie";

        o.ClientId = "id";
        o.ClientSecret = "secret";

        o.AuthorizationEndpoint = "https://oauth.mocklab.io/oauth/authorize";
        o.TokenEndpoint = "https://oauth.mocklab.io/oauth/token";
        o.UserInformationEndpoint = "https://oauth.mocklab.io/userinfo";

        o.CallbackPath = "/signin-oauth";

        o.Scope.Add("profile");
        o.SaveTokens = true;
    });

builder.Services.AddAuthorization(b =>
{
    b.AddPolicy("user", p =>
    {
        p.AddAuthenticationSchemes("local")
            .RequireAuthenticatedUser();
    });
    b.AddPolicy("fullaccess", p =>
    {
        p.AddAuthenticationSchemes("ext-oauth-provider")
            .RequireAuthenticatedUser();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
    .RequireAuthorization("fullaccess")
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/login-local", async (ctx) =>
{
    List<Claim> claims = new() { new Claim("usr", "christian") };
    ClaimsIdentity identity = new(claims, "local");
    ClaimsPrincipal user = new(identity);

    await ctx.SignInAsync("local", user);
});

app.MapGet("/login-ext", async (ctx) => await ctx.ChallengeAsync("ext-oauth-provider", new AuthenticationProperties
{
    RedirectUri = "/weatherforecast"
}))
    .RequireAuthorization("user");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
