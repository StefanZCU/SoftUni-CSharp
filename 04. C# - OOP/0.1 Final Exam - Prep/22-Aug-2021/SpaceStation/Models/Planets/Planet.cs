namespace SpaceStation.Models.Planets
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
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

        public ICollection<string> Items
        {
            get => items;
            set => items = value.ToList();
        }
    }
}
