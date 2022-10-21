using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            double totalSum = 0.0;
            double tempSum = 1.0;


            double tempNum = double.Parse(num);

            

            for (int i = 1; i <= num.Length; i++)
            {
                double newNum = tempNum % 10;

                for (double j = newNum; j >= 1; j--)
                {
                    tempSum *= j;
                }

                totalSum += tempSum;
                tempSum = 1.0;
                tempNum = Math.Floor(tempNum / 10.0);
            }

            if (totalSum == double.Parse(num))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}



