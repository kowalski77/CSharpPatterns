using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SharedKernel;

public static class Guards
{
    public static int ThrowIfLessOrEqualThan(int argument, int value, [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument <= value)
        {
            Throw(paramName);
        }

        return argument;
    }

    [DoesNotReturn]
    private static void Throw(string? paramName)
    {
        throw new ArgumentOutOfRangeException(paramName);
    }
}