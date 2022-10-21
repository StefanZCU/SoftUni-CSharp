using System;

namespace _05._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                decimal minBudget = decimal.Parse(Console.ReadLine());
                decimal moneySaved = 0;

                while (true)
                {
                    decimal newMoney = decimal.Parse(Console.ReadLine());
                    moneySaved += newMoney;

                    if (moneySaved >= minBudget)
                    {
                        Console.WriteLine($"Going to {command}!");
                        break;
                    }
                }
            }
        }
    }
}
