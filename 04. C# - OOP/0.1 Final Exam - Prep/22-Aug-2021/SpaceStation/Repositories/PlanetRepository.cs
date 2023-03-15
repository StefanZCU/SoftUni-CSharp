namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            var planetToRemove = models.FirstOrDefault(x => x.Name == model.Name);
            if (planetToRemove == null) return false;
            models.Remove(planetToRemove);
            return true;
        }

        public IPlanet FindByName(string name)
        {
            return models.First(x => x.Name == name);
        }
    }
}
