namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using UniversityCompetition.Models.Contracts;
    using Contracts;

    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models.AsReadOnly();
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

            string firstName = fullName[0];
            string lastName = fullName[1];

            return models.FirstOrDefault(student => student.FirstName == firstName && student.LastName == lastName);
        }
    }
}
