using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gamesLost = double.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalExpenses = 0.0;
            double keyboardCounter = 0.0;

            for (int i = 1; i <= gamesLost; i++)
            {
                if (i % 2 == 0)
                {
                    totalExpenses += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    totalExpenses += mousePrice;
                }
                if (i % 3 == 0 && i % 2 == 0)
                {
                    totalExpenses += keyboardPrice;
                    keyboardCounter++;

                    if (keyboardCounter % 2 == 0)
                    {
                        totalExpenses += displayPrice;
                    }
                }
                
            }

            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
