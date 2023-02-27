namespace MilitaryElite.Models.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
    }
}
