namespace P05
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(';');

                    string cmdType = cmdArgs[0];
                    string teamName = cmdArgs[1];
                    
                    switch (cmdType)
                    {
                        case "Team":
                        {
                            Team team = new Team(teamName);
                            teams.Add(team);
                            break;
                        }
                        case "Add":
                        {
                            string playerName = cmdArgs[2];
                            int endurance = int.Parse(cmdArgs[3]);
                            int sprint = int.Parse(cmdArgs[4]);
                            int dribble = int.Parse(cmdArgs[5]);
                            int passing = int.Parse(cmdArgs[6]);
                            int shooting = int.Parse(cmdArgs[7]);

                            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                            Player player = new Player(playerName, stats);

                            var teamToFind = teams.FirstOrDefault(x => x.Name == teamName);
                            if (teamToFind != null)
                            {
                                teamToFind.AddPlayer(player);
                            }
                            else
                            {
                                throw new Exception(string.Format(ExceptionMessages.TeamDoesNotExist, teamName));
                            }

                            break;
                        }
                        case "Remove":
                        {
                            string playerName = cmdArgs[2];
                            var teamToFind = teams.First(x => x.Name == teamName);

                            if (!teamToFind.RemovePlayer(teamToFind.Players.First(x => x.Name == playerName)))
                            {
                                throw new Exception(string.Format(ExceptionMessages.PlayerDoesNotExist, playerName,
                                    teamName));
                            }

                            break;
                        }
                        case "Rating":
                        {
                            var teamToFind = teams.FirstOrDefault(x => x.Name == teamName);
                            if (teamToFind != null) 
                            {
                                Console.WriteLine($"{teamToFind.Name} - {teamToFind.Rating}");
                            }
                            else
                            {
                                throw new Exception(string.Format(ExceptionMessages.TeamDoesNotExist, teamName));
                            }
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}