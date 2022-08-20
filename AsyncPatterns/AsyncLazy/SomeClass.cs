namespace AsyncPatterns.AsyncLazy;

public class SomeClass
{
    private static readonly Lazy<Task<SomeService>> SomeServiceLazy = new(async () =>
    {
        var someService = new SomeService();
        await someService.CreateAsync();

        return someService;
    });

    public async Task<string> UseSomeServiceAsync()
    {
        var someService = await SomeServiceLazy.Value;

        var result = someService.DoStuff();

        return result;
    }
}
