namespace Playground;

public class Foo
{
    public Action<string>? SimpleAction { get; set; }

    public void RunSimpleAction()
    {
        this.SimpleAction?.Invoke("Hello World!");
    }
}