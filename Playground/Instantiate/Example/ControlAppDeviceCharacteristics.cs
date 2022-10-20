namespace Playground.Instantiate.Example;

public record ControlAppDeviceCharacteristics : IDeviceCharacteristics
{
    public ControlAppDeviceCharacteristics(
        string appId,
        string appVersion,
        string appConfiguration,
        MobileHardwareInfo hardwareInfo,
        MobileSoftwareInfo softwareInfo,
        string region,
        string language,
        IDictionary<string, object> extensions)
    {
        this.AppId = appId;
        this.AppVersion = appVersion;
        this.AppConfiguration = appConfiguration;
        this.HardwareInfo = hardwareInfo;
        this.SoftwareInfo = softwareInfo;
        this.Region = region;
        this.Language = language;
        this.Extensions = extensions;
    }

    public string AppId { get; init; }

    public string AppVersion { get; init; }

    public string AppConfiguration { get; init; }

    public MobileHardwareInfo HardwareInfo { get; init; }

    public MobileSoftwareInfo SoftwareInfo { get; init; }

    public string Region { get; init; }

    public string Language { get; init; }

    public IDictionary<string, object> Extensions { get; set; }
}
