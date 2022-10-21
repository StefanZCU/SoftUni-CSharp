using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    numbers = GetAdd(numbers, int.Parse(input[1]));
                }

                else if (input[0] == "Remove")
                {
                    if (int.Parse(input[1]) >= numbers.Count || int.Parse(input[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = GetRemove(numbers, int.Parse(input[1]));
                    }
                }

                else if (input[0] == "Insert")
                {

                    if (int.Parse(input[2]) >= numbers.Count || int.Parse(input[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = GetInsert(numbers, int.Parse(input[1]), int.Parse(input[2]));
                    }
                }

                else if (input[0] == "Shift")
                {
                    numbers = GetShift(numbers, input[1], int.Parse(input[2]));
                }
            }

            Console.WriteLine(String.Join(" ", numbers));


        }

        static List<int> GetAdd(List<int> numbers, int num)
        {
            numbers.Add(num);

            return numbers;
        }

        static List<int> GetRemove(List<int> numbers, int num)
        {
            numbers.RemoveAt(num);

            return numbers;
        }

        static List<int> GetInsert(List<int> numbers, int num1, int index)
        {
            numbers.Insert(index, num1);

            return numbers;
        }

        static List<int> GetShift(List<int> numbers, string command, int count)
        {
            int tempNum = 0;

            if (command == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(numbers[0]);
                    numbers.Remove(numbers[0]);
                }
            }

            else if (command == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    tempNum = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Insert(1, tempNum);
                }
            }

            return numbers;

        }
    }
}

