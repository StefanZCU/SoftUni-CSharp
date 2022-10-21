using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] input = command.Split();

                if (input[0] == "merge")
                {
                    inputList = GetMerge(inputList, int.Parse(input[1]), int.Parse(input[2]));
                }
                else if (input[0] == "divide")
                {
                    inputList = GetDivide(inputList, int.Parse(input[1]), int.Parse(input[2]));
                }
            }


            Console.WriteLine(String.Join(" ", inputList));


        }

        static List<string> GetMerge(List<string> inputList, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex < 0 || startIndex >= inputList.Count)
            {
                return inputList;
            }

            if (endIndex >= inputList.Count)
            {
                endIndex = inputList.Count - 1;
            }


            for (int i = startIndex; i < endIndex; i++)
            {
                inputList[startIndex] = inputList[startIndex] + inputList[startIndex + 1];
                inputList.RemoveAt(startIndex + 1);
            }

            return inputList;
        }

        static List<string> GetDivide(List<string> inputList, int index, double partitions)
        {

            string[] partitionedStrings = new string[(int)partitions];

            string word = inputList[index];

            List<char> splitWord = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                splitWord.Add(word[i]);
            }

            int originalCount = splitWord.Count;

            double leftOver = originalCount % partitions;

            if (leftOver == 0)
            {
                for (int j = 0; j < partitions; j++)
                {
                    for (int k = 0; k < originalCount / partitions; k++)
                    {
                        partitionedStrings[j] += splitWord[0];
                        splitWord.RemoveAt(0);
                    }
                }
            }
            else
            {
                for (int j = 0; j < partitions; j++)
                {
                    for (int k = 0; k < Math.Floor(originalCount / partitions); k++)
                    {
                        partitionedStrings[j] += splitWord[0];
                        splitWord.RemoveAt(0);
                    }

                    if (j == partitions - 1)
                    {
                        for (int l = 0; l < leftOver; l++)
                        {
                            partitionedStrings[j] += splitWord[l];
                        }
                    }
                }
            }

            int currIndex = index;
            inputList.RemoveAt(index);

            for (int m = 0; m < partitionedStrings.Length; m++)
            {
                inputList.Insert(currIndex, partitionedStrings[m]);
                currIndex++;
            }

            return inputList;
        }
    }
}
