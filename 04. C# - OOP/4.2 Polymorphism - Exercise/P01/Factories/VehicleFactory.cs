namespace Vehicles.Factories
{
    using Models;
    using Interfaces;
    using Vehicles.Models.Interfaces;

    internal class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQty, double fuelConsumption)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption);
            }
            else 
            {
                vehicle = new Truck(fuelQty, fuelConsumption);
            }

            return vehicle;
        }
    }
}
