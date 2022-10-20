using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record MobileHardwareInfo
{
    private string make = default!;
    private string model = default!;

    public string Make
    {
        get => this.make;
        init => this.make = value.NonEmpty();
    }

    public string Model
    {
        get => this.model;
        init => this.model = value.NonEmpty();
    }
}
