using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine().Split().ToList();

            int moves = 0;
            bool win = false;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (win)
                {
                    continue;
                }
                moves++;

                string[] input = command.Split();

                if (int.Parse(input[0]) >= 0 && int.Parse(input[0]) < sequence.Count && int.Parse(input[1]) >= 0 && int.Parse(input[1]) < sequence.Count && input[0] != input[1])
                {

                    if (sequence[int.Parse(input[0])] == sequence[int.Parse(input[1])])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequence[int.Parse(input[0])]}!");

                        if (int.Parse(input[0]) > int.Parse(input[1]))
                        {
                            sequence.RemoveAt(int.Parse(input[1]));
                            sequence.RemoveAt(int.Parse(input[0]) - 1);
                        }
                        else
                        {
                            sequence.RemoveAt(int.Parse(input[0]));
                            sequence.RemoveAt(int.Parse(input[1]) - 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                    if (sequence.Count <= 1)
                    {
                        win = true;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");
                }



            }

            if (win)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(" ", sequence));
            }
        }
    }
}