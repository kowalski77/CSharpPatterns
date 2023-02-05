namespace DesignPatterns.Creational.Singleton;

public class Logger
{
    private static readonly Lazy<Logger> lazyLogger = new(() => new Logger());

    private Logger() { }

    public static Logger Instance => lazyLogger.Value;

    public void Log(string message)
    {
        // ...
    }
}
