using System;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            string randomString = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < randomString.Length; i++)
            {
                if (firstChar > secondChar)
                {
                    if (randomString[i] > secondChar && randomString[i] < firstChar)
                    {
                        sum += randomString[i];
                    }
                }
                else
                {
                    if (randomString[i] < secondChar && randomString[i] > firstChar)
                    {
                        sum += randomString[i];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
