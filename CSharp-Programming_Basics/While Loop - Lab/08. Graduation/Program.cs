using System;

namespace _08._Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string name = Console.ReadLine();

            int numberOfGrades = 0;
            double sumGrades = 0.0;
            double gradeComparing = 0.0;

            while (true)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.0)
                {
                    if (gradeComparing != 0.0)
                    {
                        Console.WriteLine($"{name} has been excluded at {numberOfGrades} grade");
                        break;
                    }
                    gradeComparing = grade;
                }

                numberOfGrades++;
                sumGrades += grade;
                double average = sumGrades / numberOfGrades;

                if ((average >= 4.0) && (numberOfGrades == 12))
                {
                    Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
                    break;
                }
            }
        }
    }
}
