using System.Security.Cryptography.X509Certificates;

namespace _05_Football_Team_Generator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            Team teamToFind;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(';');

                string cmdType = input[0];
                string teamName = input[1];

                try
                {
                    switch (cmdType)
                    {
                        case "Team":

                            Team team = new Team(teamName);
                            teams.Add(team);

                            break;

                        case "Add":

                             teamToFind = teams.FirstOrDefault(x => x.Name == teamName);

                            if (teamToFind == null)
                            {
                                Console.WriteLine(ExceptionMessages.TeamDoesntExist, teamName);
                                break;
                            }

                            string playerName = input[2];
                            int endurance = int.Parse(input[3]);
                            int sprint = int.Parse(input[4]);
                            int dribble = int.Parse(input[5]);
                            int passing = int.Parse(input[6]);
                            int shooting = int.Parse(input[7]);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            
                            teamToFind.AddPlayer(player);

                            break;

                        case "Remove":

                            teamToFind = teams.FirstOrDefault(x => x.Name == teamName);
                            teamToFind.RemovePlayer(input[2]);

                            break;

                        case "Rating":
                            teamToFind = teams.FirstOrDefault(x => x.Name == teamName);

                            if (teamToFind == null)
                            {
                                Console.WriteLine(ExceptionMessages.TeamDoesntExist, teamName);
                                break;
                            }

                            Console.WriteLine(teamToFind);

                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}