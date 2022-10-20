using Playground.Invariants;

namespace Playground.Instantiate.Example;

public abstract class DeviceTwin
{
    private Guid id;
    private IDeviceState deviceState = default!;
    private Guid registrationId;

    public Guid Id
    {
        get => this.id;
        init => this.id = value.NonEmpty();
    }

    public IDeviceState State
    {
        get => this.deviceState;
        init => this.deviceState = value.NonNull();
    }

    public Guid RegistrationId
    {
        get => this.registrationId;
        init => this.registrationId = value.NonEmpty();
    }

    public abstract DeviceType DeviceType { get; }

    public IEnumerable<IDeviceState>? History { get; init; }
}
