using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int result = GetVowels(word);

            Console.WriteLine(result);
        }

        static int GetVowels(string word)
        {
            int vowelCnt = 0;
            char[] chars = new char[] {'a', 'e', 'i', 'o', 'u'};

            foreach (char vowel in word.ToLower())
            {
                if (chars.Contains(vowel))
                {
                    vowelCnt++;
                }
            }

            return vowelCnt;
        }
    }
}
