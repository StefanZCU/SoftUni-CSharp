using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (data.Count != Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            var personToRemove = data.FirstOrDefault(x => x.Name == name);
            if (personToRemove != null)
            {
                data.Remove(personToRemove);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
