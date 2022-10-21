using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i < num; i++)
            {
                if (GetSumOfDigits(i))
                {
                    if (FindOddDigit(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }

        static bool GetSumOfDigits(int num)
        {
            int sum = 0;
            int currentDigit;
            string numberLength = num.ToString();

            for (int i = 0; i < numberLength.Length; i++)
            {
                currentDigit = num % 10;
                sum += currentDigit;
                currentDigit = num - (num % 10);
                num = num / 10;
            }
            

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;

        }

        static bool FindOddDigit(int num)
        {
            int currentDigit;

            string numberLength = num.ToString();

            for (int i = 0; i < numberLength.Length; i++)
            {
                currentDigit = num % 10;

                if (currentDigit % 2 == 1)
                {
                    return true;
                }
                else
                {
                    currentDigit = num - (num % 10);
                    num = num / 10;
                }
            }

            return false;
        }
    }
}
