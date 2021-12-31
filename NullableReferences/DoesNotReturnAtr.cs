using System.Diagnostics.CodeAnalysis;

namespace NullableReferences;

public static class DoesNotReturnAtr
{
    public static int Measure(string? pieceOf)
    {
        if (pieceOf is null)
        {
            ThrowHelper();
        }
    
        return pieceOf.Length;
    }

    private static void Test(string? arg)
    {
        OnlyReturnsIfTrue(arg != null);
        Console.WriteLine(arg.Length);
    }

    [DoesNotReturn]
    private static void ThrowHelper() => throw new ArgumentNullException();

    private static void OnlyReturnsIfTrue([DoesNotReturnIf(false)] bool flag)
    {
        if (!flag)
        {
            throw new InvalidOperationException();
        }
    }
}