using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            int sum = 0;

            if (words[0].Length > words[1].Length)
            {
                for (int i = 0; i < words[1].Length; i++)
                {
                    sum += GetSum(words[0][i], words[1][i]);
                }

                for (int i = words[1].Length; i < words[0].Length; i++)
                {
                    sum += words[0][i];
                }
            }
            else if (words[0].Length < words[1].Length)
            {
                for (int i = 0; i < words[0].Length; i++)
                {
                    sum += GetSum(words[0][i], words[1][i]);
                }

                for (int i = words[0].Length; i < words[1].Length; i++)
                {
                    sum += words[1][i];
                }
            }
            else
            {
                for (int i = 0; i < words[1].Length; i++)
                {
                    sum += GetSum(words[0][i], words[1][i]);
                }
            }

            Console.WriteLine(sum);
        }

        public static int GetSum(char char1, char char2)
        {
            int sum = char1 * char2;
            return sum;
        }
        
    }
}
