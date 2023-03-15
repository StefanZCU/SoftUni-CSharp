namespace SpaceStation.Models.Astronauts
{
    using System;

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
    }
}
