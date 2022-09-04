using DiagnosticsApp;
using System.Diagnostics;

Console.WriteLine("Press a key to retrieve products...");
Console.ReadKey();  

DiagnosticListener.AllListeners.Subscribe(new DiagnosticExampleObserver());

HttpClient client = new();
var response = await client.GetAsync("https://localhost:7215/products"); //Playground.Minimal.API
response.EnsureSuccessStatusCode();

var responseBody = await response.Content.ReadAsStringAsync();  

Console.WriteLine(responseBody);
