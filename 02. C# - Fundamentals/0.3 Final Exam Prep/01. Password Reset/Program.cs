using System;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "TakeOdd")
                {
                    string newString = string.Empty;

                    for (int i = 0; i < initialString.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            char currentChar = initialString[i];
                            newString += currentChar;
                        }
                    }

                    initialString = newString;
                    Console.WriteLine(initialString);
                }
                else if (input[0] == "Cut")
                {
                    initialString = initialString.Remove(int.Parse(input[1]), int.Parse(input[2]));
                    Console.WriteLine(initialString);
                }
                else if (input[0] == "Substitute")
                {
                    string substring = input[1];
                    string substitute = input[2];

                    if (initialString.Contains(substring))
                    {
                        initialString = initialString.Replace(substring, substitute);
                        Console.WriteLine(initialString);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {initialString}");
        }
    }
}
