namespace AquaShop.Models.Decorations
{
    using Contracts;

    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort { get; }
        public decimal Price { get; }
    }
}
