using System;

namespace _05._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal moneyNeeded = decimal.Parse(Console.ReadLine());

            int moneyCounter = 0;

            while (moneyNeeded > 0.0m)
            {
                if (moneyNeeded - 2.0m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 2.0m;
                }
                else if (moneyNeeded - 1.0m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 1.0m;
                }
                else if (moneyNeeded - 0.5m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.5m;
                }
                else if (moneyNeeded - 0.2m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.2m;
                }
                else if (moneyNeeded - 0.1m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.1m;
                }
                else if (moneyNeeded - 0.05m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.05m;
                }
                else if (moneyNeeded - 0.02m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.02m;
                }
                else if (moneyCounter - 0.01m >= 0)
                {
                    moneyCounter++;
                    moneyNeeded -= 0.01m;
                }

                if (moneyNeeded <= 0)
                {
                    Console.WriteLine(moneyCounter);
                    break;
                }

            }
        }
    }
}
