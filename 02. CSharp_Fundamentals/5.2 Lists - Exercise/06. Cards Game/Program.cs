using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> playerTwo = Console.ReadLine().Split().Select(int.Parse).ToList();


            while (true)
            {
                if (playerOne.Count == 0)
                {
                    int sum = 0;

                    foreach (int item in playerTwo)
                    {
                        sum += item;
                    }

                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (playerTwo.Count == 0)
                {
                    int sum = 0;

                    foreach (int item in playerOne)
                    {
                        sum += item;
                    }

                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }

                if (playerOne[0] == playerTwo[0])
                {
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                }
                else if (playerOne[0] > playerTwo[0])
                {
                    playerOne.Add(playerOne[0]);
                    playerOne.Add(playerTwo[0]);
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                }
                else if (playerOne[0] < playerTwo[0])
                {
                    playerTwo.Add(playerTwo[0]);
                    playerTwo.Add(playerOne[0]);
                    playerTwo.RemoveAt(0);
                    playerOne.RemoveAt(0);
                }
            }


            
        }
    }
}
