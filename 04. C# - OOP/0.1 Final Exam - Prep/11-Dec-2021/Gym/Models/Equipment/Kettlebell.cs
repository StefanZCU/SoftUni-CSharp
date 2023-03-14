namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double WEIGHT = 10000.0;
        private const decimal PRICE = 80.0m;

        public Kettlebell() : base(WEIGHT, PRICE)
        {
        }
    }
}
