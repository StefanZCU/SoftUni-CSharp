using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = roster.FirstOrDefault(x => x.Name == name);
            if (playerToRemove != null)
            {
                roster.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = roster.First(x => x.Name == name);
            playerToPromote.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            var playerToPromote = roster.First(x => x.Name == name);
            playerToPromote.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var playersToRemove = new List<Player>();

            while (roster.FirstOrDefault(x => x.Class == @class) != null)
            {
                playersToRemove.Add(roster.FirstOrDefault(x => x.Class == @class));
                roster.Remove(roster.FirstOrDefault(x => x.Class == @class));
            }

            return playersToRemove.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
