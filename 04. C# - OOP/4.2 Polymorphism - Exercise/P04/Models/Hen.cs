namespace WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void WeightIncreaser(int quantity)
        {
            Weight += quantity * 0.35;
        }
    }
}
