using System.Diagnostics.CodeAnalysis;

namespace NullableReferences;

public class NotNullAtr
{
    public void Run()
    {
        string? text = null;
        Whatever.ThrowIfNull(text);
        var newText = text.Split(","); // with not null the warning disappears because we know that the value will never be null.
        // So this is not a statement about the method's output. It is a statement about the method's inputs,
        // and more specifically it tells the compiler something that it can infer about the input once the method returns
        ArgumentNullException.ThrowIfNull(text);
    }
}

public static class Whatever
{
    public static void ThrowIfNull([NotNull] string? x)
    {
        if (x == null)
        {
            throw new ArgumentNullException(nameof(x));
        }
    }
}