namespace FoodShortage.Models
{
    using Interfaces;

    public class Rebel : IBuyer
    {
        public void BuyFood()
        {
            Food += 5;
        }

        public int Food { get; private set; }
        public string Name { get; }

        public Rebel(string name)
        {
            Name = name;
        }
    }
}
