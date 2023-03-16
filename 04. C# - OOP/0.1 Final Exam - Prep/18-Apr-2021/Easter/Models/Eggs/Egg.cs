namespace Easter.Models.Eggs
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get => energyRequired;
            private set => energyRequired = value < 0 ? 0 : value;
        }
        public void GetColored()
        {
            EnergyRequired -= 10;
        }

        public bool IsDone() => energyRequired == 0;
    }
}
