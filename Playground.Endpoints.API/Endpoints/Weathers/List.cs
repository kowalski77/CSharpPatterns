using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Playground.Endpoints.API.Services;
using Playground.Endpoints.API.Support;

namespace Playground.Endpoints.API.Endpoints.Weathers;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IReadOnlyList<WeatherListResponse>>
{
    private readonly IRequestService<GetWeatherForecastsRequest, IReadOnlyList<WeatherListResponse>> requestService;

    public List(IRequestService<GetWeatherForecastsRequest, IReadOnlyList<WeatherListResponse>> requestService)
    {
        this.requestService = requestService;
    }

    [HttpGet("[namespace]")]
    public override async Task<ActionResult<IReadOnlyList<WeatherListResponse>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var weatherInfo = await this.requestService.ExecuteAsync(new GetWeatherForecastsRequest(), cancellationToken);

        return this.Ok(weatherInfo);
    }
}
