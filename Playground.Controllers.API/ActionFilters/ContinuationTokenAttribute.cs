using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Playground.Controllers.API.Models;

namespace Playground.Controllers.API.ActionFilters;

[AttributeUsage(AttributeTargets.Method)]
public class ContinuationTokenAttribute : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        //left empty
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value is IPageable pageable)
        {
            context.HttpContext.Response.Headers.Add("ContinuationToken", pageable.ContinuationToken);
        }
    }
}