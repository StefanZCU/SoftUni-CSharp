using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => this.fish.Count;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fishToRemove = fish.FirstOrDefault(x => x.Weight == weight);

            if (fishToRemove == null)
            {
                return false;
            }

            fish.Remove(fishToRemove);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            return this.fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(x => x.Length).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var fish1 in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish1.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
