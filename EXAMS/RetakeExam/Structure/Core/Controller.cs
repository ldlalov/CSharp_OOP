using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    internal class Controller : IController
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
        public string AddStudent(string firstName, string lastName)
        {
            int studentId = students.Models.Count + 1;
            string name = $"{firstName} {lastName}";
            if (students.FindByName(name) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            Student student = new Student(studentId, firstName, lastName);
            students.AddModel(student);
            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            int subjectId = subjects.Models.Count + 1;
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject,subjectName);
            }
            ISubject subject;
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(subjectId, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(subjectId, subjectName);
            }
            else
            {
                subject = new HumanitySubject(subjectId, subjectName);
            }
            subjects.AddModel(subject);
            return String.Format(OutputMessages.SubjectAddedSuccessfully,subjectType, subjectName,subjects.GetType().Name);

        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            int universityId = universities.Models.Count +1;
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity,universityName);
            }
            List<int> subjectsID = new List<int>();
            foreach (var item in requiredSubjects)
            {
                subjectsID.Add(subjects.FindByName(item).Id);
            }
            University university = new University(universityId,universityName, category,capacity, subjectsID);
            universities.AddModel(university);
            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] names = studentName.Split(" ");
            if (students.FindByName(studentName) == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, names[0], names[1]);
            }
            if (universities.FindByName(universityName) == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            var student = students.FindByName(studentName);
            var university = universities.FindByName(universityName);
            bool areCovered = true;
            foreach (var exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(exam))
                {
                    areCovered = false;
                    break;
                }
            }
            if (areCovered == false)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName,universityName);
            }
            if (student.University != null && student.University.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, names[0], names[1], universityName);
            }
            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, names[0], names[1], universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }
            if (subjects.FindById(subjectId) == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);
            }
            string studentFName = students.FindById(studentId).FirstName;
            string studentLName = students.FindById(studentId).LastName;
            string subjectName = subjects.FindById(subjectId).Name;
            if (students.FindById(studentId).CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, studentFName,studentLName,subjectName);
            }
            students.FindById(studentId).CoverExam(subjects.FindById(subjectId));
            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, studentFName,studentLName,subjectName);
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);
            int studentsAdmited = students.Models.Where(s => s.University != null && s.University.Name == university.Name).Count();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsAdmited}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsAdmited}");
            return sb.ToString().Trim();
        }
    }
}
