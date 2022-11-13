using FluentValidation;
using Playground.Controllers.API.Models;

namespace Playground.Controllers.API.Controllers;

public class WeatherValidator : AbstractValidator<WeatherForecast>
{
    public WeatherValidator()
    {
        this.RuleFor(x => x.TemperatureC).GreaterThan(0);
    }
}
