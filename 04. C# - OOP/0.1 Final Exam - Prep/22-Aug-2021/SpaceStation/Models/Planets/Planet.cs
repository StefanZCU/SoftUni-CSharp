namespace SpaceStation.Models.Planets
{
    using System.Collections.Generic;
    using System;

    using Utilities.Messages;
    using Contracts;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            Name = name;
            Items = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public ICollection<string> Items { get; }
    }
}
