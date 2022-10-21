using System;

namespace _02._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badGradesAllowed = int.Parse(Console.ReadLine());

            double average = 0.0;
            int numberOfProblems = 0;
            string lastProblem = "";
            int badGrades = 0;
            double gradesSum = 0.0;



            while (true)
            {
                string problemName = Console.ReadLine();


                if (problemName == "Enough")
                {
                    average = gradesSum / numberOfProblems;
                    Console.WriteLine($"Average score: {average:F2}");
                    Console.WriteLine($"Number of problems: {numberOfProblems}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }

                int grade = int.Parse(Console.ReadLine());
                lastProblem = problemName;
                numberOfProblems++;
                gradesSum += grade;
                average = gradesSum / numberOfProblems;

                if (grade <= 4)
                {
                    badGrades++;
                }
                if (badGrades == badGradesAllowed)
                {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    break;
                }
            }
        }
    }
}
