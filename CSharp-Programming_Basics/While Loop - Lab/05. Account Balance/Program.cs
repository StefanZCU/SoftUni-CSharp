using System;

namespace _05._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.0;

            while (true)
            {
                string num = Console.ReadLine();
                

                if (num == "NoMoreMoney")
                {
                    Console.WriteLine($"Total: {sum:F2}");
                    break;
                }

                double num1 = double.Parse(num);

                if (num1 <= 0.0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {sum:F2}");
                    break;
                }

                sum += num1;
                Console.WriteLine($"Increase: {num1:F2}");
            }
        }
    }
}
