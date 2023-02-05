namespace Animals.Models
{
    using System.Text;

    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("MEEOW");

            return sb.ToString().TrimEnd();
        }
    }
}
