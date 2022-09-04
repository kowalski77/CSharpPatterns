using System.Diagnostics;

namespace DiagnosticsExamples.Lib;

public class SampleEvents
{
    private static readonly DiagnosticSource sampleLogger = new DiagnosticListener("DiagnosticsExamples.Lib");

    public void RaiseEvent()
    {
        if (sampleLogger.IsEnabled("SampleEvent"))
        {
            sampleLogger.Write("SampleEvent", new
            {
                name = "initiated",
                info = "Some info about the event"
            });
        }
    }
}
