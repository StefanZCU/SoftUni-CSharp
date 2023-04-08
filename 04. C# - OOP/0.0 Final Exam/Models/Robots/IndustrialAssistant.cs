namespace RobotService.Models.Robots
{
    using System.Text;

    public class IndustrialAssistant : Robot
    {
        private const int BatteryCapacity = 40000;
        private const int ConversionCapacityIndex = 5000;

        public IndustrialAssistant(string model) : base(model, BatteryCapacity, ConversionCapacityIndex)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{GetType().Name} {Model}:")
                .AppendLine(base.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
