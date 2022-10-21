using System;

namespace _01._Read_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();

                if (word == "Stop")
                {
                    break;
                }
                Console.WriteLine(word);
            }
        }
    }
}
