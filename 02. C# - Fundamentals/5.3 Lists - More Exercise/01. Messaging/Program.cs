using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numMessage = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();

            int sum = 0;

            List<char> sentenceChar = message.ToList();
            List<char> newMessage = new List<char>();

            for (int i = 0; i < numMessage.Count; i++)
            {
                string currentNumString = numMessage[i].ToString();

                for (int j = 0; j < currentNumString.Length; j++)
                {
                    string num = currentNumString[j].ToString();
                    sum += int.Parse(num);
                }

                int counter = 0;

                for (int k = 0; k <= sum; k++)
                {
                    if (counter == sentenceChar.Count)
                    {
                        counter = 0;
                    }

                    if (k == sum)
                    {
                        newMessage.Add(sentenceChar[counter]);
                        sentenceChar.RemoveAt(counter);
                    }

                    counter++;
                }

                sum = 0;
            }

            foreach (char item in newMessage)
            {
                Console.Write($"{item}");
            }
        }
    }
}
