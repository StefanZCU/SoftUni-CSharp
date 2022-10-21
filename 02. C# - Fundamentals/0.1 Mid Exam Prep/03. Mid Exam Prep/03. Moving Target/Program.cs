using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targetSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();

                if (input[0] == "Shoot")
                {
                    if (GetValidIndex(targetSequence, int.Parse(input[1]))) // if true is returned, index is in scope
                    {
                        targetSequence = GetShoot(targetSequence, int.Parse(input[1]), int.Parse(input[2]));
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (input[0] == "Add")
                {
                    if (GetValidIndex(targetSequence, int.Parse(input[1]))) // if true is returned, index is in scope
                    {
                        targetSequence = GetAdd(targetSequence, int.Parse(input[1]), int.Parse(input[2]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }
                }
                else if (input[0] == "Strike")
                {
                    if (GetValidIndex(targetSequence, int.Parse(input[1]))
                        && GetValidIndex(targetSequence, (int.Parse(input[1]) + int.Parse(input[2])))
                        && GetValidIndex(targetSequence, (int.Parse(input[1]) - int.Parse(input[2]))))
                    {
                        //all three arguments must be true, otherwise out of scope

                        targetSequence = GetStrike(targetSequence, int.Parse(input[1]), int.Parse(input[2]));
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                }
            }

            Console.WriteLine(String.Join("|", targetSequence));
        }

        static bool GetValidIndex(List<int> targetSequence, int index) // return true if in scope (works after test)
        {
            if (index >= 0 && index < targetSequence.Count)
            {
                return true;
            }

            return false;
        }
        static List<int> GetShoot(List<int> targetSequence, int index, int power) // works after test
        {
            if (targetSequence[index] - power <= 0)
            {
                targetSequence.RemoveAt(index);
            }
            else
            {
                targetSequence[index] -= power;
            }

            return targetSequence;
        }
        static List<int> GetAdd(List<int> targetSequence, int index, int value) // works after test
        {

            targetSequence.Insert(index, value);

            return targetSequence;
        }
        static List<int> GetStrike(List<int> targetSequence, int index, int radius)
        {
            int start = index - radius;

            for (int i = start; i <= index + radius; i++)
            {
                targetSequence.RemoveAt(start);
            }

            return targetSequence;
        }
    }
}