namespace Playground.Minimal.API.Cancellation;

public class OperationCanceledMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<OperationCanceledMiddleware> logger;

    public OperationCanceledMiddleware(
        RequestDelegate next,
        ILogger<OperationCanceledMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (OperationCanceledException)
        {
            this.logger.LogInformation("Request was cancelled");
            context.Response.StatusCode = 409; // Client Closed Request
        }
    }
}
