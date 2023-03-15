namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;

    using Contracts;

    public class Backpack : IBag
    {
        public Backpack()
        {
            Items = new List<string>();
        }

        public ICollection<string> Items { get; }
    }
}
