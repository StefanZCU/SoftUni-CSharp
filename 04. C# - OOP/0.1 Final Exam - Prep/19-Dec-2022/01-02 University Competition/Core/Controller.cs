using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Students;
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

                subject = subjectType switch
                {
                    nameof(TechnicalSubject) => new TechnicalSubject(subjectId, subjectName),
                    nameof(EconomicalSubject) => new EconomicalSubject(subjectId, subjectName),
                    _ => new HumanitySubject(subjectId, subjectName)
                };

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
            StringBuilder sb = new StringBuilder();

            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                sb.AppendLine(string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName));
            }
            else
            {
                IStudent student = new Student(this.students.Models.Count + 1, firstName, lastName);
                students.AddModel(student);

                sb.AppendLine(string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository)));
            }

            return sb.ToString().TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            StringBuilder sb = new StringBuilder();
            var studentToFind = students.FindById(studentId);
            var subjectToFind = subjects.FindById(subjectId);

            if (studentToFind == null)
            {
                sb.AppendLine(OutputMessages.InvalidStudentId);
            }
            else if (subjectToFind == null)
            {
                sb.AppendLine(OutputMessages.InvalidSubjectId);
            }
            else if (studentToFind.CoveredExams.Contains(subjectId))
            {
                sb.AppendLine(string.Format(OutputMessages.StudentAlreadyCoveredThatExam, studentToFind.FirstName,
                    studentToFind.LastName, subjectToFind.Name));
            }
            else
            {
                var subject = subjects.FindById(subjectId);
                studentToFind.CoverExam(subject);
                sb.AppendLine(string.Format(OutputMessages.StudentSuccessfullyCoveredExam, studentToFind.FirstName, studentToFind.LastName, subject.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            StringBuilder sb = new StringBuilder();
            bool hasNotCoveredExams = false;

            foreach (var requiredSubject in university.FindByName(universityName).RequiredSubjects)
            {
                if (!students.FindByName(studentName).CoveredExams.Contains(requiredSubject))
                {
                    hasNotCoveredExams = true;
                }
            }

            string[] name = studentName.Split();
            string firstName = name[0];
            string lastName = name[1];

            var studentToFind = students.FindByName(studentName);
            var universityToFind = university.FindByName(universityName);

            if (studentToFind == null)
            {
                sb.AppendLine(string.Format(OutputMessages.StudentNotRegitered, firstName, lastName));
            }
            else if (universityToFind == null)
            {
                sb.AppendLine(String.Format(OutputMessages.UniversityNotRegitered, universityName));
            }
            else if (hasNotCoveredExams)
            {
                sb.AppendLine(string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName));
            }
            else if (studentToFind.University == universityToFind)
            {
                sb.AppendLine(String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName));
            }
            else
            {
                studentToFind.JoinUniversity(universityToFind);
                sb.AppendLine(string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName,
                    universityName));
            }

            return sb.ToString().TrimEnd();

        }

        public string UniversityReport(int universityId)
        {
            var universityToFind = university.FindById(universityId);
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"*** {universityToFind.Name} ***")
                .AppendLine($"Profile: {universityToFind.Category}")
                .AppendLine(
                    $"Students admitted: {students.Models.Count(x => x.University == universityToFind)}")
                .AppendLine(
                    $"University vacancy: {universityToFind.Capacity - students.Models.Count(s => s.University == universityToFind)}");

            return sb.ToString().TrimEnd();

        }
    }
}
