namespace VehiclesExtension.Models
{
    using Exceptions;

    public class Truck : Vehicle
    {
        private const double FuelIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + FuelIncrement, tankCapacity)
        {
        }

        public override double Refuel(double liters)
        {
            try
            {
                return base.Refuel(liters * 0.95);
            }
            catch (NotEnoughTankCapacity NETC)
            {
                return base.Refuel(liters); 
            }
        }
    }
}
