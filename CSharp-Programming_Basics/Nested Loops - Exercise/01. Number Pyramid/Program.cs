using System;

namespace _01._Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rowCounter = 1;
            int numbersInRow = 1;
            int currentNumber = 1;

            while (currentNumber <= n)
            {
                if (numbersInRow <= rowCounter)
                {
                    numbersInRow++;
                    Console.Write(currentNumber + " ");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(currentNumber + " ");
                    rowCounter++;
                    numbersInRow = 2;
                }
                currentNumber++;

            }
        }
    }
}
