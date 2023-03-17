namespace AquaShop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => models;
        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            var decorationToRemove = models.FirstOrDefault(x => x.GetType().Name == model.GetType().Name);
            if (decorationToRemove == null) return false;
            models.Remove(decorationToRemove);
            return true;
        }

        public IDecoration FindByType(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}
