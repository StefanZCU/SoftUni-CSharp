namespace UniversityCompetition.Models.Subjects
{
    public class HumanitySubject : Subject
    {
        private const double SubjectRate = 1.15;
        public HumanitySubject(int subjectId, string subjectName) : base(subjectId, subjectName, SubjectRate)
        {
        }
    }
}
