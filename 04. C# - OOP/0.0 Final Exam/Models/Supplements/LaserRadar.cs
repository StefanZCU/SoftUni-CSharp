namespace RobotService.Models.Supplements
{
    public class LaserRadar : Supplement
    {
        private const int InterfaceStandard = 20082;
        private const int BatteryUsage = 5000;

        public LaserRadar() : base(InterfaceStandard, BatteryUsage)
        {
        }
    }
}
