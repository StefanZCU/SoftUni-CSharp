using System;
using System.Collections.Generic;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersPerCourse = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = input[0];
                string studentName = input[1];

                if (!usersPerCourse.ContainsKey(courseName))
                {
                    usersPerCourse.Add(courseName, new List<string>());
                    usersPerCourse[courseName].Add(studentName);
                }
                else
                {
                    usersPerCourse[courseName].Add(studentName);
                }
            }

            foreach (var course in usersPerCourse)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var user in course.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
