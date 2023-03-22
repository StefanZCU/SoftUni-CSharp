namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string ProduceSound();
        bool CheckIfAnimalWillEat(string food);
        void WeightIncreaser(int quantity);
        void QuantityIncreaser(int quantity);
    }
}
