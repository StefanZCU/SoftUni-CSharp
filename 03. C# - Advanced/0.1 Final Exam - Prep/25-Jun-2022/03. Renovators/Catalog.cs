using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var targetRenovator = this.renovators.FirstOrDefault(x => x.Name == name);
            if (targetRenovator == null)
            {
                return false;
            }
            this.renovators.Remove(targetRenovator);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovators = 0;

            while (this.renovators.FirstOrDefault(x => x.Type == type) != null)
            {
                var renovatorToRemove = this.renovators.FirstOrDefault(x => x.Type == type);
                removedRenovators++;
                this.renovators.Remove(renovatorToRemove);
            }

            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            if (this.renovators.FirstOrDefault(x => x.Name == name) != null)
            {
                 var renovatorToHire = this.renovators.FirstOrDefault(x => x.Name == name);
                 renovatorToHire.Hired = true;
                 return renovatorToHire;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators.Where(x => x.Hired != true))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
