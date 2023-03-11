namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using PlanetWars.Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            var planetToRemove = models.FirstOrDefault(x => x.Name == name);
            if (planetToRemove == null) return false;

            models.Remove(planetToRemove);
            return true;
        }
    }
}
