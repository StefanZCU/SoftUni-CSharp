using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Student
    {
        public string Name { get; set; }
        public Dictionary<string, int> Grades { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.Grades = new Dictionary<string, int>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsPerContest = new Dictionary<string, string>();

            List<Student> students = new List<Student>();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] input = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                passwordsPerContest.Add(input[0], input[1]);
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);


                if (passwordsPerContest.ContainsKey(contest) && passwordsPerContest[contest] == password)
                {
                    if (students.All(s => s.Name != username))
                    {
                        Student currentStudent = new Student(username);
                        students.Add(currentStudent);

                        foreach (var student in students)
                        {
                            if (student.Name == username)
                            {
                                student.Grades.Add(contest, points);
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var student in students)
                        {
                            if (student.Name == username && student.Grades.ContainsKey(contest))
                            {
                                if (points > student.Grades[contest])
                                {
                                    student.Grades[contest] = points;
                                }

                                break;
                            }

                            if (student.Name == username)
                            {
                                student.Grades.Add(contest, points);
                                break;
                            }
                        }
                    }
                }
            }

            int mostPoints = int.MinValue;
            string bestStudent = string.Empty;

            foreach (var student in students)
            {
                if (student.Grades.Values.Sum() > mostPoints)
                {
                    bestStudent = student.Name;
                    mostPoints = student.Grades.Values.Sum();
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {mostPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine($"{student.Name}");
                foreach (var grade in student.Grades.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {grade.Key} -> {grade.Value}");
                }
            }
        }
    }
}
