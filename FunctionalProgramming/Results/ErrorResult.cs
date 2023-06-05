namespace FunctionalProgramming.Results;

public record ErrorResult
{
    public ErrorResult(
        string title,
        string message)
    {
        this.Title = title;
        this.Message = message;
    }

    public string Title { get; }

    public string Message { get; }
}
