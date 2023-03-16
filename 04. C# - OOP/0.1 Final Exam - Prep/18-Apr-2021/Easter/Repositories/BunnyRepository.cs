namespace Easter.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Easter.Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => models;
        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public bool Remove(IBunny model)
        {
            var bunnyToRemove = models.FirstOrDefault(x => x.Name == model.Name);
            if (bunnyToRemove == null) return false;
            models.Remove(bunnyToRemove);
            return true;
        }

        public IBunny FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
