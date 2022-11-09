using BenchmarkDotNet.Attributes;
using SharedKernel.Results;

namespace Performance;

[MemoryDiagnoser]
public class ResultBranchingBenchy
{
    [Benchmark]
    public Result<int> HandleWithIfStatements()
    {
        var numberResult = GetNumber(5);
        if (numberResult.Failure)
        {
            return numberResult.Error!;
        }

        var transformResult = Transform(numberResult.Value);
        if (transformResult.Failure)
        {
            return transformResult.Error!;
        }

        return transformResult.Value;
    }

    //[Benchmark]
    //public Result<int> HandleWithLambdas()
    //{
    //    var result = Result.Init
    //        .Start(() => GetNumber(5))
    //        .OnSuccess(Transform);

    //    return result;
    //}

    private static Result<int> GetNumber(int id)
    {
        return id;
    }

    private static Result<int> Transform(int number)
    {
        return number + 5;
    }
}