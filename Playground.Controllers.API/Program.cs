using FluentValidation;
using FluentValidation.AspNetCore;
using Playground.Controllers.API.ActionFilters;
using Playground.Controllers.API.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        //.ConfigureApiBehaviorOptions(options =>
        //{
        //    options.SuppressModelStateInvalidFilter = true;
        //})
        .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<WeatherValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ValidationFilterAttribute>();
//builder.Services.AddValidatorsFromAssemblyContaining<WeatherValidator>();

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
