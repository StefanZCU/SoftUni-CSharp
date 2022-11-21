using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] students = Console.ReadLine().Split();

                if (!studentsGrades.ContainsKey(students[0]))
                {
                    studentsGrades.Add(students[0], new List<decimal>());
                    studentsGrades[students[0]].Add(decimal.Parse(students[1]));
                }
                else
                {
                    studentsGrades[students[0]].Add(decimal.Parse(students[1]));
                }
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var number in student.Value)
                {
                    Console.Write($"{number:f2} ");
                }

                Console.Write($"(avg: {student.Value.Average():F2})");
                Console.WriteLine();
            }

        }
    }
}
