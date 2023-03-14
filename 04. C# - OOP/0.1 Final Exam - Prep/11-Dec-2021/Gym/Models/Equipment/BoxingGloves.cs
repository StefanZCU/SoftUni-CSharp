namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double WEIGHT = 227.0;
        private const decimal PRICE = 120.0m;

        public BoxingGloves() : base(WEIGHT, PRICE)
        {
        }
    }
}
