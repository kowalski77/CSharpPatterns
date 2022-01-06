using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace LoggingDemo;

public static partial class LoggingExtensions
{
    [LoggerMessage(0, LogLevel.Information, "The length of segment {segment} is {length}.")]
    public static partial void LogSegmentLength(
        this ILogger logger, 
        Segment segment, 
        double length);

    public static void LogInterpolated(
        this ILogger logger, 
        LogLevel logLevel, 
        [InterpolatedStringHandlerArgument("logger", "logLevel")] ref StructuredLoggingInterpolatedStringHandler handler)
    {
        if (!handler.IsEnabled)
        {
            return;
        }

        var (template, arguments) = handler.GetTemplateAndArguments();
        logger.Log(logLevel, template, arguments);
    }
}