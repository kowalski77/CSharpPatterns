using Microsoft.AspNetCore.Mvc;

namespace Playground.ErrorHandling.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet("{Numerator}/{Denominator}")]
    public IActionResult Divide(double Numerator, double Denominator) => Denominator == 0 ? this.BadRequest() : this.Ok(Numerator / Denominator);

    [HttpGet("{radicand}")]
    public IActionResult Squareroot(double radicand) => radicand < 0 ? this.BadRequest() : this.Ok(Math.Sqrt(radicand));
}