namespace Gym.Models.Equipment
{
    using Contracts;

    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; }
        public decimal Price { get; }
    }
}
