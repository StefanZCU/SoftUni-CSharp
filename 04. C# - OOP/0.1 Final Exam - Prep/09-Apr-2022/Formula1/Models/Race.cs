namespace Formula1.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                numberOfLaps = value;
            }
        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots { get; }
        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"The {raceName} race has:")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {numberOfLaps}")
                .AppendLine(TookPlace ? "Took place: Yes" : "Took place: No");

            return sb.ToString().TrimEnd();
        }
    }
}
