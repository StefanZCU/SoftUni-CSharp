namespace AquaShop.Models.Decorations
{
    public class Plant: Decoration
    {
        private const int COMFORT = 5;
        private const int PRICE = 10;
        public Plant() : base(COMFORT, PRICE)
        {
        }
    }
}
