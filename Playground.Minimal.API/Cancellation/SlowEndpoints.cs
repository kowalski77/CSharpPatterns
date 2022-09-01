namespace Playground.Minimal.API.Cancellation;

public static class SlowEndpoints
{
    public static WebApplication RegisterSlowEndpoint(this WebApplication app)
    {
        app.MapGet("/slowasync", async (CancellationToken token) =>
        {
            app.Logger.LogInformation("Starting to do slow work");
            await Task.Delay(10_000, token);
            app.Logger.LogInformation("Finished doing slow work");

            return Results.Ok("Hello from async slow endpoint");

        }).WithName("slowasync");

        app.MapGet("/slowsync", (CancellationToken token) =>
        {
            app.Logger.LogInformation("Starting to do slow work");

            for (var i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
            }

            app.Logger.LogInformation("Finished doing slow work");

            return Results.Ok("Hello from sync slow endpoint");

        }).WithName("slowsync");

        return app;
    }
}
