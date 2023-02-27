namespace P05
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;

            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception(string.Format(ExceptionMessages.StatIsInvalid, nameof(Endurance)));
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception(string.Format(ExceptionMessages.StatIsInvalid, nameof(Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception(string.Format(ExceptionMessages.StatIsInvalid, nameof(Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing; 
            
            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception(string.Format(ExceptionMessages.StatIsInvalid, nameof(Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                if (value is < 0 or > 100)
                {
                    throw new Exception(string.Format(ExceptionMessages.StatIsInvalid, nameof(Shooting)));
                }

                shooting = value;
            }
        }

        public double Average => (Endurance + Dribble + Sprint + Passing + Shooting) / 5.0;
    }
}
