using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (Capacity != data.Count)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = null;

            foreach (var ski in data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    skiToRemove = ski;
                }
            }

            if (skiToRemove == null)
            {
                return false;
            }

            data.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
        {
            var skiToFind = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return skiToFind;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            foreach (var ski in data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    return ski;
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
