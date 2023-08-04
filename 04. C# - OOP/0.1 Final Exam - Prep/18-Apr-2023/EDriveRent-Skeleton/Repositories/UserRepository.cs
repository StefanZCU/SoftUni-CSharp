namespace EDriveRent.Repositories;

using System.Linq;
using System.Collections.Generic;

using Contracts;
using EDriveRent.Models.Contracts;

public class UserRepository : IRepository<IUser>
{
    private List<IUser> models = new();

    public void AddModel(IUser model)
    {
        models.Add(model);
    }

    public bool RemoveById(string identifier)
    {
        var unitToRemove = models.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);

        if (unitToRemove == null) return false;

        models.Remove(unitToRemove);
        return true;
    }

    public IUser FindById(string identifier)
    {
        return models.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);
    }

    public IReadOnlyCollection<IUser> GetAll() => models.AsReadOnly();
}