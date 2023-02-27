namespace VehiclesExtension.Factories
{
    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQty, double fuelConsumption, double tankCapacity)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }
            else
            {
                vehicle = new Truck(fuelQty, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
