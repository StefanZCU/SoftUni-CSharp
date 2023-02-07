namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using UniversityCompetition.Models.Contracts;
    using Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;
        public IReadOnlyCollection<IUniversity> Models => models.AsReadOnly();
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
