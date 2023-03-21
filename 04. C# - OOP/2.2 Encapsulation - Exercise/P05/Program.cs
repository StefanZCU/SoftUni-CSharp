namespace P05
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(";");

                string command = cmdArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            AddTeam(cmdArgs[1], teams);
                            break;
                        case "Add":
                            AddPlayer(
                                cmdArgs[1],
                                cmdArgs[2],
                                int.Parse(cmdArgs[3]),
                                int.Parse(cmdArgs[4]),
                                int.Parse(cmdArgs[5]),
                                int.Parse(cmdArgs[6]),
                                int.Parse(cmdArgs[7]),
                                teams);
                            break;
                        case "Remove":
                            RemovePlayer(cmdArgs[1], cmdArgs[2], teams);
                            break;
                        case "Rating":
                            PrintRating(cmdArgs[1], teams);
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void AddTeam(string name, List<Team> teams)
        {
            teams.Add(new Team(name));
        }

        static void AddPlayer(
            string teamName,
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting,
            List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            Player player = new(name, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            team.RemovePlayer(playerName);
        }

        static void PrintRating(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            Console.WriteLine($"{teamName} - {team.Rating:f0}");
        }
    }
}