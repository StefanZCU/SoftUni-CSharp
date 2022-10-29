using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPairs = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> gradesPerStudent = new Dictionary<string, List<double>>();

            for (int i = 0; i < numPairs; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradesPerStudent.ContainsKey(studentName))
                {
                    gradesPerStudent.Add(studentName, new List<double>());
                    gradesPerStudent[studentName].Add(grade);
                }
                else
                {
                    gradesPerStudent[studentName].Add(grade);
                }
            }

            foreach (var student in gradesPerStudent)
            {
                if (student.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                }
            }
        }
    }
}
