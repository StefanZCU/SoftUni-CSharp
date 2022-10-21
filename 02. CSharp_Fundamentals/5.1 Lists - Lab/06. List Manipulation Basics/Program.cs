using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    numbers = GetAdd(numbers, int.Parse(input[1]));
                }
                else if (input[0] == "Remove")
                {
                    numbers = GetRemove(numbers, int.Parse(input[1]));
                }
                else if (input[0] == "RemoveAt")
                {
                    numbers = GetRemoveAt(numbers, int.Parse(input[1]));
                }
                else if (input[0] == "Insert")
                {
                    numbers = GetInsert(numbers, int.Parse(input[1]), int.Parse(input[2]));
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
            numbers.Remove(num);

            return numbers;
        }

        static List<int> GetRemoveAt(List<int> numbers, int num)
        {
            numbers.RemoveAt(num);

            return numbers;
        }

        static List<int> GetInsert(List<int> numbers, int num1, int num2)
        {
            numbers.Insert(num2, num1);

            return numbers;
        }
    }
}
