namespace Playground.Instantiate.Example;

public record MobileSoftwareInfo
{
    public MobileSoftwareInfo(
        string operatingSystem, string operatingSystemVersion)
    {
        this.OperatingSystem = operatingSystem;
        this.OperatingSystemVersion = operatingSystemVersion;
    }

    public string OperatingSystem { get; init; }

    public string OperatingSystemVersion { get; init; }
}
