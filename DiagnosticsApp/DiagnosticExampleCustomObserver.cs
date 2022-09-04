using System.Diagnostics;

namespace DiagnosticsApp;

public class DiagnosticExampleCustomObserver : IObserver<DiagnosticListener>
{
    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(DiagnosticListener value)
    {
        if (value.Name == "DiagnosticsExamples.Lib")
        {
            value.Subscribe(new HttpHandlerDiagnosticCustomObserver());
        }
    }
}

public class HttpHandlerDiagnosticCustomObserver : IObserver<KeyValuePair<string, object?>>
{
    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(KeyValuePair<string, object?> value)
    {
        switch (value.Key)
        {
            case "SampleEvent":
                Console.WriteLine("Event name: " + value.Key);
                Console.WriteLine("Event value: " + value.Value);
                break;
            default:
                break;
        }
    }
}
