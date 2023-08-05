namespace RobotService.Models.Robots;

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Contracts;
using Utilities.Messages;

public abstract class Robot : IRobot
{
    private string model;
    private int batteryCapacity;
    private List<int> interfaceStandards;

    public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        ConvertionCapacityIndex = conversionCapacityIndex;
        BatteryLevel = batteryCapacity;
        interfaceStandards = new List<int>();
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }

            model = value;
        }
    }

    public int BatteryCapacity
    {
        get => batteryCapacity;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }

            batteryCapacity = value;
        }
    }
    public int BatteryLevel { get; private set; }
    public int ConvertionCapacityIndex { get; private set; }
    public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();
    
    
    
    public void Eating(int minutes)
    {
        for (int i = 1; i <= minutes; i++)
        {
            BatteryLevel += ConvertionCapacityIndex * minutes;

            if (BatteryLevel < BatteryCapacity) continue;
            
            BatteryLevel = batteryCapacity;
            return;
        }
    }

    public void InstallSupplement(ISupplement supplement)
    {
        interfaceStandards.Add(supplement.InterfaceStandard);
        BatteryCapacity -= supplement.BatteryUsage;
        BatteryLevel -= supplement.BatteryUsage;

    }

    public bool ExecuteService(int consumedEnergy)
    {
        if (BatteryLevel < consumedEnergy) return false;
        
        BatteryLevel -= consumedEnergy;
        return true;

    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        
        sb
            .AppendLine($"{GetType().Name} {Model}:")
            .AppendLine($"--Maximum battery capacity: {BatteryCapacity}")
            .AppendLine($"--Current battery level: {BatteryLevel}")
            .AppendLine($"--Supplements installed: {(interfaceStandards.Any() ? string.Join(", ", interfaceStandards) : "none")}");

        return sb.ToString().TrimEnd();
    }
}