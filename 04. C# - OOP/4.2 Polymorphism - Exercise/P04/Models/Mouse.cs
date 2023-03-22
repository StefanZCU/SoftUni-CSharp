namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void WeightIncreaser(int quantity)
        {
            Weight += quantity * 0.1;
        }
    }
}
