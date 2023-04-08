namespace RobotService.Core
{
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using Models.Robots;
    using Models.Supplements;
    using Utilities.Messages;
    using RobotService.Models.Contracts;

    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(IndustrialAssistant) && typeName != nameof(DomesticAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = typeName switch
            {
                nameof(IndustrialAssistant) => new IndustrialAssistant(model),
                _ => new DomesticAssistant(model)
            };

            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = typeName switch
            {
                nameof(SpecializedArm) => new SpecializedArm(),
                _ => new LaserRadar()
            };

            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var supplementInterface = supplements.Models()
                .First(x => x.GetType().Name == supplementTypeName);

            var robotsThatDoNotSupportTheInterface = robots.Models()
                .Where(x => !x.InterfaceStandards.Contains(supplementInterface.InterfaceStandard))
                .Where(x => x.Model == model).ToList();

            if (robotsThatDoNotSupportTheInterface.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            var robot = robotsThatDoNotSupportTheInterface.First();
            robot.InstallSupplement(supplementInterface);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            var robotsToService = robots.Models()
                .Where(x => x.InterfaceStandards.Contains(interfaceStandard))
                .OrderByDescending(x => x.BatteryLevel)
                .ToList();

            if (robotsToService.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
            }

            int batterySum = robotsToService.Sum(x => x.BatteryLevel);

            if (batterySum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, $"{totalPowerNeeded - batterySum}");
            }

            int counter = 0;

            foreach (var robot in robotsToService)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    counter++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    counter++;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsList = robots.Models().Where(x => x.BatteryLevel < x.BatteryCapacity / 2 && x.Model == model).ToList();

            foreach (var robot in robotsList)
            {
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsList.Count);
        }


        public string Report()
        {
            var robotsList = robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity);

            var sb = new StringBuilder();
            foreach (var robot in robotsList)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
