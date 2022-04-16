namespace SharedKernel.Results;

public class ErrorResult
{
    private const string Separator = "||";

    public ErrorResult(
        string? code,
        string? message)
    {
        this.Code = code;
        this.Message = message;
        this.TimeGenerated = DateTime.UtcNow;
    }

    public string? Code { get; }

    public string? Message { get; }

    public DateTime TimeGenerated { get; }

    public string Serialize()
    {
        return $"{this.Code}{Separator}{this.Message}";
    }
}
