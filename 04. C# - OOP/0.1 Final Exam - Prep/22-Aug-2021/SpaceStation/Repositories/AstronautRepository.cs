namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using SpaceStation.Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;
        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => models.AsReadOnly();
        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            var astronautToRemove = models.FirstOrDefault(x => x.Name == model.Name);
            if (astronautToRemove == null) return false;
            models.Remove(astronautToRemove);
            return true;
        }

        public IAstronaut FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
