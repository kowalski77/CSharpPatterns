using Playground.Invariants;

namespace Playground.Instantiate.Example;

public record DeviceState : IDeviceState
{
    private IDeviceCharacteristics characteristics = default!;

    public IDeviceCharacteristics Characteristics
    {
        get => this.characteristics;
        init => this.characteristics = value.NonNull();
    }

    public DateTime TimeStamp { get; init; }
}