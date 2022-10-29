
namespace Playground.AutoDisposable;

public class Demo
{
    public void Run()
    {
        FileInfo source = new FileInfo(@"C:\Temp\temp.txt");
        int totalLength =
          Advanced.Of.Read(Disposable.Of(source.OpenRead))
            .Sum(line => line.Length);
    }
}
