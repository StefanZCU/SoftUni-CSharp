using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories;

public class RouteRepository : IRepository<IRoute>
{
    private List<IRoute> models = new();
    
    public void AddModel(IRoute model)
    {
        models.Add(model);
    }

    public bool RemoveById(string identifier)
    {
        var modelToRemove = models.FirstOrDefault(x => x.RouteId == int.Parse(identifier));
        if (modelToRemove == null) return false;
        models.Remove(modelToRemove);
        return true;
    }

    public IRoute FindById(string identifier)
    {
        return models.FirstOrDefault(x => x.RouteId == int.Parse(identifier));
    }

    public IReadOnlyCollection<IRoute> GetAll() => models.AsReadOnly();
}