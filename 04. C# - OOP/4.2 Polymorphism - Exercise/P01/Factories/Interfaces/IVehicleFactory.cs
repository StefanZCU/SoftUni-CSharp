namespace Vehicles.Factories.Interfaces
{
    using Vehicles.Models.Interfaces;
    public interface IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQty, double fuelConsumption);
    }
}
