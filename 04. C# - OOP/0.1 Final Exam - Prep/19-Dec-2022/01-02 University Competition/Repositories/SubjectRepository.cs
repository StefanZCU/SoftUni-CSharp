namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using UniversityCompetition.Models.Contracts;
    using Contracts;

    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models;

        public IReadOnlyCollection<ISubject> Models => models.AsReadOnly();

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
