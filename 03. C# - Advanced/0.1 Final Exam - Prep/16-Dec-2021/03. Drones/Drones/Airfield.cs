using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => this.Drones.Count;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || (drone.Range < 5 || drone.Range > 15))
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = Drones.FirstOrDefault(x => x.Name == name);

            if (droneToRemove == null)
            {
                return false;
            }

            Drones.Remove(droneToRemove);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int dronesRemoved = 0;

            while (Drones.FirstOrDefault(x => x.Brand == brand) != null)
            {
                var droneToRemove = Drones.FirstOrDefault(x => x.Brand == brand);
                Drones.Remove(droneToRemove);
                dronesRemoved++;
            }

            return dronesRemoved;
        }

        public Drone FlyDrone(string name)
        {
            var droneToFly = Drones.FirstOrDefault(x => x.Name == name);

            if (droneToFly != null)
            {
                droneToFly.Available = false;
                return droneToFly;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToReturn = new List<Drone>();

            foreach (var drone in Drones.Where(x => x.Range >= range).Where(y => y.Available))
            {
                drone.Available = false;
                dronesToReturn.Add(drone);
            }

            return dronesToReturn;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in Drones.Where(x => x.Available))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
