using System;
using System.Text;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalPassword = Console.ReadLine();

            StringBuilder sb = new StringBuilder(originalPassword);

            string command;
            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] input = command.Split();

                if (input[0] == "Make")
                {
                    if (input[1] == "Upper")
                    {
                        int index = int.Parse(input[2]);

                        if (index >= 0 && index < sb.Length)
                        {
                            char letter = sb[index];
                            sb.Remove(index, 1);
                            sb.Insert(index, char.ToUpper(letter));
                            Console.WriteLine(sb);
                        }
                    }
                    else if (input[1] == "Lower")
                    {
                        int index = int.Parse(input[2]);

                        if (index >= 0 && index < sb.Length)
                        {
                            char letter = sb[index];
                            sb.Remove(index, 1);
                            sb.Insert(index, char.ToLower(letter));
                            Console.WriteLine(sb);
                        }
                    }
                }
                else if (input[0] == "Insert")
                {
                    int index = int.Parse(input[1]);
                    char c = char.Parse(input[2]);

                    if (index >= 0 && index < sb.Length)
                    {
                        sb.Insert(index, c);
                        Console.WriteLine(sb);
                    }
                }
                else if (input[0] == "Replace")
                {
                    char c = char.Parse(input[1]);
                    int value = int.Parse(input[2]);

                    if (sb.ToString().Contains(c))
                    {
                        int newValue = value + c;
                        char newChar = (char)newValue;

                        sb.Replace(c, newChar);
                        Console.WriteLine(sb);
                    }

                }
                else if (input[0] == "Validation")
                {
                    if (sb.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }
                    
                    if (!ConsistsOfChecker(sb))
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }
                    
                    if (!UpperChecker(sb))
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }
                    
                    if (!LowerChecker(sb))
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }
                    
                    if (!DigitChecker(sb))
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
            }
        }

        static bool ConsistsOfChecker(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                char currC = sb[i];

                if (!char.IsLetter(currC))
                {
                    if (!char.IsDigit(currC))
                    {
                        if (currC != '_')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static bool UpperChecker(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsLetter(sb[i]) && char.IsUpper(sb[i]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool LowerChecker(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsLetter(sb[i]) && char.IsLower(sb[i]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool DigitChecker(StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsDigit(sb[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}