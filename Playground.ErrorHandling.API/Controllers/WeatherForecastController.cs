using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Playground.ErrorHandling.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error-development")]
    public IActionResult HandleErrorDevelopment(
    [FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return this.NotFound();
        }

        var exceptionHandlerFeature =
            this.HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        return this.Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public IActionResult HandleError() =>
        this.Problem();

    [HttpGet("/forceerror")]
    public IActionResult ForceError() =>
        throw new InvalidOperationException("This is a forced error");

    [HttpGet("/badrequest")]
    public IActionResult HandleBadRequest() =>
        this.BadRequest();

    [HttpGet("/validationproblem")]
    public IActionResult HandleValidationProblem() =>
        this.ValidationProblem();
}
