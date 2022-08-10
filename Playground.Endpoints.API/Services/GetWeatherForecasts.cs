using Playground.Endpoints.API.Endpoints.Weathers;
using Playground.Endpoints.API.Support;

namespace Playground.Endpoints.API.Services;

public record GetWeatherForecastsRequest() : IRequest<IReadOnlyList<WeatherListResponse>>;

public class GetWeatherForecastsHandler : IRequestService<GetWeatherForecastsRequest, IReadOnlyList<WeatherListResponse>>
{
    private readonly WeatherRepository repository;

    public GetWeatherForecastsHandler(WeatherRepository repository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IReadOnlyList<WeatherListResponse>> ExecuteAsync(GetWeatherForecastsRequest command, CancellationToken cancellationToken = default)
    {
        var weatherInfo = await repository.GetAsync(cancellationToken);
        
        return weatherInfo
            .Select(x => new WeatherListResponse(x.Date, x.TemperatureC, x.Summary))
            .ToList();
    }
}
