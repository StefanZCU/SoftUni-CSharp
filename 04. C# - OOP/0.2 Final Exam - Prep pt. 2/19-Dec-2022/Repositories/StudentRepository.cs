namespace UniversityCompetition.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using UniversityCompetition.Models.Contracts;

    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models;
        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(" ");
            return models.FirstOrDefault(x => x.FirstName == fullName[0] && x.LastName == fullName[1]);
        }
    }
}
