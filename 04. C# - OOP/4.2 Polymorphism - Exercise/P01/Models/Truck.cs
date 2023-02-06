namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, FuelIncrement)
        {
        }

        public override double Refuel(double liters)
        {
            return base.Refuel(liters * 0.95);
        }
    }
}
