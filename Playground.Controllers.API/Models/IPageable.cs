namespace Playground.Controllers.API.Models;

public interface IPageable
{
    public string ContinuationToken { get; set; }
}