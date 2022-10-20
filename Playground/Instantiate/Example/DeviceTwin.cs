using Playground.Invariants;

namespace Playground.Instantiate.Example;

public abstract class DeviceTwin
{
    protected DeviceTwin(string id, IDeviceState state)
    {
        this.Id = id.NonEmpty();
        this.State = state.NonNull();
    }

    public string Id { get; init; }

    public IDeviceState State { get; init; }

    public string? RegistrationId { get; init; }

    public abstract DeviceType DeviceType { get; }

    public IEnumerable<IDeviceState>? History { get; init; }
}
