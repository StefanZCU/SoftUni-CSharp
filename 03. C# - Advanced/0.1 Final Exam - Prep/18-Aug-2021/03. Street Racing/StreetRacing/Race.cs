using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public void Add(Car car)
        {
            if (Participants.FirstOrDefault(x => x.LicensePlate == car.LicensePlate) != null)
            {
                return;
            }

            if (car.HorsePower > MaxHorsePower)
            {
                return;
            }

            if (Capacity == Participants.Count)
            {
                return;
            }

            Participants.Add(car);
        }

        public bool Remove(string licensePlate)
        {
            var carToFind = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (carToFind == null)
            {
                return false;
            }

            Participants.Remove(carToFind);
            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            var carToFind = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return carToFind;
        }

        public Car GetMostPowerfulCar()
        {
            var carToFind = Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return carToFind;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var participant in Participants)
            {
                sb.AppendLine(participant.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
