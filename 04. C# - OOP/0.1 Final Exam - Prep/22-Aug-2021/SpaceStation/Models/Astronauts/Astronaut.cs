namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;

    using Bags;
    using Contracts;
    using Utilities.Messages;
    using SpaceStation.Models.Bags.Contracts;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen != 0;
        public IBag Bag { get; }
        public virtual void Breath()
        {
            Oxygen = Oxygen - 10 < 0 
                ? 0 
                : Oxygen - 10;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"Name: {Name}")
                .AppendLine($"Oxygen: {Oxygen}")
                .AppendLine(Bag.Items.Count > 0 ? $"Bag items: {string.Join(", ", Bag.Items)}" : "Bag items: none");

            return sb.ToString().TrimEnd();
        }
    }
}
