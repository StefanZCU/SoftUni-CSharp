namespace UniversityCompetition.Models.Subjects
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Subject : ISubject
    {
        private string name;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
        }

        public int Id { get; }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public double Rate { get; }
    }
}
