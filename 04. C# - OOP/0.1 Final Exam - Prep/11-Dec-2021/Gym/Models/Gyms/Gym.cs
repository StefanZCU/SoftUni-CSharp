using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }
        public int Capacity { get; }
        public ICollection<IEquipment> Equipment { get; }
        public ICollection<IAthlete> Athletes { get; }
        public double EquipmentWeight => Equipment.Sum(x => x.Weight);
        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            var athleteToRemove = Athletes.FirstOrDefault(x => x.FullName == athlete.FullName);
            if (athleteToRemove == null) return false;
            Athletes.Remove(athleteToRemove);
            return true;
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine(Athletes.Count > 0
                    ? $"Athletes: {string.Join(", ", Athletes.Select(x => x.FullName))}"
                    : "Athletes: No athletes")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
