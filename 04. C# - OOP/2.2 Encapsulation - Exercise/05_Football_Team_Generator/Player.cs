using System.Reflection;

namespace _05_Football_Team_Generator
{
    public class Player
    {
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public Stats Stats { get; }

        public double AverageStats => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.0;

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
    }
}
