using LoggingDemo;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(new CompactJsonFormatter())
    .CreateLogger();

using var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog(dispose: true));

var logger = loggerFactory.CreateLogger<Program>();

var segment = new Segment(new Point(1, 2), new Point(4, 6));
var length = segment.GetLength();

Console.WriteLine("With string interpolation");
// former, never use again $
logger.LogInformation($"The length of segment {segment} is {length}");

Console.WriteLine("With params");
// former
logger.LogInformation("The length of segment {@segment} is {length}.", segment, length);

Console.WriteLine("With Serilog");
// Serilog
Log.Logger.Information("The length of segment {@segment} is {length}", segment, length);

Console.WriteLine("With Source Generators - Define");
// new
logger.LogSegmentLength(segment, length);

Console.WriteLine("With Source Generators - Interpolated string handler");
// improved
logger.LogInterpolated(LogLevel.Information, $"The length of segment {segment} is {length}.");

Console.ReadKey();