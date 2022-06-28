using System.Diagnostics;

namespace DiagnosticsStudio;

public class TestDiagnosticObserver : IObserver<DiagnosticListener>
{
    public void OnCompleted() { }

    public void OnError(Exception error) { }

    public void OnNext(DiagnosticListener value)
    {
        if (value.Name == "Microsoft.Extensions.Hosting")
        {
            _ = value.Subscribe(new ProductionisingObserver ());
        }
    }
}

public class ProductionisingObserver  : IObserver<KeyValuePair<string, object?>>
{
    public void OnNext(KeyValuePair<string, object?> value)
    {
        if (value.Key == "HostBuilding")
        {
            var hostBuilder = value.Value as HostBuilder;
            _ = hostBuilder.UseEnvironment("Production");
        }
    }

    public void OnCompleted() { }

    public void OnError(Exception error) { }
}
