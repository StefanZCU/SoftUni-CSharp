namespace _05_Football_Team_Generator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                name = value;
            }
        }

        public int Rating => players.Count > 0 
            ? (int)Math.Round(players.Average(p => p.AverageStats), 0) 
            : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var playerToRemove = players.FirstOrDefault(x => x.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerDoesntExist, playerName, Name));
            }

            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
