using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Delete")
                {
                    numberList = GetDelete(numberList, int.Parse(input[1]));
                }
                else if (input[0] == "Insert")
                {
                    numberList = GetInsert(numberList, int.Parse(input[1]), int.Parse(input[2]));
                }
            }

            Console.WriteLine(String.Join(" ", numberList));
        }

        static List<int> GetDelete(List<int> numberList, int element)
        {
            numberList.RemoveAll(n => n == element);

            return numberList;
        }
        static List<int> GetInsert(List<int> numberList, int number, int index)
        {
            numberList.Insert(index, number);

            return numberList;
        }
    }
}
