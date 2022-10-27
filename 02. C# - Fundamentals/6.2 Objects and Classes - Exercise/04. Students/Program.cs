using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Program
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string firstName = command[0];
                string lastName = command[1];
                double grade = double.Parse(command[2]);

                Student currStudent = new Student(firstName, lastName, grade);

                studentList.Add(currStudent);
            }

            studentList = studentList.OrderByDescending(x => x.Grade).ToList();

            foreach (var student in studentList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }
    }
}