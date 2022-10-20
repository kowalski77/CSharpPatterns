using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record RegionSettings
{
    private string region = default!;
    private string language = default!;

    public string Region
    {
        get => this.region;
        init => this.region = value.NonEmpty();
    }

    public string Language
    {
        get => this.language;
        init => this.language = value.NonEmpty();
    }
}
