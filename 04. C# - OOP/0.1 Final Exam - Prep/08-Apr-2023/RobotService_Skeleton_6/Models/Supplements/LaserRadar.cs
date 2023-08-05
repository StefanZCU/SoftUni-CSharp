namespace RobotService.Models.Supplements;

public class LaserRadar : Supplement
{
    private const int INTERFACE_STANDARD = 20082;
    private const int BATTERY_USAGE = 5000;
    
    public LaserRadar() : base(INTERFACE_STANDARD, BATTERY_USAGE)
    {
    }
}