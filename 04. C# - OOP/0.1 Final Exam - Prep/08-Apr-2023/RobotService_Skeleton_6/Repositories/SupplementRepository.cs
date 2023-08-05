namespace RobotService.Repositories;

using System.Linq;
using System.Collections.Generic;

using Contracts;
using RobotService.Models.Contracts;

public class SupplementRepository : IRepository<ISupplement>
{
    private List<ISupplement> models = new();

    public IReadOnlyCollection<ISupplement> Models() => models;

    public void AddNew(ISupplement model)
    {
        models.Add(model);
    }

    public bool RemoveByName(string typeName)
    {
        var suppToRemove = models.FirstOrDefault(x => x.GetType().Name == typeName);
        if (suppToRemove == null) return false;

        models.Remove(suppToRemove);
        return true;
    }

    public ISupplement FindByStandard(int interfaceStandard) =>
        models.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
}