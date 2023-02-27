namespace VehiclesExtension.Models
{
    using Exceptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new NotEnoughFuelForDrive(string.Format(ExceptionMessages.NotEnoughFuelForDrive, GetType().Name));
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual double Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new FuelIsNotPositiveNumber(ExceptionMessages.FuelIsNotPositiveNumber);
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new NotEnoughTankCapacity(string.Format(ExceptionMessages.NotEnoughTankCapacity, liters));
            }

            FuelQuantity += liters;
            return FuelQuantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
