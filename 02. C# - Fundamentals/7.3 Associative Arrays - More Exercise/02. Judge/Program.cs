using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _02._Judge
{
    class Student
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Student(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Student>> contests = new Dictionary<string, List<Student>>();

            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new List<Student>());
                }

                var student = contests[contest].FirstOrDefault(student => student.Name == username);
                if (student != null && student.Points < points)
                {
                    student.Points = points;
                }
                else if (student == null)
                {
                    student = new Student(username, points);
                    contests[contest].Add(student);
                }
            }

            Dictionary<string, int> studentPoints = new Dictionary<string, int>();

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int counter = 1;

                foreach (var student in contest.Value.OrderByDescending(student => student.Points).ThenBy(student => student.Name))
                {
                    if (!studentPoints.ContainsKey(student.Name))
                    {
                        studentPoints.Add(student.Name, 0);
                    }
                    studentPoints[student.Name] += student.Points;

                    Console.WriteLine($"{counter++}. {student.Name} <::> {student.Points}");
                }
            }

            Console.WriteLine("Individual standings:");

            int secondCounter = 1;
            foreach (var student in studentPoints.OrderByDescending(stud => stud.Value).ThenBy(stud => stud.Key))
            {
                Console.WriteLine($"{secondCounter++}. {student.Key} -> {student.Value}");
            }

        }
    }
}