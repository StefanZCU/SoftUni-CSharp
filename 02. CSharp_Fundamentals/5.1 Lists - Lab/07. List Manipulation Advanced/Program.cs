using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool checker = false;

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    numbers = GetAdd(numbers, int.Parse(input[1]));
                    checker = true;
                }
                else if (input[0] == "Remove")
                {
                    numbers = GetRemove(numbers, int.Parse(input[1]));
                    checker = true;
                }
                else if (input[0] == "RemoveAt")
                {
                    numbers = GetRemoveAt(numbers, int.Parse(input[1]));
                    checker = true;
                }
                else if (input[0] == "Insert")
                {
                    numbers = GetInsert(numbers, int.Parse(input[1]), int.Parse(input[2]));
                    checker = true;
                }
                else if (input[0] == "Contains")
                {
                    GetContains(numbers, int.Parse(input[1]));
                }
                else if (input[0] == "PrintEven")
                {
                    Console.WriteLine(String.Join(" ", GetPrintEvenOdd(numbers, input[0])));
                }
                else if (input[0] == "PrintOdd")
                {
                    Console.WriteLine(String.Join(" ", GetPrintEvenOdd(numbers, input[0])));
                }
                else if (input[0] == "GetSum")
                {
                    int result = GetSum(numbers);
                    Console.WriteLine(result);
                }
                else if (input[0] == "Filter")
                {
                    List<int> newList = GetFilter(numbers, input[1], int.Parse(input[2]));
                    Console.WriteLine(String.Join(" ", newList));
                }

            }

            if (checker)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
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

        static void GetContains(List<int> numbers, int num1)
        {
            if (numbers.Contains(num1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static List<int> GetPrintEvenOdd(List<int> numbers, string evenOdd)
        {
            List<int> evenNumbers = new List<int>();

            foreach (int currentNum in numbers)
            {
                if (evenOdd == "PrintEven")
                {
                    if (currentNum % 2 == 0)
                    {
                        evenNumbers.Add(currentNum);
                    }
                }

                if (evenOdd == "PrintOdd")
                {
                    if (currentNum % 2 != 0)
                    {
                        evenNumbers.Add(currentNum);
                    }
                }
            }

            return evenNumbers;
        }

        static int GetSum(List<int> numbers)
        {
            int sum = 0;

            foreach (int item in numbers)
            {
                sum += item;

            }

            return sum;
        }

        static List<int> GetFilter(List<int> numbers, string command, int number)
        {
            List<int> newList = new List<int>();

            if (command == "<")
            {
                foreach (int item in numbers)
                {
                    if (item < number)
                    {
                        newList.Add(item);
                    }
                }
            }
            else if (command == ">")
            {
                foreach (int item in numbers)
                {
                    if (item > number)
                    {
                        newList.Add(item);
                    }
                }
            }
            else if (command == "<=")
            {
                foreach (int item in numbers)
                {
                    if (item <= number)
                    {
                        newList.Add(item);
                    }
                }
            }
            else if (command == ">=")
            {
                foreach (int item in numbers)
                {
                    if (item >= number)
                    {
                        newList.Add(item);
                    }
                }
            }

            return newList;
        }
    }
}