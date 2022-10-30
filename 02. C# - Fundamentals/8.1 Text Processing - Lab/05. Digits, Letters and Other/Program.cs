using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder nums = new StringBuilder();
            StringBuilder words = new StringBuilder();
            StringBuilder symbols = new StringBuilder();
            
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    nums.Append(word[i]);
                }
                else if (char.IsLetter(word[i]))
                {
                    words.Append(word[i]);
                }
                else
                {
                    symbols.Append(word[i]);
                }
            }

            Console.WriteLine(nums);
            Console.WriteLine(words);
            Console.WriteLine(symbols);
        }
    }
}
