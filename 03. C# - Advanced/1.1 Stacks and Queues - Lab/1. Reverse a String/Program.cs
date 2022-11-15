using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Stack<string> reverseWord = new Stack<string>();
            string finalReverse = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                reverseWord.Push(word[word.Length - i - 1].ToString());
                finalReverse += reverseWord.Pop();
            }

            Console.WriteLine(finalReverse);
        }
    }
}
