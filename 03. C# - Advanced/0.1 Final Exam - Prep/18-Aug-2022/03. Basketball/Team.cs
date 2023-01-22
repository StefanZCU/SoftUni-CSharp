using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> player;

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => player.Count;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            player = new List<Player>();
        }

        public string AddPlayer(Player player)
        {
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            this.player.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var playerToFind = player.FirstOrDefault(x => x.Name == name);

            if (playerToFind == null)
            {
                return false;
            }

            OpenPositions++;
            player.Remove(playerToFind);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countRemovedPlayers = 0;
            while (player.FirstOrDefault(x => x.Position == position) != null)
            {
                var targetPlayer = player.FirstOrDefault(x => x.Position == position);
                this.OpenPositions++;
                player.Remove(targetPlayer);
                countRemovedPlayers++;
            }
            return countRemovedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player1 in player.Where(x => x.Name == name))
            {
                player1.Retired = true;
                return player1;
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            return player.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player1 in player.Where(x => x.Retired != true))
            {
                sb.AppendLine(player1.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
