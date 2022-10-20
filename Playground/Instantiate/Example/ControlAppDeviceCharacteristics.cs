using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record ControlAppDeviceCharacteristics : IDeviceCharacteristics
{
    private AppSettings appSettings = default!;
    private MobileHardwareInfo mobileHardwareInfo = default!;
    private MobileSoftwareInfo mobileSoftwareInfo = default!;
    private RegionSettings regionSettings = default!;

    public AppSettings AppSettings
    {
        get => this.appSettings;
        init => this.appSettings = value.NonNull();
    }

    public MobileHardwareInfo HardwareInfo
    {
        get => this.mobileHardwareInfo;
        init => this.mobileHardwareInfo = value.NonNull();
    }

    public MobileSoftwareInfo SoftwareInfo
    {
        get => this.mobileSoftwareInfo;
        init => this.mobileSoftwareInfo = value.NonNull();
    }

    public RegionSettings RegionSettings
    {
        get => this.regionSettings;
        init => this.regionSettings = value.NonNull();
    }

    public IDictionary<string, object>? Extensions { get; init; }
}
