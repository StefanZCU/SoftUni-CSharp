using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneySaved = double.Parse(Console.ReadLine());

            int numberOfDaysSpent = 0;
            double moneySum = moneySaved;
            int numberOfDays = 0;

            while (moneySaved < moneyNeeded)
            {
                string spendOrSave = Console.ReadLine();
                double moneySpentOrSaved = double.Parse(Console.ReadLine());

                numberOfDays++;

                if (spendOrSave == "spend")
                {
                    numberOfDaysSpent++;
                    moneySum -= moneySpentOrSaved;

                    if (moneySum <= 0.0)
                    {
                        moneySum = 0.0;
                    }
                    if (numberOfDaysSpent == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{numberOfDays}");
                        break;
                    }
                }

                if (spendOrSave == "save")
                {
                    numberOfDaysSpent = 0;
                    moneySum += moneySpentOrSaved;

                    if (moneySum >= moneyNeeded)
                    {
                        Console.WriteLine($"You saved the money for {numberOfDays} days.");
                        break;
                    }
                }
            }
        }
    }
}
