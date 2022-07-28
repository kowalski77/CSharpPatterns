using System.Text.Json;
using LoggingDemo;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.Console(new CompactJsonFormatter())
//    .CreateLogger();

//using var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog(dispose: true));

using var loggerFactory = LoggerFactory.Create(builder => builder.AddJsonConsole(options =>
{
    options.JsonWriterOptions = new JsonWriterOptions { Indented = true };
}));

var logger = loggerFactory.CreateLogger<Program>();

var segment = new Segment(new Point(1, 2), new Point(4, 6));
var length = segment.GetLength();

logger.LogInformation("With string interpolation");
// former, never use again $
logger.LogInformation($"The length of segment {segment} is {length}");

logger.LogInformation("With params");
// former
logger.LogInformation("The length of segment {@segment} is {length}.", segment, length);

//Console.WriteLine("With Serilog");
//// Serilog
//Log.Logger.Information("The length of segment {@segment} is {length}", segment, length);

logger.LogInformation("With Source Generators - Define");
// new
logger.LogSegmentLength(segment, length);

logger.LogInformation("With Source Generators - Interpolated string handler");
// improved
logger.LogInterpolated(LogLevel.Information, $"The length of segment {segment} is {length}.");

Console.ReadKey();