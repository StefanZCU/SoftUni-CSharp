namespace P02.Factories.Interfaces
{
    using P02.Models.Interfaces;

    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
