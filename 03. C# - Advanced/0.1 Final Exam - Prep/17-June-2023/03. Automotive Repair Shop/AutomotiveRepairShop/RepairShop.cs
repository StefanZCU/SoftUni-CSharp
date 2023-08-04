using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle foundCar = Vehicles.FirstOrDefault(x => x.VIN == vin);

            if (foundCar == null) return false;
            
            Vehicles.Remove(foundCar);
            return true;
        }

        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage()
        {
            return Vehicles.OrderBy(x => x.Mileage).First();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
