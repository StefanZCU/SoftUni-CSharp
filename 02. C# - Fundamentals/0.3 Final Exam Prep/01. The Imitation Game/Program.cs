using System;
using System.Diagnostics;
using System.Text;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] input = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string instruction = input[0];

                if (instruction == "Move")
                {
                    string replacement = encryptedMessage.Substring(int.Parse(input[1]));
                    replacement += encryptedMessage.Substring(0, int.Parse(input[1]));
                    encryptedMessage = replacement;
                }
                else if (instruction == "Insert")
                {
                    encryptedMessage = encryptedMessage.Insert(int.Parse(input[1]), input[2]);
                }
                else if (instruction == "ChangeAll")
                {
                    encryptedMessage = encryptedMessage.Replace(input[1], input[2]);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
