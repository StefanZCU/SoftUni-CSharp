namespace RobotService.Models.Robots;

public class IndustrialAssistant : Robot
{
    private const int BATTERY_CAPACITY = 40000;
    private const int CONVERSION_CAPACITY_INDEX = 5000;
    
    public IndustrialAssistant(string model) : base(model, BATTERY_CAPACITY, CONVERSION_CAPACITY_INDEX)
    {
    }
}