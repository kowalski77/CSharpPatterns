using Playground.Endpoints.API.Services;
using Playground.Endpoints.API.Support;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.UseNamespaceRouteToken();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRequestsFromAssembly<GetWeatherForecastsRequest>();
builder.Services.AddScoped<WeatherRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
