namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public abstract class Aquarium: IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort => Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            var fishToRemove = Fish.FirstOrDefault(x => x.Name == fish.Name);
            if (fishToRemove == null) return false;
            Fish.Remove(fishToRemove);
            return true;
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{Name} ({GetType().Name}):")
                .AppendLine(Fish.Count > 0 ? $"Fish: {string.Join(", ", Fish.Select(x => x.Name))}" : "Fish: none")
                .AppendLine($"Decorations: {Decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
