namespace RobotService.Models.Robots;

public class DomesticAssistant : Robot
{
    private const int BATTERY_CAPACITY = 20000;
    private const int CONVERSION_CAPACITY_INDEX = 2000;
    
    public DomesticAssistant(string model) : base(model, BATTERY_CAPACITY, CONVERSION_CAPACITY_INDEX)
    {
    }
}