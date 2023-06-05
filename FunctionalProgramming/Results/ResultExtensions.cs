using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Results;

public static class ResultExtensions
{
    public static Result Validate(this Result _, params Result[] results)
    {
        var errorResults = results
            .Where(result => result.Failure)
            .SelectMany(result => result.Errors!)
            .ToList();

        return errorResults.Any() ?
            errorResults :
            Result.Ok();
    }

    public static void Match(this Result result, Action success, Action<IEnumerable<ErrorResult>> failure)
    {
        if (result.NonNull().Success)
            success.NonNull()();
        else
            failure.NonNull()(result.Errors!);
    }

    public static void Match(this Result result, Action success, Action failure)
    {
        if (result.NonNull().Success)
            success.NonNull()();
        else
            failure.NonNull()();
    }

    public static Result<T> Bind<T>(this Result result, Func<T> func) =>
    result.NonNull().Success ?
        func.NonNull()() :
        result.ToErrorsResult();

    public static Result<T> Bind<T>(this Result result, Func<Result<T>> func) =>
    result.NonNull().Success ?
        func.NonNull()() :
        result.ToErrorsResult();

    public static Result<TR> Bind<T, TR>(this Result<T> result, Func<T, Result<TR>> func) =>
    result.NonNull().Success ?
        func.NonNull()(result.Value) :
        result.ToErrorsResult();

    public static Result<TR> Bind<T, TR>(this Result<T> result, Func<T, TR> func) =>
        result.NonNull().Success ?
        func.NonNull()(result.Value) :
        result.ToErrorsResult();

    public static Result Bind<T>(this Result<T> result, Func<T, Result> func) =>
    result.NonNull().Success ?
        func.NonNull()(result.Value) :
        result.ToErrorsResult();

    public static async Task<Result<T>> BindAsync<T>(this Result result, Func<Task<Result<T>>> func) =>
     result.NonNull().Success ?
         await func.NonNull()() :
         result.ToErrorsResult();

    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<T, Task<Result>> func) =>
     result.NonNull().Success ?
         await func.NonNull()(result.Value) :
         result.ToErrorsResult();

    public static async Task<Result<TR>> BindAsync<T, TR>(this Result<T> result, Func<T, Task<Result<TR>>> func) =>
    result.NonNull().Success ?
        await func.NonNull()(result.Value) :
        result.ToErrorsResult();

    public static async Task<Result<TR>> BindAsync<TR>(this Task<Result> result, Func<Task<Result<TR>>> func)
    {
        Result awaitedResult = await result.NonNull();

        return awaitedResult.NonNull().Success ?
        await func.NonNull()() :
        awaitedResult.ToErrorsResult();
    }

    public static async Task<Result<TR>> BindAsync<T, TR>(this Task<Result<T>> result, Func<T, Task<Result<TR>>> func)
    {
        Result<T> awaitedResult = await result.NonNull();

        return awaitedResult.NonNull().Success ?
            await func.NonNull()(awaitedResult.Value) :
            awaitedResult.ToErrorsResult();
    }

    public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> result, Func<T, Task> func)
    {
        Result<T> awaitedResult = await result.NonNull();

        if (awaitedResult.Success)
            await func.NonNull()(awaitedResult.Value);

        return awaitedResult;
    }

    public static List<ErrorResult> ToErrorsResult(this Result result) =>
        result.NonNull().Errors!.ToList();
}