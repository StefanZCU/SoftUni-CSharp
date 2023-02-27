namespace UniversityCompetition.Models.Subjects
{
    public class TechnicalSubject : Subject
    {
        private const double SubjectRate = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, SubjectRate)
        {
        }
    }
}
