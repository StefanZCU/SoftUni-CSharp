namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Formula1.Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();
        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
        {
            var carToRemove = models.FirstOrDefault(x => x.Model == model.Model);
            if (carToRemove == null) return false;

            models.Remove(carToRemove);
            return true;
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }
    }
}
