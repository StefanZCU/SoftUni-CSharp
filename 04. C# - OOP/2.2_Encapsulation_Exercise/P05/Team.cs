namespace P05
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            players = new List<Player>();
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.NameIsNull);
                }

                name = value;
            }
        }
        
        public int Rating => players.Count == 0 ? 0 : (int)Math.Round(players.Sum(x => x.Stats.Average) / players.Count);

        public IReadOnlyCollection<Player> Players => players;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public bool RemovePlayer(Player player)
        {
            if (!players.Contains(player))
            {
                return false;
            }

            players.Remove(player);
            return true;
        }
    }
}
