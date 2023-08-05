using System.Linq;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Supplements;
using RobotService.Repositories;
using RobotService.Utilities.Messages;

namespace RobotService.Core;

public class Controller : IController
{
    private SupplementRepository supplements = new();
    private RobotRepository robots = new();
    
    public string CreateRobot(string model, string typeName)
    {
        if (typeName != nameof(DomesticAssistant) && 
            typeName != nameof(IndustrialAssistant))
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }
        
        IRobot robot = typeName switch
        {
            nameof(DomesticAssistant) => new DomesticAssistant(model),
            _ => new IndustrialAssistant(model)
        };

        robots.AddNew(robot);
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        if (typeName != nameof(SpecializedArm) && 
            typeName != nameof(LaserRadar))
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
        var supplement = supplements.Models().First(x => x.GetType().Name == supplementTypeName);

        var robotToFind = robots.Models().FirstOrDefault(x => !x.InterfaceStandards.Contains(supplement.InterfaceStandard) && x.Model == model);

        if (robotToFind == null)
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }
        
        robotToFind.InstallSupplement(supplement);
        supplements.RemoveByName(supplementTypeName);
        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

    }

    public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
    {
        var robotsToFind = robots.Models().Where(x => x.InterfaceStandards.Contains(interfaceStandard)).OrderByDescending(x => x.BatteryLevel).ToList();

        if (robotsToFind.Count == 0)
        {
            return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
        }

        int sumOfRobotsToFind = robotsToFind.Sum(x => x.BatteryLevel);

        if (sumOfRobotsToFind < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName,
                (totalPowerNeeded - sumOfRobotsToFind).ToString());
        }

        int robotCounter = 0;

        foreach (var robot in robotsToFind)
        {
            if (robot.BatteryLevel >= totalPowerNeeded)
            {
                robot.ExecuteService(totalPowerNeeded);
                robotCounter++;
                break;
            }
            
            totalPowerNeeded -= robot.BatteryLevel;
            robot.ExecuteService(robot.BatteryLevel);
            robotCounter++;
        }

        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCounter);
        
    }
    
    public string RobotRecovery(string model, int minutes)
    {
        var robotsToFind = robots.Models().Where(x => x.Model == model && x.BatteryCapacity / 2 >= x.BatteryLevel).ToList();

        foreach (var robot in robotsToFind)
        {
            robot.Eating(minutes);
        }

        return string.Format(OutputMessages.RobotsFed, robotsToFind.Count);
    }


    public string Report()
    {
        var sb = new StringBuilder();
        foreach (var robot in robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity))
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}