namespace P05
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.NameIsNull);
                }

                name = value;
            }
        }

        public Stats Stats { get; }
    }
}
