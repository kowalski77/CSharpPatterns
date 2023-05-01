namespace Playground.Timers;

public class ClassicTimer
{
    private Task? executingTask;
    private Timer timer = default!;

    public void Run(CancellationToken cancellationToken)
    {
        this.timer = new Timer(o => this.ExecuteInternalTask(o, cancellationToken), null, TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(-1));
    }

    public async Task StopAsync()
    {
        if (this.executingTask is not null)
        {
            await this.executingTask;
            this.executingTask.Dispose();
        }

        await this.timer.DisposeAsync();
    }

    private void ExecuteInternalTask(object? _, CancellationToken cancellationToken)
    {
        this.timer.Change(Timeout.Infinite, 0);

        this.executingTask = ExecuteWorkAsync(cancellationToken);

        this.timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(-1));
    }

    private static async Task ExecuteWorkAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(500, cancellationToken);
        Console.WriteLine($"Time: {DateTime.Now:O}");
    }
}