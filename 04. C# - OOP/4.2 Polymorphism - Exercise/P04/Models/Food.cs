namespace WildFarm.Models
{
    using Interfaces;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; }

    }
}
