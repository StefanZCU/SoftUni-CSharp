namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double FUEL_AVAILABLE = 65;
        private const double FUEL_CONSUMPTION_PER_RACE = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, FUEL_AVAILABLE, FUEL_CONSUMPTION_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower -= Convert.ToInt32(HorsePower * 0.03);
        }
    }
}
