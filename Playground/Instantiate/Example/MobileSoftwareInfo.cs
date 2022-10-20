using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record MobileSoftwareInfo
{
    private string operatingSystem = default!;
    private string operatingSystemVersion = default!;

    public string OperatingSystem
    {
        get => this.operatingSystem;
        init => this.operatingSystem = value.NonEmpty();
    }

    public string OperatingSystemVersion
    {
        get => this.operatingSystemVersion;
        init => this.operatingSystemVersion = value.NonEmpty();
    }
}
