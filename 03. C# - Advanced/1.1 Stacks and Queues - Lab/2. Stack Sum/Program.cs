using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numsToAdd = new Stack<int>(numbers);

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "add")
                {
                    int num1 = int.Parse(input[1]);
                    int num2 = int.Parse(input[2]);

                    numsToAdd.Push(num1);
                    numsToAdd.Push(num2);
                }
                else if (input[0] == "remove")
                {
                    int numberCycles = int.Parse(input[1]);

                    if (numberCycles <= numsToAdd.Count)
                    {
                        for (int i = 0; i < numberCycles; i++)
                        {
                            numsToAdd.Pop();
                        }

                    }

                }
            }

            int sum = 0;
            foreach (var num in numsToAdd)
            {
                sum += num;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
