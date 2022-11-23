using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    public class Follows
    {
        public List<string> followers { get; set; } = new List<string>();
        public List<string> following { get; set; } = new List<string>();

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Follows> vloggers = new Dictionary<string, Follows>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = input[0];
                string action = input[1];

                if (!vloggers.ContainsKey(vloggerName) && action == "joined")
                {
                    Follows follows = new Follows();

                    vloggers[vloggerName] = follows;

                }

                if (vloggers.ContainsKey(vloggerName) && action == "followed")
                {
                    string personFollowed = input[2];

                    if (vloggers.ContainsKey(personFollowed) && vloggerName != personFollowed && !vloggers[vloggerName].following.Contains(personFollowed))
                    {
                        vloggers[personFollowed].followers.Add(vloggerName);
                        vloggers[vloggerName].following.Add(personFollowed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.followers.Count).ThenBy(y => y.Value.following.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");

                if (vlogger.Value.followers.Count != 0 && counter == 1) 
                {
                    foreach (var follower in vlogger.Value.followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
