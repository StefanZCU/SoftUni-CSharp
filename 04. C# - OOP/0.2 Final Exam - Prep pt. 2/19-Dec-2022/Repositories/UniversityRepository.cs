namespace UniversityCompetition.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using UniversityCompetition.Models.Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;

        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => models;
        public void AddModel(IUniversity model)
        {
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
