using DiagnosticsStudio;
using System.Diagnostics;

DiagnosticListener.AllListeners.Subscribe(new TestDiagnosticObserver());

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
