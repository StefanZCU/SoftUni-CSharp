namespace UniversityCompetition.Models.Students
{
    using System;

    using Utilities.Messages;
    using System.Collections.Generic;
    using Contracts;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private List<int> coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
        }

        public int Id { get; }
        public string FirstName
        {
            get => firstName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                lastName = value;
            }
        }
        public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();
        public IUniversity University { get; private set; }
        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
