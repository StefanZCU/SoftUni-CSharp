namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void WeightIncreaser(int quantity)
        {
            Weight += quantity * 0.4;
        }
    }
}
