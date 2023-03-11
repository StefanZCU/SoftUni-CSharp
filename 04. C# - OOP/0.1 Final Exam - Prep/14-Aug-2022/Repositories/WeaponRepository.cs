namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            var weaponToRemove = models.FirstOrDefault(x => x.GetType().Name == name);

            if (weaponToRemove == null) return false;

            models.Remove(weaponToRemove);
            return true;
        }
    }
}
