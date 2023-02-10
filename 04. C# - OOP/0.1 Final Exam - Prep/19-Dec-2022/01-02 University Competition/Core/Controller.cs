using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly SubjectRepository subjects;
        private readonly StudentRepository students;
        private readonly UniversityRepository university;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            university = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            StringBuilder sb = new StringBuilder();

            if (subjectType != nameof(TechnicalSubject) && 
                subjectType != nameof(HumanitySubject) &&
                subjectType != nameof(EconomicalSubject))
            {
                sb.AppendLine(string.Format(OutputMessages.SubjectTypeNotSupported, subjectType));
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                sb.AppendLine(string.Format(OutputMessages.AlreadyAddedSubject, subjectName));
            }
            else
            {
                ISubject subject;
                int subjectId = subjects.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }

                this.subjects.AddModel(subject);
                sb.AppendLine(string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository)));
            }

            return sb.ToString().TrimEnd();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            StringBuilder sb = new StringBuilder();

            if (university.FindByName(universityName) != null)
            {
                sb.AppendLine(string.Format(OutputMessages.AlreadyAddedUniversity, universityName));
            }
            else 
            {
                List<int> rs = requiredSubjects.Select(subName => this.subjects.FindByName(subName).Id).ToList();
                IUniversity university =
                    new University(this.university.Models.Count + 1, universityName, category, capacity, rs);
                this.university.AddModel(university);

                sb.AppendLine(string.Format(OutputMessages.UniversityAddedSuccessfully, universityName,
                    nameof(UniversityRepository)));
            }

            return sb.ToString().TrimEnd();
        }

        public string AddStudent(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            throw new System.NotImplementedException();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            throw new System.NotImplementedException();
        }

        public string UniversityReport(int universityId)
        {
            throw new System.NotImplementedException();
        }
    }
}
