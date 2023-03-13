namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Formula1.Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();
        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public bool Remove(IPilot model)
        {
            var pilotToRemove = models.FirstOrDefault(x => x.FullName == model.FullName);
            if (pilotToRemove == null) return false;
            models.Remove(pilotToRemove);
            return true;
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(x => x.FullName == name);
        }
    }
}
