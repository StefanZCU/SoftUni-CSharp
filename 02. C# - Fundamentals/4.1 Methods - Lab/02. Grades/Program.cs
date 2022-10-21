using System;
using System.Globalization;

namespace _02._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Grade(grade);
        }
        private static void Grade(double grade)
        {
            if (grade >= 2.00 && grade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (grade >= 3.00 && grade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (grade >= 3.5 && grade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 4.5 && grade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 5.5 && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
