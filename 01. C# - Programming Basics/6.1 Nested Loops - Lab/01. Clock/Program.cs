using System;

namespace _01._Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 23;
            int num2 = 59;

            for (int i = 0; i <= num1; i++)
            {
                for (int j = 0; j <= num2; j++)
                {
                    Console.WriteLine($"{i}:{j}");
                }
            }
        }
    }
}
