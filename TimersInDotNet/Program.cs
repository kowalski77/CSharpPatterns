
using TimersInDotNet;

//var timer = new ClassicTimer();
var timer = new ModernTimer();
var cts = new CancellationTokenSource();

Console.WriteLine("Press any key to start the timer");
Console.ReadKey();

timer.Run(cts.Token);

Console.WriteLine("Press any key to stop the timer");
Console.ReadKey();

await timer.StopAsync();
cts.Dispose();