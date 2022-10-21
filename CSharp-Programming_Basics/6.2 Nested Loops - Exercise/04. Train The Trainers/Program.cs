using System;

namespace _04._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberJury = int.Parse(Console.ReadLine());

            double sumAll = 0;
            double gradesCount = 0;
            double countPerPresentation = 0;
            double gradePerPresentation = 0.0;



            while (true)
            {
                string presentationName = Console.ReadLine();


                if (presentationName == "Finish")
                {
                    double totalAverage = sumAll / gradesCount;
                    Console.WriteLine($"Student's final assessment is {totalAverage:F2}.");
                    break;
                }

                for (int i = 1; i <= numberJury; i++)
                {
                    double currentGrade = double.Parse(Console.ReadLine());

                    gradePerPresentation += currentGrade;
                    countPerPresentation++;
                    sumAll += currentGrade;
                    gradesCount++;

                    if (countPerPresentation == numberJury)
                    {
                        countPerPresentation = 0;
                        double averagePerPresentation = gradePerPresentation / numberJury;

                        Console.WriteLine($"{presentationName} - {averagePerPresentation:F2}.");
                        gradePerPresentation = 0;
                        break;
                    }

                }
            }
        }
    }
}
