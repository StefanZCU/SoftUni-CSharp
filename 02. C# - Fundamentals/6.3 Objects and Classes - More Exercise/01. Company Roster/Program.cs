using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01._Company_Roster
{
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;

        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }

    class AllEmployees
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<string> Departments { get; set; } = new List<string>();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numCycles = int.Parse(Console.ReadLine());
            AllEmployees employeeList = new AllEmployees();

            for (int i = 0; i < numCycles; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];

                if (employeeList.Employees.All(x => x.Department != department))
                {
                    employeeList.Departments.Add(department);
                }

                Employee employee = new Employee(name, salary, department);

                employeeList.Employees.Add(employee);
            }

            double highestSum = int.MinValue;
            string bestDpt = String.Empty;
            int counter = 0;
            double sum;
            double average;

            for (int i = 0; i < employeeList.Departments.Count; i++)
            {
                (sum, counter) = FindAverages(employeeList.Employees, employeeList.Departments[i], counter);

                average = sum / counter;

                if (average > highestSum)
                {
                    highestSum = average;
                    bestDpt = employeeList.Departments[i];
                }

                counter = 0;
            }

            Console.WriteLine($"Highest Average Salary: {bestDpt}");

            List<Employee> bestDepartments = new List<Employee>();

            for (int i = 0; i < employeeList.Employees.Count; i++)
            {
                if (employeeList.Employees[i].Department == bestDpt)
                {
                    bestDepartments.Insert(0, employeeList.Employees[i]);
                }
            }

            var orderedList = bestDepartments.OrderByDescending(x => x.Salary);

            foreach (var employee in orderedList)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }

        public static (double, int) FindAverages(List<Employee> employeeList, string currentDpt, int counter)
        {
            double currentSum = 0;

            foreach (var employee in employeeList)
            {
                if (employee.Department == currentDpt)
                {
                    currentSum += employee.Salary;
                    counter++;
                }
            }
            
            return (currentSum, counter);
        }
    }
}
