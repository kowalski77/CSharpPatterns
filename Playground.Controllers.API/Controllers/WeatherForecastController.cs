using Microsoft.AspNetCore.Mvc;
using Playground.Controllers.API.ActionFilters;
using Playground.Controllers.API.Models;

namespace Playground.Controllers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ContinuationToken]
    public ActionResult<WeatherForecastCollection> Get()
    {
        var weatherForecastCollection = new WeatherForecastCollection(
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList())
        {
            ContinuationToken = Guid.NewGuid().ToString()
        };

        return this.Ok(weatherForecastCollection);
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post([FromBody] WeatherForecast weatherForecast)
    {
        return this.Ok(weatherForecast);
    }
}
