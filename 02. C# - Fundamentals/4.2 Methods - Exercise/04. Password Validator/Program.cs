using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();

            bool passlengthChecker = GetPassLength(passwordInput); // if true, valid -> if between 6 and 10
            bool letterAndDigitChecker = SymbolChecker(passwordInput); // if true, valid -> if it contains only digits and letters
            bool twoDigitChecker = GetNumberCount(passwordInput); // if true, valid -> contains 2 digits

            if (passlengthChecker && letterAndDigitChecker && twoDigitChecker)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (passlengthChecker == false)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (letterAndDigitChecker == false)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (twoDigitChecker == false)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }

        }

        static bool GetPassLength(string passInput)
        {
            if (passInput.Length >= 6 && passInput.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool SymbolChecker(string passInput)
        {
            foreach (char letterOrDigit in passInput)
            {
                if (!char.IsLetterOrDigit(letterOrDigit))
                {
                    return false;
                }
            }

            return true;
        }

        static bool GetNumberCount(string passInput)
        {
            int numberCount = 0;

            foreach (char letterOrDigit in passInput)
            {
                if (char.IsDigit(letterOrDigit))
                {
                    numberCount++;
                }
            }

            return numberCount >= 2;
        }
    }
}
