using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => models.AsReadOnly();
        public void Add(IHero model)
        {
            models.Add(model);
        }

        public bool Remove(IHero model)
        {
            var heroToRemove = models.FirstOrDefault(x => x.Name == model.Name);
            if (heroToRemove == null) return false; 
            
            models.Remove(heroToRemove);
            return true;
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
