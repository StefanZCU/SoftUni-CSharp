namespace VehiclesExtension.Models
{
    using Interfaces;

    internal class Bus : Vehicle, IBus
    {
        private const double FuelIncrement = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + FuelIncrement, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            FuelConsumption -= FuelIncrement;
            return base.Drive(distance);
        }
    }
}
