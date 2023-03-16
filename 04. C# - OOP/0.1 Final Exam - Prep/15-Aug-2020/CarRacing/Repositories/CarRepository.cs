namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;

    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;
        public CarRepository()
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            var carToRemove = models.FirstOrDefault(x => x.VIN == model.VIN);
            if (carToRemove == null) return false;
            models.Remove(carToRemove);
            return true;
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(x => x.VIN == property);
        }
    }
}
