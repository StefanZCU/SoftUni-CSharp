namespace UniversityCompetition.Models.Subjects
{
    public class EconomicalSubject : Subject
    {
        private const double SubjectRate = 1.0;
        public EconomicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, SubjectRate)
        {
        }
    }
}
