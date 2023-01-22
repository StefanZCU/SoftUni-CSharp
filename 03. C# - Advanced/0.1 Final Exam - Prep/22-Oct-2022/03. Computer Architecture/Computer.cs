using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ComputerArchitecture
{
    public class Computer
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => Multiprocessor.Count;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count == Capacity)
            {
                return;
            }

            Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(x => x.Brand.ToLower() == brand.ToLower()))
            {
                Multiprocessor.Remove(Multiprocessor.Find(x => x.Brand.ToLower() == brand.ToLower()));
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.Find(x => x.Brand.ToLower() == brand.ToLower());
        }

        public string Report()
        {
            return $"CPUs in the Computer {Model}:\n{string.Join("\n", Multiprocessor)}";
        }
    }
}
