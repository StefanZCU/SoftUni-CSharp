using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            int numLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double totalBonus = 0;
            double currentStudentBonus;
            int mostLectures = 0;

            for (int i = 0; i < numStudents; i++)
            {
                int attendanceStudent = int.Parse(Console.ReadLine());

                currentStudentBonus = Math.Ceiling((double)attendanceStudent / numLectures * (5.0 + additionalBonus));

                if (currentStudentBonus > totalBonus)
                {
                    totalBonus = currentStudentBonus;
                    mostLectures = attendanceStudent;
                    currentStudentBonus = 0;
                }
            }

            Console.WriteLine($"Max Bonus: {totalBonus}.");
            Console.WriteLine($"The student has attended {mostLectures} lectures.");
        }
    }
}