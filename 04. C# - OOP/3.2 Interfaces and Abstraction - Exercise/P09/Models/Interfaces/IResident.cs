namespace P09.Models.Interfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}
