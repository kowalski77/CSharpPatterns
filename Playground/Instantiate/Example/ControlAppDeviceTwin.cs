namespace Playground.Instantiate.Example;

public class ControlAppDeviceTwin : DeviceTwin
{
    public ControlAppDeviceTwin()
    {
    }

    public ControlAppDeviceTwin(ControlAppDeviceTwin other)
    {
        this.State = other.State;
        this.RegistrationId = other.RegistrationId;
    }

    public override DeviceType DeviceType => DeviceType.ControlApp;
}
