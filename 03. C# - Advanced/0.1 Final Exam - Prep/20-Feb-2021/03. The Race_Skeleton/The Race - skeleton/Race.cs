using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public void Add(Racer Racer)
        {
            if (data.Count != Capacity)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            foreach (var racer in data)
            {
                if (racer.Name == name)
                {
                    data.Remove(racer);
                    return true;
                }
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).First();
        }

        public string Report()
        {
            return $"Racers participating at {Name}:\n{string.Join("\n", data)}";
        }

    }
}
