namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using CarRacing.Models.Racers.Contracts;

    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models;
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            var racerToRemove = models.FirstOrDefault(x => x.Username == model.Username);
            if (racerToRemove == null) return false;
            models.Remove(racerToRemove);
            return true;
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);
        }
    }
}
