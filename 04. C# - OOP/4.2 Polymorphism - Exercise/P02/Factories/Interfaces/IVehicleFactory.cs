namespace VehiclesExtension.Factories.Interfaces
{
    using VehiclesExtension.Models.Interfaces;

    public interface IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQty, double fuelConsumption, double tankCapacity);
    }
}
