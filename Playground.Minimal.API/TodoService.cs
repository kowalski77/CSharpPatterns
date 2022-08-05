namespace Playground.Minimal.API;

public class TodoService :  ITodoService, IDisposable
{
    private readonly ILogger<TodoService> logger;

    public TodoService(ILogger<TodoService> logger)
    {
        this.logger = logger;
    }

    public string SayHello()
    {
        return "Hello World!";
    }

    public IReadOnlyList<TodoItem> GetTodoItems()
    {
        return new List<TodoItem>(new[]
        {
            new TodoItem(1, "Apply Facade pattern", DateTime.Now.AddDays(1)),
            new TodoItem(2, "Apply Singleton pattern", DateTime.Now.AddDays(2)),
        });
    }

    public void Dispose()
    {
        this.logger.LogInformation("Dispose called!");
    }
}

public interface ITodoService
{
    string SayHello();
    
    IReadOnlyList<TodoItem> GetTodoItems();
}

public record TodoItem(long Id, string Description, DateTime ExpiresAt);
