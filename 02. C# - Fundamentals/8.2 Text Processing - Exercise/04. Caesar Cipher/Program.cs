using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < originalText.Length; i++)
            {
                char c = originalText[i];
                char newChar = (char)(c + 3);
                sb.Append(newChar.ToString());
            }

            Console.WriteLine(sb);
        }
    }
}
