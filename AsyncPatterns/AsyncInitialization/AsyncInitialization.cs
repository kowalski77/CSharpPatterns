namespace AsyncPatterns.AsyncInitialization;

public interface IAsyncInitialization<T>
{
    Task<T> Initialization { get; }
}

public class AsyncInitialization : IAsyncInitialization<SomeService>
{
    public AsyncInitialization()
    {
        Initialization = InitializateAsync();
    }

    public Task<SomeService> Initialization { get; }

    private static async Task<SomeService> InitializateAsync()
    {
        var someService = new SomeService();
        await someService.CreateAsync();

        return someService;
    }
}
