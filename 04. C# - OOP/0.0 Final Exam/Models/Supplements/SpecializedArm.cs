namespace RobotService.Models.Supplements
{
    public class SpecializedArm : Supplement
    {
        private const int InterfaceStandard = 10045;
        private const int BatteryUsage = 10000;

        public SpecializedArm() : base(InterfaceStandard, BatteryUsage)
        {
        }
    }
}
