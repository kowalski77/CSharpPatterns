namespace DesignPatterns.Singleton;

public class Logger
{
    private static readonly Lazy<Logger> lazyLogger = new Lazy<Logger>(() => new Logger());

    private Logger() { }

    public static Logger Instance => lazyLogger.Value;

    public void Log(string message)
    {
        // ...
    }
}
