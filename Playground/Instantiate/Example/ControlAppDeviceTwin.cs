namespace Playground.Instantiate.Example;

public class ControlAppDeviceTwin : DeviceTwin
{
    public ControlAppDeviceTwin(string id = "", IDeviceState state = default!) : base(id, state)
    {
    }

    public ControlAppDeviceTwin(ControlAppDeviceTwin other) 
        : this(other.Id, other.State)
    {
    }

    public override DeviceType DeviceType => DeviceType.ControlApp;
}
