using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int currentIndex = random.Next(0, words.Length);

                string currWord = words[currentIndex];
                words[currentIndex] = words[i];
                words[i] = currWord;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}