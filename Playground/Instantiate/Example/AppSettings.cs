using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record AppSettings
{
    private string appId = default!;
    private string appVersion = default!;
    private string appConfiguration = default!;

    public string AppId
    {
        get => this.appId;
        init => this.appId = value.NonEmpty();
    }

    public string AppVersion
    {
        get => this.appVersion;
        init => this.appVersion = value.NonEmpty();
    }

    public string AppConfiguration
    {
        get => this.appConfiguration;
        init => this.appConfiguration = value.NonEmpty();
    }
}
