using System;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialKey = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] input = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = input[0];

                if (cmdArg == "Contains")
                {
                    string substring = input[1];
                    if (initialKey.Contains(substring))
                    {
                        Console.WriteLine($"{initialKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (cmdArg == "Flip")
                {
                    string upperOrLower = input[1];
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);

                    if (upperOrLower == "Upper")
                    {
                        string toUpper = initialKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                        initialKey = initialKey.Remove(startIndex, endIndex - startIndex);
                        initialKey = initialKey.Insert(startIndex, toUpper);
                        Console.WriteLine(initialKey);
                    }
                    else
                    {
                        string toLower = initialKey.Substring(startIndex, endIndex - startIndex).ToLower();
                        initialKey = initialKey.Remove(startIndex, endIndex - startIndex);
                        initialKey = initialKey.Insert(startIndex, toLower);
                        Console.WriteLine(initialKey);
                    }
                }
                else if (cmdArg == "Slice")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    initialKey = initialKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(initialKey);
                }
            }

            Console.WriteLine($"Your activation key is: {initialKey}");
        }
    }
}
