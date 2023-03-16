namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int INITIAL_ENERGY = 100;
        public HappyBunny(string name) : base(name, INITIAL_ENERGY)
        {
        }

        public override void Work()
        {
            Energy = Energy - 10 < 0
                ? 0
                : Energy - 10;
        }
    }
}
