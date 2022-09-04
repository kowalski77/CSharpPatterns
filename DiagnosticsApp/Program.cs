using DiagnosticsApp;
using DiagnosticsExamples.Lib;
using System.Diagnostics;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

//await ListenDiagnosticListenerEvents();

ListenCustomDiagnostigEvents();

static async Task ListenDiagnosticListenerEvents()
{
    DiagnosticListener.AllListeners.Subscribe(new DiagnosticExampleObserver());

    HttpClient client = new();
    var response = await client.GetAsync("https://localhost:7215/products"); //Playground.Minimal.API
    response.EnsureSuccessStatusCode();

    var responseBody = await response.Content.ReadAsStringAsync();

    Console.WriteLine(responseBody);
}

static void ListenCustomDiagnostigEvents()
{
    DiagnosticListener.AllListeners.Subscribe(new DiagnosticExampleCustomObserver());

    var lib = new SampleEvents();
    lib.RaiseEvent();
}