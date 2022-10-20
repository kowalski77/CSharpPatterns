namespace Playground.Instantiate.Example;

public class DeviceState : IDeviceState
{
    public DeviceState(IDeviceCharacteristics characteristics, DateTime timeStamp)
    {
        this.Characteristics = characteristics;
        this.TimeStamp = timeStamp;
    }

    public IDeviceCharacteristics Characteristics { get; private set; }

    public DateTime TimeStamp { get; private set; }
}
