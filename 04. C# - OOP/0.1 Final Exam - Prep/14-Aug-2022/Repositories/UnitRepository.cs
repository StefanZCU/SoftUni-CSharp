namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();
        public IMilitaryUnit FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }
        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }
        public bool RemoveItem(string name)
        {
            var unitToRemove = models.FirstOrDefault(x => x.GetType().Name == name);

            if (unitToRemove == null) return false;

            models.Remove(unitToRemove);
            return true;
        }
    }
}
