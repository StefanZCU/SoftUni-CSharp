namespace WildFarm.Models
{
    using Interfaces;

    public abstract class Animal : IAnimal
    {
        private readonly Dictionary<string, List<string>> foodPerAnimal = new Dictionary<string, List<string>>()
        {
            { "Hen", new List<string>() { "Vegetable", "Fruit", "Meat", "Seeds" } },
            { "Mouse", new List<string>() { "Vegetable", "Fruit" } },
            { "Cat", new List<string>() { "Vegetable", "Meat" } },
        };


        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; private set; }
        public abstract string ProduceSound();
        public bool CheckIfAnimalWillEat(string food)
        {
            var animalType = GetType().Name;

            if (foodPerAnimal.ContainsKey(animalType))
            {
                if (foodPerAnimal[animalType].Contains(food))
                {
                    return true;
                }
            }
            else if (!foodPerAnimal.ContainsKey(animalType))
            {
                if (food is "Meat")
                {
                    return true;
                }
            }

            return false;
        }
        public abstract void WeightIncreaser(int quantity);
        public void QuantityIncreaser(int quantity)
        {
            FoodEaten += quantity;
        }
    }
}
