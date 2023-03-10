namespace NavalVessels.Repositories
{
    using System.Linq;  
    using System.Collections.Generic;

    using Contracts;
    using NavalVessels.Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();
        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public bool Remove(IVessel model)
        {
            var vesselToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (vesselToRemove == null) return false;

            models.Remove(vesselToRemove);
            return true;
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
