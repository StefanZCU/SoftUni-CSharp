using System;
using System.Linq;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] input = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = input[0];

                if (cmdArg == "InsertSpace")
                {
                    concealedMessage = concealedMessage.Insert(int.Parse(input[1]), " ");

                    Console.WriteLine(concealedMessage);
                }
                else if (cmdArg == "Reverse")
                {
                    string subString = input[1];
                    if (concealedMessage.Contains(subString))
                    {
                        int index = concealedMessage.IndexOf(subString);
                        concealedMessage = concealedMessage.Remove(index, subString.Length);

                        string reverseWord = string.Empty;

                        for (int i = 0; i < subString.Length; i++)
                        {
                            char currentChar = subString[subString.Length - i - 1];
                            reverseWord += currentChar;
                        }

                        concealedMessage += reverseWord;

                        Console.WriteLine(concealedMessage);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArg == "ChangeAll")
                {
                    string subString = input[1];
                    string replacement = input[2];

                    concealedMessage = concealedMessage.Replace(subString, replacement);

                    Console.WriteLine(concealedMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
