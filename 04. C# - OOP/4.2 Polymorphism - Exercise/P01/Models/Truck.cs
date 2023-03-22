namespace Vehicles.Models
{
    using Interfaces;

    public class Truck : IVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm + 1.6;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public string Drive(double distance)
        {
            var fuelNeeded = FuelConsumptionPerKm * distance;

            if (FuelQuantity - fuelNeeded < 0) return "Truck needs refueling";
            FuelQuantity -= fuelNeeded;
            return $"Truck travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:F2}";
        }
    }
}
