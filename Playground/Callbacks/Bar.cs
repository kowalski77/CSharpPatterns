namespace Playground.Callbacks;

public class Bar
{
    public void Execute(int id)
    {
        var args = new BarExecutedEventArgs
        {
            Id = id
        };

        BarExecuted?.Invoke(this, args);
    }

    public event EventHandler<BarExecutedEventArgs>? BarExecuted;
}

public class BarExecutedEventArgs : EventArgs
{
    public int Id { get; set; }
}
