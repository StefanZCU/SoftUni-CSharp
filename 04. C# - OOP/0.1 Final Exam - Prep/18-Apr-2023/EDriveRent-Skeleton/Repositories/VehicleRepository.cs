namespace EDriveRent.Repositories;

using System.Linq;
using System.Collections.Generic;

using Contracts;
using EDriveRent.Models.Contracts;

public class VehicleRepository : IRepository<IVehicle>
{
    private List<IVehicle> models = new();
    
    public void AddModel(IVehicle model)
    {
        models.Add(model);
    }

    public bool RemoveById(string identifier)
    {
        var modelToRemove = models.FirstOrDefault(x => x.LicensePlateNumber == identifier);

        if (modelToRemove == null) return false;
        models.Remove(modelToRemove);
        return true;
    }

    public IVehicle FindById(string identifier)
    {
        return models.FirstOrDefault(x => x.LicensePlateNumber == identifier);
    }

    public IReadOnlyCollection<IVehicle> GetAll() => models.AsReadOnly();
}