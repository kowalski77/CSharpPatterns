namespace Playground;

public class Bar
{
    public void Execute(int id)
    {
        var args = new BarExecutedEventArgs
        {
            Id = id
        };

        this.BarExecuted?.Invoke(this, args);
    }

    public event EventHandler<BarExecutedEventArgs>? BarExecuted;
}

public class BarExecutedEventArgs : EventArgs
{
    public int Id { get; set; }
}
