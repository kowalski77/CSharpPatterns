using System.Collections;

namespace Playground.Controllers.API.Models;

public class WeatherForecastCollection : IEnumerable<WeatherForecast>, IPageable
{
    private readonly List<WeatherForecast> weatherForecasts;

    public WeatherForecastCollection(List<WeatherForecast> weatherForecasts)
    {
        this.weatherForecasts = weatherForecasts ?? 
            throw new ArgumentNullException(nameof(weatherForecasts));
    }

    public string ContinuationToken { get; set; } = default!;

    public IEnumerator<WeatherForecast> GetEnumerator() => this.weatherForecasts.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}