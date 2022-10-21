using System;

namespace _03._Numbers_1___N_with_Step_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num2 = int.Parse(Console.ReadLine());
            for (int number = 1; num2 >= number; number += 3)
            {
                Console.WriteLine(number);
            }
        }
    }
}
