using System;
using System.Runtime.ExceptionServices;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0.0;
            double currentSum = 0.0;

            char firstLetter = ' ';
            char lastLetter = ' ';
            
            StringBuilder nums = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 1; i < word.Length - 1; i++)
                {
                    firstLetter = word[0];
                    lastLetter = word[word.Length - 1];

                    nums.Append(word[i]);
                }

                currentSum = double.Parse(nums.ToString());

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    double newNum = (double)firstLetter - 64.0;
                    currentSum /= newNum;
                }
                else
                {
                    double newNum = (double)firstLetter - 96.0;
                    currentSum *= newNum;
                }

                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    double newNum = (double)lastLetter - 64.0;
                    currentSum -= newNum;
                }
                else
                {
                    double newNum = (double)lastLetter - 96.0;
                    currentSum += newNum;
                }

                totalSum += currentSum;
                nums.Remove(0, nums.Length);
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
