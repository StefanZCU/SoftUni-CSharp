using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morseMessage = Console.ReadLine().Split('|');

            Dictionary<string, char> morse = new Dictionary<string, char>()
            {
                { ".-", 'A' },
                { "-...", 'B' },
                { "-.-.", 'C' },
                { "-..", 'D' },
                { ".", 'E' },
                { "..-.", 'F' },
                { "--.", 'G' },
                { "....", 'H' },
                { "..", 'I' },
                { ".---", 'J' },
                { "-.-", 'K' },
                { ".-..", 'L' },
                { "--", 'M' },
                { "-.", 'N' },
                { "---", 'O' },
                { ".--.", 'P' },
                { "--.-", 'Q' },
                { ".-.", 'R' },
                { "...", 'S' },
                { "-", 'T' },
                { "..-", 'U' },
                { "...-", 'V' },
                { ".--", 'W' },
                { "-..-", 'X' },
                { "-.--", 'Y' },
                { "--..", 'Z' }

            };

            StringBuilder sb = new StringBuilder();

            foreach (var word in morseMessage)
            {
                string[] morseLetter = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var letter in morseLetter)
                {
                    foreach (var translator in morse)
                    {
                        if (translator.Key == letter)
                        {
                            sb.Append(translator.Value);
                            break;
                        }
                    }
                }

                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
