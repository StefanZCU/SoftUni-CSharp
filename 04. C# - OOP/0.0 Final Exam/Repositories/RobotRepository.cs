namespace RobotService.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using RobotService.Models.Contracts;

    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => models.AsReadOnly();

        public void AddNew(IRobot model)
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

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(x => x.InterfaceStandards.Contains(interfaceStandard));
        }
    }
}
