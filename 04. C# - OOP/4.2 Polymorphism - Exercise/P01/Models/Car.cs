namespace Vehicles.Models;

using Interfaces;

public class Car : IVehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm + 0.9;
    }

    public double FuelQuantity { get; private set; }
    public double FuelConsumptionPerKm { get; private set; }

    public string Drive(double distance)
    {
        var fuelNeeded = FuelConsumptionPerKm * distance;

        if (FuelQuantity - fuelNeeded < 0) return "Car needs refueling";
        FuelQuantity -= fuelNeeded;
        return $"Car travelled {distance} km";
    }

    public void Refuel(double liters)
    {
        FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"Car: {FuelQuantity:F2}";
    }
}