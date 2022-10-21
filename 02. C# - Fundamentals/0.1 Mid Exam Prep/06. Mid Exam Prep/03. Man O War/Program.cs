using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShipStatus = Console.ReadLine().Split(">").Select(int.Parse).ToList();

            int maxAllowedHealth = int.Parse(Console.ReadLine());
            bool flag = true;
            double twentyPercent = maxAllowedHealth * 0.2;
            int pirateShipSum = 0;
            int warShipSum = 0;
            int repairCounter = 0;

            string command;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] input = command.Split();

                if (input[0] == "Fire")
                {
                    if (FindValidIndex(warShipStatus, int.Parse(input[1])))
                    {
                        warShipStatus[int.Parse(input[1])] -= int.Parse(input[2]);

                        if (warShipStatus[int.Parse(input[1])] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Defend")
                {
                    if (FindValidIndex(pirateShipStatus, int.Parse(input[1])) && FindValidIndex(pirateShipStatus, int.Parse(input[2])))
                    {
                        for (int i = int.Parse(input[1]); i <= int.Parse(input[2]); i++)
                        {
                            pirateShipStatus[i] -= int.Parse(input[3]);

                            if (pirateShipStatus[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                flag = false;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Repair")
                {
                    if (FindValidIndex(pirateShipStatus, int.Parse(input[1])))
                    {
                        if (pirateShipStatus[int.Parse(input[1])] + int.Parse(input[2]) > maxAllowedHealth)
                        {
                            pirateShipStatus[int.Parse(input[1])] = maxAllowedHealth;
                        }
                        else
                        {
                            pirateShipStatus[int.Parse(input[1])] += int.Parse(input[2]);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Status")
                {
                    for (int i = 0; i < pirateShipStatus.Count; i++)
                    {
                        if (pirateShipStatus[i] < twentyPercent)
                        {
                            repairCounter++;
                        }
                    }

                    Console.WriteLine($"{repairCounter} sections need repair.");
                    repairCounter = 0;
                }
            }

            if (flag)
            {
                for (int i = 0; i < pirateShipStatus.Count; i++)
                {
                    pirateShipSum += pirateShipStatus[i];
                }

                for (int j = 0; j < warShipStatus.Count; j++)
                {
                    warShipSum += warShipStatus[j];
                }

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }

        }

        static bool FindValidIndex(List<int> ship, int index)
        {
            if (index >= 0 && index < ship.Count)
            {
                return true;
            }

            return false;
        }
    }
}