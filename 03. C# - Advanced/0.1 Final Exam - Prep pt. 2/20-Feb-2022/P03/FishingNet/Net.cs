using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Fish> Fish => fish;
        public int Count => fish.Count;

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
            var fishToRelease = fish.FirstOrDefault(x => x.Weight == weight);

            if (fishToRelease == null) return false;
            fish.Remove(fishToRelease);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var fish1 in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish1.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
