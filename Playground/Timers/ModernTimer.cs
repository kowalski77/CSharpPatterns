namespace Playground.Timers;

public class ModernTimer
{
    private Task? executingTask;
    private readonly PeriodicTimer timer;

    public ModernTimer()
    {
        this.timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
    }

    public void Run(CancellationToken cancellationToken)
    {
        this.executingTask = this.RunAsync(cancellationToken);
    }

    public async Task StopAsync()
    {
        if (this.executingTask is null)
            return;

        this.timer.Dispose();

        await this.executingTask;

        this.executingTask.Dispose();
    }

    private async Task RunAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested && await this.timer.WaitForNextTickAsync(cancellationToken))
        {
            await Task.Delay(500, cancellationToken);
            Console.WriteLine($"Time: {DateTime.Now:O}");
        }
    }
}