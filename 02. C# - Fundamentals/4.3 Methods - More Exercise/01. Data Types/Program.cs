using System;

namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int num = int.Parse(Console.ReadLine());
                GetInt(num);
            }
            else if (input == "real")
            {
                double floatNum = double.Parse(Console.ReadLine());
                GetFloatingPoint(floatNum);
            }
            else if (input == "string")
            {
                string word = Console.ReadLine();
                GetString(word);
            }
        }

        static void GetInt(int num)
        {
            Console.WriteLine(num * 2);
        }
        static void GetFloatingPoint(double num)
        {
            Console.WriteLine($"{num * 1.5:F2}");
        }
        static void GetString(string word)
        {
            Console.WriteLine($"${word}$");
        }
    }
}
