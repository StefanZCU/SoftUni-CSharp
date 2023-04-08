namespace RobotService.Models.Robots
{
    using System.Text;

    public class DomesticAssistant : Robot
    {
        private const int BatteryCapacity = 20000;
        private const int ConversionCapacityIndex = 2000;

        public DomesticAssistant(string model) : base(model, BatteryCapacity, ConversionCapacityIndex)
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
