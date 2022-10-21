using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                bool resultBool = PalindromeChecker(command);

                string result = resultBool.ToString();
                Console.WriteLine(result.ToLower());
            }
        }

        static bool PalindromeChecker(string command)
        {

            if (command.Length == 1)
            {
                return true;
            }
            else if (command.Length % 2 == 0)
            {
                int palindromeCount = 0;

                for (int i = 0; i < command.Length / 2; i++)
                {
                    if (command[i] == command[command.Length - i - 1])
                    {
                        palindromeCount++;
                    }
                }

                if (palindromeCount == command.Length / 2)
                {
                    return true;
                }
            }
            else if (command.Length % 2 == 1)
            {
                int palindromeCount = 0;

                double middleD = Math.Floor((double)command.Length / 2);
                int middle = (int)middleD;

                for (int i = 0; i < middle; i++)
                {
                    if (command[i] == command[command.Length - i - 1])
                    {
                        palindromeCount++;
                    }
                }

                if (palindromeCount == middle)
                {
                    return true;
                }

            }


            return false;
        }
    }
}
