using System;

namespace _04._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);

            Console.WriteLine(charArray);
        }
    }
}
