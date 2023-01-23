using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> originalVowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            Stack<char> originalConsonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());


            List<string> wordsToFind = new List<string>
            {
                {"pear"}, {"flour"}, {"pork"}, {"olive"}
            };

            List<string> wordsFound = new List<string>();


            for (int i = 0; i < 4; i++)
            {
                string word = wordsToFind[i];

                var currentQueueV = new Queue<char>();
                foreach (var c in originalVowels)
                {
                    currentQueueV.Enqueue(c);
                }

                var currentStackC = new Stack<char>();
                foreach (var c in originalConsonants)
                {
                    currentStackC.Push(c);
                }

                StringBuilder sb = new StringBuilder();

                while (currentStackC.Any())
                {
                    char currentConsonant = currentStackC.Pop();
                    char currentVowel = currentQueueV.Dequeue();

                    sb.Append($"{currentVowel}{currentConsonant}");

                    currentQueueV.Enqueue(currentVowel);

                }

                int count = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    if (sb.ToString().Contains(word[j]))
                    {
                        count++;
                    }
                }

                if (count == word.Length)
                {
                    wordsFound.Add(word);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            if (wordsFound.Count != 0)
            {
                Console.WriteLine($"{string.Join("\n", wordsFound)}");
            }
        }
    }
}
