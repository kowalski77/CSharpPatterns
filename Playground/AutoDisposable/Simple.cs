namespace Playground.AutoDisposable;

public static class Simple
{
    public static void PrintOut(FileInfo source) => PrintOut(source.OpenRead);

    public static void PrintOut(Func<FileStream> sourceFactory)
    {
        using var input = sourceFactory();
        PrintOut(input);
    }

    private static void PrintOut(FileStream input) =>
      PrintOut(() => new StreamReader(input));

    // ...

    public static void PrintOut(Func<TextReader> readerFactory)
    {
        using var textInput = readerFactory();
        PrintOut(textInput);
    }

    private static void PrintOut(TextReader textInput)
    {
        while (textInput.ReadLine() is string line)
        {
            Console.WriteLine(line);
        }
    }
}
