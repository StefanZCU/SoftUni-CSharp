using System;

namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                char currChar;
                string reverseWord = String.Empty;
                for (int i = 0; i < command.Length; i++)
                {
                    currChar = command[command.Length - i - 1];
                    reverseWord += currChar;
                }

                Console.WriteLine($"{command} = {reverseWord}");
            }
        }
    }
}
