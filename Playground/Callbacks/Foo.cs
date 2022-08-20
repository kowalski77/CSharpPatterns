namespace Playground.Callbacks;

public class Foo
{
    public Action<string>? SimpleAction { get; set; }

    public void RunSimpleAction()
    {
        SimpleAction?.Invoke("Hello World!");
    }
}