using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Team
    {
        public string TeamsCreated { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teamList = new List<Team>();

            int numTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-");

                if (teamList.Any(x => x.TeamsCreated == input[1]))
                {
                    Console.WriteLine($"Team {input[1]} was already created!");
                }
                else if (teamList.Any(x => x.Creator == input[0]))
                {
                    Console.WriteLine($"{input[0]} cannot create another team!");
                }
                else
                {
                    Team currentTeam = new Team();

                    currentTeam.Creator = input[0];
                    currentTeam.TeamsCreated = input[1];
                    currentTeam.Members = new List<string>();

                    teamList.Add(currentTeam);

                    Console.WriteLine($"Team {input[1]} has been created by {input[0]}!");
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] input = command.Split("->");

                string newUser = input[0];
                string teamToJoin = input[1];

                if (teamList.All(x => x.TeamsCreated != teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teamList.Any(x => x.Members.Contains(newUser) || teamList.Any(creator => creator.Creator == newUser)))
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamToJoin}!");
                }
                else
                {
                    var currentTeam = teamList.Find(x => x.TeamsCreated == teamToJoin);
                    currentTeam.Members.Add(newUser);
                }
            }

            var completedTeams = teamList.Where(x => x.Members.Count > 0);
            var disbandTeams = teamList.Where(x => x.Members.Count == 0);


            foreach (var orderedList in completedTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.TeamsCreated))
            {
                Console.WriteLine(orderedList.TeamsCreated);
                Console.WriteLine($"- {orderedList.Creator}");
                foreach (var orderedMembers in orderedList.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {orderedMembers}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var disband in disbandTeams.OrderBy(x => x.TeamsCreated))
            {
                Console.WriteLine(disband.TeamsCreated);
            }

        }
    }
}

