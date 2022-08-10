namespace Playground.Endpoints.API.Endpoints.Weathers;

public record WeatherListResponse(DateTime Date, int TemperatureC, string? Summary);