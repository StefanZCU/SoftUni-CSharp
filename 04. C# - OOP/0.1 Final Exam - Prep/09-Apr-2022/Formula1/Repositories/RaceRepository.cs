namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Formula1.Models.Contracts;

    public class RaceRepository: IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();
        public void Add(IRace model)
        {
            models.Add(model);
        }

        public bool Remove(IRace model)
        {
            var raceToRemove = models.FirstOrDefault(x => x.RaceName == model.RaceName);
            if (raceToRemove == null) return false;
            models.Remove(raceToRemove);
            return true;
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
        }
    }
}
