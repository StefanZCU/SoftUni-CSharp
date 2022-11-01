using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> rolePerPlayer =
                new Dictionary<string, Dictionary<string, int>>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 3)
                {
                    string name = input[0];
                    string position = input[1];
                    int skillPoints = int.Parse(input[2]);

                    if (!rolePerPlayer.ContainsKey(name))
                    {
                        rolePerPlayer.Add(name, new Dictionary<string, int>());
                        rolePerPlayer[name].Add(position, skillPoints);
                    }

                    if (rolePerPlayer[name].ContainsKey(position))
                    {
                        if (rolePerPlayer[name][position] < skillPoints)
                        {
                            rolePerPlayer[name][position] = skillPoints;
                        }
                    }
                    else
                    {
                        rolePerPlayer[name].Add(position, skillPoints);
                    }
                }
                else
                {
                    string[] battle = command.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);

                    string firstPlayer = battle[0];
                    string secondPlayer = battle[1];

                    int totalPointsFirst = 0;
                    int totalPointsSecond = 0;

                    if (rolePerPlayer.ContainsKey(firstPlayer) && rolePerPlayer.ContainsKey(secondPlayer))
                    {
                        foreach (var role1 in rolePerPlayer[firstPlayer])
                        {
                            foreach (var role2 in rolePerPlayer[secondPlayer])
                            {
                                if (role1.Key == role2.Key)
                                {
                                    totalPointsFirst += role1.Value;
                                    totalPointsSecond += role2.Value;
                                }
                            }
                        }

                        if (totalPointsSecond + totalPointsSecond == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (totalPointsFirst > totalPointsSecond)
                            {
                                rolePerPlayer.Remove(secondPlayer);
                            }
                            else if (totalPointsSecond > totalPointsFirst)
                            {
                                rolePerPlayer.Remove(firstPlayer);
                            }
                        }

                        totalPointsFirst = 0;
                        totalPointsSecond = 0;
                    }
                }
            }


            foreach (var player in rolePerPlayer
                         .OrderByDescending(x => x.Value.Values.Sum())
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                Console.WriteLine(String.Join("\n", player.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .Select(x => $"- {x.Key} <::> {x.Value}")));
            }
        }
    }
}
