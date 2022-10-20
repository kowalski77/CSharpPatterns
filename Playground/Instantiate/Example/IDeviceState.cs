namespace Playground.Instantiate.Example;

public interface IDeviceState
{
    IDeviceCharacteristics Characteristics { get; }

    DateTime TimeStamp { get; }
}