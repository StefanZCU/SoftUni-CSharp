namespace Vehicles.Models
{
    using Exceptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelIncrement)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + fuelIncrement;
        }

        public string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new InvalidFuelAmount(string.Format(ExceptionMessages.InvalidFuelAmount, GetType().Name));
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual double Refuel(double liters)
        {
            return FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
