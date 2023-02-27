namespace FoodShortage.Models
{
    using Interfaces;

    public class Citizen : IBuyer
    {
        public void BuyFood()
        {
            Food += 10;
        }

        public int Food { get; private set; }
        public string Name { get; }

        public Citizen(string name)
        {
            Name = name;
        }
    }
}
