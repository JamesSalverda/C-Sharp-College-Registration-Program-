using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BITCollege_JS.Models;
using Utility;

namespace BitCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    /// <summary>
    /// holds methods to drop a course, register a course, and update a grade
    /// </summary>
    public class CollegeRegistration : ICollegeRegistration
    {
        public BITCollege_JSContext db = new BITCollege_JSContext();

        public void DoWork()
        {
        }

        /// <summary>
        /// Uses LINQ-SQL to retrieve the Registration record from the database which corresponds to the method argument
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns>returns false if fails, otherwise returns true</returns>
        public bool dropCourse(int registrationId)
        {
            Registration record = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();

            try
            {
                db.Registrations.Remove(record);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates and adds a course to a Students record
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="notes"></param>
        /// <returns>0 if successful, -100, -200, or -300 if errors were encounterd</returns>
        public int registerCourse(int studentId, int courseId, string notes)
        {
            int returnCode = 0;

            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
            Course course = db.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();

            IQueryable<Registration> attempt = db.Registrations.Where(x => x.CourseId == courseId).Where(x => x.StudentId == studentId);
            List<Registration> gradeNull = db.Registrations.Where(x => x.CourseId == courseId).Where(x => x.StudentId == studentId).Where(x => x.Grade == null).ToList();

            int maxAttempts = (from result in db.MasteryCourses
                               where result.CourseId == course.CourseId
                               select result.MaximumAttempts).SingleOrDefault();

            if (course.CourseType == "Mastery")
            {
                MasteryCourse mastery = (MasteryCourse)course;

                if (attempt.Count() >= mastery.MaximumAttempts)
                {
                    return returnCode = -200;
                }
            }

            if (gradeNull.Count() > 0)
            {
                return returnCode = -100;
            }

            if(student.Registration != null)
            {
                try
                {
                    Registration registration = new Registration();

                    registration.setNextRegistrationNumber();
                    registration.StudentId = studentId;
                    registration.CourseId = courseId;
                    registration.RegistrationDate = DateTime.Now;
                    registration.Grade = null;
                    registration.Notes = notes;

                    db.Registrations.Add(registration);
                    db.SaveChanges();
                    student.OutstandingFees += course.TuitionAmount * student.GPAState.tuitionRateAdjustment(student);

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return returnCode = -300;
                }

                return returnCode;
            }
            return returnCode;
        }

        /// <summary>
        /// Updates the grade of the course for the student
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="registrationId"></param>
        /// <param name="notes"></param>
        public void upgradeGrade(double grade, int registrationId, string notes)
        {
            BITCollege_JSContext db = new BITCollege_JSContext();

            Registration registration = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();

            registration.Grade = grade;
            registration.Notes = notes;
            db.SaveChanges();

            calculateGPA(registration.StudentId);
            db.SaveChanges();
        }

        /// <summary>
        /// Calculates the students Grade point average
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>grade point average</returns>
        private double calculateGPA(int studentId)
        {
            double totalGradePointValue = 0;
            double totalCreditHours = 0;

            IQueryable<Registration> grades = db.Registrations.Where(x => x.StudentId == studentId).Where(x => x.Grade != null);
            IQueryable<Registration> courses = db.Registrations.Where(x => x.StudentId == studentId).Where(x => x.Grade != null);

            foreach(Registration course in courses)
            {
                double grade = (double)course.Grade;

                CourseType courseType = BusinessRules.courseTypeLookup(course.Course.CourseType);
                double gradePointValue = BusinessRules.gradeLookup(grade, courseType);

                if(courseType != CourseType.AUDIT)
                {
                    totalGradePointValue += course.Course.CreditHours * gradePointValue;
                    totalCreditHours += course.Course.CreditHours;
                }
            }

            double gradePointAverage = totalGradePointValue / totalCreditHours;

            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();

            student.GradePointAverage = gradePointAverage;

            student.changeState();
            db.SaveChanges();

            return gradePointAverage;
        }
    }
}
