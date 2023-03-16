namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set => power = value < 0 ? 0 : value;
        }
        public void Use()
        {
            Power -= 10;
        }

        public bool IsFinished() => Power == 0;
    }
}
