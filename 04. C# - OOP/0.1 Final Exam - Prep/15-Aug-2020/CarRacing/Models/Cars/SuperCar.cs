namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FUEL_AVAILABLE = 80;
        private const double FUEL_CONSUMPTION_PER_RACE = 10;

        public SuperCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, FUEL_AVAILABLE, FUEL_CONSUMPTION_PER_RACE)
        {
        }
    }
}
