namespace RobotService.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using RobotService.Models.Contracts;

    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() => models.AsReadOnly();

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            var itemToRemove = models.FirstOrDefault(x => x.GetType().Name == typeName);

            if (itemToRemove == null) return false;

            models.Remove(itemToRemove);
            return true;
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
        }
    }
}
