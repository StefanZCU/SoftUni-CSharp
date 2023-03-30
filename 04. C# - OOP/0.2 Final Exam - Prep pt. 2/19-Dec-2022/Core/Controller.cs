using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Students;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(HumanitySubject) &&
                subjectType != nameof(EconomicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            var subject = subjects.FindByName(subjectName);

            if (subject != null) return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);

            subject = subjectType switch
            {
                nameof(TechnicalSubject) => new TechnicalSubject(subjects.Models.Count + 1, subjectName),
                nameof(HumanitySubject) => new HumanitySubject(subjects.Models.Count + 1, subjectName),
                _ => new EconomicalSubject(subjects.Models.Count + 1, subjectName)
            };

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName,
                subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            var university = universities.FindByName(universityName);

            if (university != null) return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);

            List<int> requiredSubjectIds = requiredSubjects
                .Select(requiredSubject => subjects.FindByName(requiredSubject))
                .Select(subject => subject.Id).ToList();

            university = new University(universities.Models.Count + 1, universityName, category, capacity,
                requiredSubjectIds);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName,
                universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;
            var student = students.FindByName(fullName);

            if (student != null) return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);

            student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = students.FindById(studentId);
            var subject = subjects.FindById(subjectId);

            if (student == null) return OutputMessages.InvalidStudentId;
            if (subject == null) return OutputMessages.InvalidSubjectId;

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName,
                    subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName,
                subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] fullStudentName = studentName.Split(" ");
            var student = students.FindByName(studentName);

            if (student == null)
                return string.Format(OutputMessages.StudentNotRegitered, fullStudentName[0], fullStudentName[1]);

            var university = universities.FindByName(universityName);

            if (university == null) return string.Format(OutputMessages.UniversityNotRegitered, universityName);

            if (university.RequiredSubjects.Any(universityRequiredSubject => !student.CoveredExams.Contains(universityRequiredSubject)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, fullStudentName[0], fullStudentName[1],
                    universityName);
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, fullStudentName[0], fullStudentName[1],
                universityName);
        }

        public string UniversityReport(int universityId)
        {
            var sb = new StringBuilder();
            var university = universities.FindById(universityId);

            sb
                .AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {students.Models.Count(x => x.University == university)}")
                .AppendLine(
                    $"University vacancy: {university.Capacity - students.Models.Count(x => x.University == university)}");

            return sb.ToString().TrimEnd();
        }
    }
}
