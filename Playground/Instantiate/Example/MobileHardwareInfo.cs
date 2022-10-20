namespace Playground.Instantiate.Example;

public record MobileHardwareInfo
{
    public MobileHardwareInfo(string make, string model)
    {
        this.Make = make;
        this.Model = model;
    }

    public string Make { get; init; }

    public string Model { get; init; }
}
