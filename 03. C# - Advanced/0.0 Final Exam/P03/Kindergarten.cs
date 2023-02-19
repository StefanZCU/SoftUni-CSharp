using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public int ChildrenCount => Registry.Count;


        public bool AddChild(Child child)
        {
            if (Registry.Count == Capacity)
            {
                return false;
            }

            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] names = childFullName.Split();
            string firstName = names[0];
            string lastName = names[1];

            var childToRemove = Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (childToRemove == null) return false;
            Registry.Remove(childToRemove);
            return true;
        }

        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.Split();
            string firstName = names[0];
            string lastName = names[1];

            return Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
