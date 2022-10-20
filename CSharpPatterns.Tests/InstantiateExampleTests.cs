using Playground.Instantiate.Example;

namespace CSharpPatterns.Tests;

public class InstantiateExampleTests
{
    [Fact]
    public void Test()
    {
        var controlAppDeviceTwin = new ControlAppDeviceTwin
        {
            Id = Guid.NewGuid(),
            State = new DeviceState
            {
                Characteristics = new ControlAppDeviceCharacteristics
                {
                    AppSettings = new AppSettings
                    {
                        AppId = "AppId",
                        AppVersion = "AppVersion",
                        AppConfiguration = "AppConfiguration",
                    },
                    HardwareInfo = new MobileHardwareInfo
                    {
                        Make = "make1",
                        Model = "modelA"
                    },
                    SoftwareInfo = new MobileSoftwareInfo
                    {
                        OperatingSystem = "Android",
                        OperatingSystemVersion = "17"
                    },
                    RegionSettings = new RegionSettings
                    {
                        Language = "es",
                        Region = "ES"
                    }
                }
            },
            RegistrationId = Guid.NewGuid(),
        };
    }
}
