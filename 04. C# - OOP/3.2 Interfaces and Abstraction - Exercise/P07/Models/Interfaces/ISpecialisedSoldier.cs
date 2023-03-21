namespace P07.Models.Interfaces
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
