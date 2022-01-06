using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace LoggingDemo;

[InterpolatedStringHandler]
public readonly ref struct StructuredLoggingInterpolatedStringHandler
{
    private readonly StringBuilder template = null!;
    private readonly List<object?> arguments = null!;

    public bool IsEnabled { get; }

    public StructuredLoggingInterpolatedStringHandler(
        int literalLength,
        int formattedCount,
        ILogger logger,
        LogLevel logLevel,
        out bool isEnabled)
    {
        ArgumentNullException.ThrowIfNull(logger);

        this.IsEnabled = isEnabled = logger.IsEnabled(logLevel);
        if (!isEnabled)
        {
            return;
        }

        this.template = new StringBuilder(literalLength + 20 * formattedCount);
        this.arguments = new List<object?>(formattedCount);
    }

    public void AppendLiteral(string literal)
    {
        ArgumentNullException.ThrowIfNull(literal);
        if (!this.IsEnabled)
        {
            return;
        }

        this.template.Append(literal.Replace("{", "{{", StringComparison.Ordinal).Replace("}", "}}", StringComparison.Ordinal));
    }

    public void AppendFormatted<T>(
        T value,
        [CallerArgumentExpression("value")] string name = "")
    {
        if (!this.IsEnabled)
        {
            return;
        }

        this.arguments.Add(value);
        this.template.Append(CultureInfo.InvariantCulture, $"{{@{name}}}");
    }

    public (string, object?[]) GetTemplateAndArguments()
    {
        return (this.template.ToString(), this.arguments.ToArray());
    }
}