namespace Basketball
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = players.FirstOrDefault(x => x.Name == name);
            if (playerToRemove == null) return false;
            players.Remove(playerToRemove);
            OpenPositions++;
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = 0;

            while (players.Any(x => x.Position == position))
            {
                var playerToRemove = players.FirstOrDefault(x => x.Position == position);

                players.Remove(playerToRemove);
                removedPlayers++;
                OpenPositions++;
            }

            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = players.FirstOrDefault(x => x.Name == name);

            if (playerToRetire == null) return null;
            playerToRetire.Retired = true;
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(x => x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
