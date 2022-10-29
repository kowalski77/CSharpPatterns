namespace Playground.AutoDisposable;

public class Advanced
{
    public void PrintOut(Disposable<FileStream> inputFactory) =>
        inputFactory.Use(this.PrintOut);

    private void PrintOut(FileStream input) =>
      this.PrintOut(Disposable.Of<TextReader>(() => new StreamReader(input)));

    public void PrintOut(Disposable<TextReader> readerFactory) =>
      readerFactory.Use(this.PrintOut);

    private void PrintOut(TextReader textInput)
    {
        while (textInput.ReadLine() is string line)
        {
            Console.WriteLine(line);
        }
    }

    public IReadOnlyList<string> Read(Disposable<FileStream> inputFactory) =>
        inputFactory.Use(this.Read);

    private List<string> Read(FileStream input) =>
      this.Read(Disposable.Of<TextReader>(() => new StreamReader(input))).ToList();

    public IReadOnlyList<string> Read(Disposable<TextReader> readerFactory) =>
      readerFactory.Use(this.Read);

    private List<string> Read(TextReader textInput)
    {
        var data = new List<string>();
        while (textInput.ReadLine() is string line)
        {
            data.Add(line);
        }
        return data;
    }

    public static Advanced Of => new();
}

// The code above is a bit more complex than the previous example, but it is still easy to understand.
// The main difference is that the code above uses a generic class to wrap the disposable objects.
// The class is called Disposable<T> and it has two methods: Use and Use<TResult>.
// The first method is used to execute an action on the disposable object, and the second method is used to map the disposable object to a value.
// The class also has a static method called Of<T> that is used to create an instance of the class. 