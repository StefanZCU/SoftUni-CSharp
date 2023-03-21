namespace P06.Models.Interfaces
{
    public interface IBuyer : INameable
    {
        int Food { get; }
        void BuyFood();
    }
}
