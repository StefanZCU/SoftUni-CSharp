namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Easter.Models.Dyes.Contracts;

    public abstract class Bunny : IBunny
    {
        private string name;
        private List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }
        public int Energy { get; protected set; }
        public ICollection<IDye> Dyes => dyes;

        public abstract void Work();

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
    }
}
