namespace Easter.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Easter.Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => models;
        public void Add(IEgg model)
        {
            models.Add(model);
        }

        public bool Remove(IEgg model)
        {
            var eggToRemove = models.FirstOrDefault(x => x.Name == model.Name);
            if (eggToRemove == null) return false;
            models.Remove(eggToRemove);
            return true;
        }

        public IEgg FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
