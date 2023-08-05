namespace RobotService.Repositories;

using System.Linq;
using System.Collections.Generic;

using Contracts;
using RobotService.Models.Contracts;

public class RobotRepository : IRepository<IRobot>
{
    private List<IRobot> models = new();

    public IReadOnlyCollection<IRobot> Models() => models;

    public void AddNew(IRobot model)
    {
        models.Add(model);
    }

    public bool RemoveByName(string typeName)
    {
        var robotToRemove = models.FirstOrDefault(x => x.GetType().Name == typeName);
        if (robotToRemove == null) return false;
        models.Remove(robotToRemove);
        return true;
    }

    public IRobot FindByStandard(int interfaceStandard) =>
        models.FirstOrDefault(x => x.InterfaceStandards.Contains(interfaceStandard));
}