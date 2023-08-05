namespace RobotService.Models.Supplements;

using Contracts;

public abstract class Supplement : ISupplement
{
    public int InterfaceStandard { get; }
    public int BatteryUsage { get; }

    public Supplement(int interfaceStandard, int batteryUsage)
    {
        InterfaceStandard = interfaceStandard;
        BatteryUsage = batteryUsage;
    }
}