using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersPerSide = new Dictionary<string, List<string>>();
            
            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                bool flag = true;

                if (command.Contains("|"))
                {
                    int index = command.IndexOf("|");

                    string forceSide = command.Substring(0, index).Trim();
                    string forceUser = command.Substring(index + 1, (command.Length - 1) - index).Trim();

                    if (!usersPerSide.ContainsKey(forceSide))
                    {
                        usersPerSide.Add(forceSide, new List<string>());
                    }

                    foreach (var kvp in usersPerSide)
                    {
                        foreach (var user in kvp.Value)
                        {
                            if (user == forceUser && kvp.Key != forceSide)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            break;
                        }
                    }

                    if (flag && !usersPerSide[forceSide].Contains(forceUser))
                    {
                        usersPerSide[forceSide].Add(forceUser);
                    }
                }
                else if (command.Contains("->"))
                {
                    int index = command.IndexOf(">");

                    string forceUser = command.Substring(0, index - 1).Trim();
                    string forceSide = command.Substring(index + 1, (command.Length - 1) - index).Trim();

                    if (!usersPerSide.ContainsKey(forceSide))
                    {
                        usersPerSide.Add(forceSide, new List<string>());
                    }

                    foreach (var kvp in usersPerSide)
                    {
                        foreach (var user in kvp.Value)
                        {
                            if (user == forceUser)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            kvp.Value.Remove(forceUser);
                            usersPerSide[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                            break;
                        }
                    }

                    if (flag)
                    {
                        usersPerSide[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    
                }
            }

            foreach (var kvp in usersPerSide.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (kvp.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
