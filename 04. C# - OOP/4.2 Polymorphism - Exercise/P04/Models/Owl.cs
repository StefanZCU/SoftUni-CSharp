namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }
        
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void WeightIncreaser(int quantity)
        {
            Weight += quantity * 0.25;
        }
    }
}
