using System;

namespace _06._Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine(); 
            int sum = 0;

            string vowels = "aeiou";

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                int vowelIndex = vowels.IndexOf(currentChar);
                if (vowelIndex >= 0)
                {
                    sum += vowelIndex + 1;
                }             
            }
            Console.WriteLine(sum);
        }
    }
}

//if (currentChar == 'a')
//{
//    sum += 1;
//}
//else if (currentChar == 'e')
//{
//    sum += 2;
//}
//else if (currentChar == 'i')
//{
//    sum += 3;
//}
