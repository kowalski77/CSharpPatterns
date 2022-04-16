namespace SharedKernel.Results;

public static class ResultExtensions
{
    public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(func);

        return result.Success ?
                func() :
                result.Error!;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, Result<T>> func)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(func);

        return result.Success ?
            func(result.Value) :
            result.Error!;
    }
}
