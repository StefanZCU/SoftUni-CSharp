using System;

namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            char three = char.Parse(Console.ReadLine());

            string word = string.Empty;

            word += one;
            word += two;
            word += three;

            Console.WriteLine(word);
        }
    }
}
