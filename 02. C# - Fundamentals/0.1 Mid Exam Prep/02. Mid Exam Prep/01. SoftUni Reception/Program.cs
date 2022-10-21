using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());


            int totalEfficiencyPerHour = employee1 + employee2 + employee3;
            int counter = 0;

            for (int i = 0; i < Math.Ceiling((double)studentCount / totalEfficiencyPerHour); i++)
            {
                counter++;

                if (counter % 4 == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine($"Time needed: {counter}h.");
        }
    }
}