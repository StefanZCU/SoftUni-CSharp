using System;
using System.Text;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string entireText = Console.ReadLine();
            string asterix = string.Empty;
            string newText = string.Empty;

            foreach (var word in bannedWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    asterix += "*";
                }

                newText = entireText.Replace(word, asterix);
                entireText = newText;
                asterix = "";
            }

            Console.WriteLine(newText);
        }
    }
}
