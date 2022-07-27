namespace Playground.Minimal.API;

public class FooService : IDisposable
{
    private readonly ILogger<FooService> logger;

    public FooService(ILogger<FooService> logger)
    {
        this.logger = logger;
    }

    public void Dispose()
    {
        this.logger.LogInformation("Dispose called!");
    }

    public string SayHello()
    {
        return "Hello World!";
    }
}
