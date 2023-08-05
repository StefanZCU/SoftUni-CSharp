namespace RobotService.Models.Supplements;

public class SpecializedArm : Supplement
{
    private const int INTERFACE_STANDARD = 10045;
    private const int BATTERY_USAGE = 10000;
    
    public SpecializedArm() : base(INTERFACE_STANDARD, BATTERY_USAGE)
    {
    }
}