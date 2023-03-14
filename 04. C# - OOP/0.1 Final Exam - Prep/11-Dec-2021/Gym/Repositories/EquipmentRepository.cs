using System.Linq;

namespace Gym.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Gym.Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => models.AsReadOnly();
        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            var equipmentToRemove = models.FirstOrDefault(x => x.GetType().Name == model.GetType().Name);
            if (equipmentToRemove == null) return false;
            models.Remove(equipmentToRemove);
            return true;
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}
