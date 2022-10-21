
using System;
using System.Linq;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lineOne = Console.ReadLine().Split().ToArray();
            string[] lineTwo = Console.ReadLine().Split().ToArray();

            string[] matches = new string[lineOne.Length];

            for (int i = 0; i < lineTwo.Length; i++)
            {
                for (int j = 0; j < lineOne.Length; j++)
                {
                    if (lineTwo[i] == lineOne[j])
                    {
                        Console.Write($"{lineOne[j]} ");
                    }
                }
            }
        }
    }
}
