using System.Diagnostics;

namespace DiagnosticsApp;

public class DiagnosticExampleObserver : IObserver<DiagnosticListener>
{
    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(DiagnosticListener value)
    {
        if (value.Name == "HttpHandlerDiagnosticListener")
        {
            value.Subscribe(new HttpHandlerDiagnosticObserver());
        }
    }
}

public class HttpHandlerDiagnosticObserver : IObserver<KeyValuePair<string, object?>>
{
    private readonly AsyncLocal<Stopwatch> stopwatch = new();

    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(KeyValuePair<string, object?> value)
    {
        switch (value.Key)
        {
            case "System.Net.Http.Request":
                PrintRequestInfo(value!);
                this.stopwatch.Value = Stopwatch.StartNew();
                break;
            case "System.Net.Http.Response":
                this.stopwatch.Value!.Stop();
                Console.WriteLine("The HttpClient call took: " + this.stopwatch.Value.Elapsed.TotalMilliseconds + " milliseconds.");
                break;
            default:
                break;
        }
    }

    private static void PrintRequestInfo(KeyValuePair<string, object> value)
    {
        var type = value.Value.GetType();
        var propInfo = type.GetProperty("Request");
        var req = (HttpRequestMessage)propInfo!.GetValue(value.Value)!;

        Console.WriteLine($"Uri: {req.RequestUri} - Method: {req.Method}");
    }
}
