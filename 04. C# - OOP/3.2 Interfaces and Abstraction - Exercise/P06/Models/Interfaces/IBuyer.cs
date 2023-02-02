namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer : IIdentifier
    {
        public void BuyFood();

        public int Food { get; }
    }
}
