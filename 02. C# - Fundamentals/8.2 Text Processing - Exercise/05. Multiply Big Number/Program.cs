using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder result = new StringBuilder();

            int overflowNum = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int bigNumDigit = int.Parse(bigNum[i].ToString());

                int product = bigNumDigit * multiplier + overflowNum;

                int resultDigit = product % 10;

                overflowNum = product / 10;
                result.Insert(0, resultDigit);
            }

            if (overflowNum != 0)
            {
                result.Insert(0, overflowNum);
            }
            
            Console.WriteLine(result);
        }
    }
}