using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int absNum = Math.Abs(int.Parse(input));

            int evenSum = GetSumOfEvenDigits(absNum);
            int oddSum = GetSumOfOddDigits(absNum);

            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        private static int GetSumOfOddDigits(int input)
        {
            int sum = 0;

            string input1 = input.ToString();

            for (int i = 0; i < input1.Length; i++)
            {
                int currentNum = int.Parse(input1[i].ToString());

                if (currentNum % 2 == 1)
                {
                    sum += currentNum;
                }
            }

            return sum;
        }

        private static int GetSumOfEvenDigits(int input)
        {
            int sum = 0;

            string input1 = input.ToString();

            for (int i = 0; i < input1.Length; i++)
            {
                int currentNum = int.Parse(input1[i].ToString());

                if (currentNum % 2 == 0)
                {
                    sum += currentNum;
                }
            }

            return sum;
        }
    }
}
