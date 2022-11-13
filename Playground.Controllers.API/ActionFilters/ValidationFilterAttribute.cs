using Microsoft.AspNetCore.Mvc.Filters;

namespace Playground.Controllers.API.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
    private readonly IServiceProvider serviceProvider;

    public ValidationFilterAttribute(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // left empty
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        //if (context.ModelState.IsValid)
        //{
        //    return;
        //}

        //context.Result = new BadRequestObjectResult(context.ModelState);
    }
}
