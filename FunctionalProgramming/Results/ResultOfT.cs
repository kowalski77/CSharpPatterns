namespace FunctionalProgramming.Results;

public sealed class Result<T> : Result
{
    private readonly T value;

    public Result(T value) => this.value = value;

    public Result(ErrorResult errorResult) : base(errorResult) => this.value = default!;

    public Result(IEnumerable<ErrorResult> errorResults) : base(errorResults) => this.value = default!;

    public T Value => this.Failure ? throw new InvalidOperationException("The result object has no value.") : this.value;

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(ErrorResult errorResult) => new(errorResult);

    public static implicit operator Result<T>(List<ErrorResult> errorResults) => new(errorResults);
}
