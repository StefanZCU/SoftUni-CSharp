using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string longString = Console.ReadLine();

            int index = longString.IndexOf(word);

            while (index != -1)
            {
                longString = longString.Remove(index, word.Length);
                index = longString.IndexOf(word);

            }

            Console.WriteLine(longString);
        }
    }
}
