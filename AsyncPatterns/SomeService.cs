namespace AsyncPatterns;

public class SomeService
{
    public async Task CreateAsync()
    {
        await Task.Delay(1000);
    }

    public string DoStuff() => "Stuff done!";
}
