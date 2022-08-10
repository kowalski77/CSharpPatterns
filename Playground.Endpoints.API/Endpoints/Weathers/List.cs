using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Playground.Endpoints.API.Services;
using Playground.Endpoints.API.Support;

namespace Playground.Endpoints.API.Endpoints.Weathers;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IReadOnlyList<WeatherListResponse>>
{
    private readonly IServiceRequest<GetWeatherForecastsRequest, IReadOnlyList<WeatherListResponse>> serviceRequest;

    public List(IServiceRequest<GetWeatherForecastsRequest, IReadOnlyList<WeatherListResponse>> serviceRequest)
    {
        this.serviceRequest = serviceRequest;
    }

    [HttpGet("[namespace]")]
    public override async Task<ActionResult<IReadOnlyList<WeatherListResponse>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var weatherInfo = await this.serviceRequest.ExecuteAsync(new GetWeatherForecastsRequest(), cancellationToken);

        return this.Ok(weatherInfo);
    }
}
