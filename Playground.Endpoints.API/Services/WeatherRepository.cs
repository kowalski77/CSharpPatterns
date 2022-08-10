namespace Playground.Endpoints.API.Services;

public class WeatherRepository
{
    private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public Task<IReadOnlyList<WeatherForecast>> GetAsync(CancellationToken cancellationToken = default)
    {
        var weatherInfo = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();

        return Task.FromResult<IReadOnlyList<WeatherForecast>>(weatherInfo);
    }
}
