//To all of the programming gods, please let my code work!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Data;

namespace BITCollege_JS.Models
{
        /// <summary>
        /// Student Model - corresponds to the table in the database
        /// </summary>
        public class Student
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int StudentId { get; set; }

            [Required]
            [ForeignKey("GPAState")]
            public int GPAStateId { get; set; }

            [ForeignKey("Program")]
            public int? ProgramId { get; set; }

            [Display(Name = "Student\nNumber")]
            public long StudentNumber { get; set; }

            [Required]
            [Display(Name = "First\nName")]
            [StringLength(35, MinimumLength = 1)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last\nName")]
            [StringLength(35, MinimumLength = 1)]
            public string LastName { get; set; }

            [Required]
            [StringLength(35, MinimumLength = 1)]
            public string Address { get; set; }

            [Required]
            [StringLength(35, MinimumLength = 1)]
            public string City { get; set; }

            [Required]
            [RegularExpression(@"^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK)$", ErrorMessage = "Please enter a valid Canadian Province abbreviation")]
            public string Province { get; set; }

            [Required]
            [RegularExpression(@"[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ]\s[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Please Enter a Valid Canadian Postal Code")]
            [Display(Name = "Postal\nCode")]
            public string PostalCode { get; set; }

            [Required]
            [Display(Name = "Date\nCreated")]
            [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}")]
            public DateTime DateCreated { get; set; }

            [Range(0.00, 4.50)]
            [Display(Name = "Grade\nPoint\nAverage")]
            public double? GradePointAverage { get; set; }

            [Range(0.00, 10000.00)]
            [Display(Name = "Outstanding\nFees")]
            [DisplayFormat(DataFormatString = "{0:c}")]
            public double OutstandingFees { get; set; }

            public string Notes { get; set; }

            /// <summary>
            /// returns the full name of the student
            /// </summary>
            [Display(Name ="Name")]
            public string FullName
            {
                get
                {
                    return String.Format("{0} {1}", FirstName, LastName);
                }
            }

            /// <summary>
            /// returns the full address of the student
            /// </summary>
            [Display(Name = "Address")]
            public string FullAddress
            {
                get
                {
                    return String.Format("{0} {1} {2}, {3}", Address, City, Province, PostalCode);
                }
            }

            /// <summary>
            /// increments the student number by one when a new student is added
            /// </summary>
            public void setNextStudentNumber()
            {
                long? studentNumber = StoredProcedures.nextNumber("NextStudentNumbers");

                if (studentNumber != null)
                    StudentNumber = (long)studentNumber;
            }

            /// <summary>
            /// Changes the state of the GPA depending on the students GPA and adjusts the tuition accordingly 
            /// </summary>
            public void changeState()
            {
                int oldGPA;
                int newGPA;

                do
                {
                    GPAState current = db.GPAStates.Find(GPAStateId);
                    oldGPA = GPAStateId;
                    current.stateChangeCheck(this);
                    current.tuitionRateAdjustment(this);
                    newGPA = GPAStateId;
                }while (oldGPA != newGPA);
            }

            public virtual ICollection<Registration> Registration { get; set; }
            public virtual Program Program { get; set; }
            public virtual GPAState GPAState { get; set; }
            public virtual ICollection<StudentCard> StudentCard { get; set; }
        }

        /// <summary>
        /// Program model - corresponds to the table in the database
        /// </summary>
        public class Program
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int ProgramId { get; set; }

            [Required]
            [Display(Name = "Program")]
            public string ProgramAcronym { get; set; }

            [Required]
            [Display(Name = "Program\nName")]
            public string Description { get; set; }

            public virtual ICollection<Student> Student { get; set; }
            public virtual ICollection<Course> Course { get; set; }           
        }

        /// <summary>
        /// Registration model - corresponds to the table in the database
        /// </summary>
        public class Registration
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int RegistrationId { get; set; }

            [Display(Name = "Registration\nNumber")]
            public long RegistrationNumber { get; set; }

            [Required]
            [ForeignKey("Student")]
            public int StudentId { get; set; }

            [Required]
            [ForeignKey("Course")]
            public int CourseId { get; set; }

            [Required]
            [Display(Name = "Registration\nDate")]
            [DisplayFormat(DataFormatString = "{0:MMM d, yyyy}")]
            public DateTime RegistrationDate { get; set; }
        
            [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Ungraded")]
            [Range(0, 100)]
            public double? Grade { get; set; }

            public string Notes { get; set; }

            /// <summary>
            /// empty Registration constructor
            /// </summary>
            public Registration()
            {

            }

            /// <summary>
            /// Increments the registration number by one after a new registration is added
            /// </summary>
            public void setNextRegistrationNumber()
            {
                long? registrationNumber = StoredProcedures.nextNumber("NextRegistrationNumbers");

                if (registrationNumber != null)
                    RegistrationNumber = (long)registrationNumber;
            }

            public virtual Course Course { get; set; }
            public virtual Student Student { get; set; }
        }

        /// <summary>
        /// Course model - corresponds to the table in the database
        /// </summary>
        public abstract class Course
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int CourseId { get; set; }

            [ForeignKey("Program")]
            public int? ProgramId { get; set; }

            [Display(Name = "Course\nNumber")]
            public String CourseNumber { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Credit\nHours")]
            public double CreditHours { get; set; }

            [Required]
            [Display(Name = "Tuition\nAmount")]
            [DisplayFormat(DataFormatString = "{0:c}")]
            public double TuitionAmount { get; set; }

            /// <summary>
            /// Returns the state of a course without the word Course on the end
            /// </summary>
            [Display(Name = "Course\nType")]
            public string CourseType
            {
                get
                {
                    return GetType().Name.Substring(0, (GetType().Name.LastIndexOf("Course")));
                }
            }

            public string Notes { get; set; }

            public abstract void setNextCourseNumber();
            

            public virtual ICollection<Registration> Registration { get; set; }
            public virtual Program Program { get; set; }
        }

        /// <summary>
        /// GradedCourse model - derives from the Course model and corresponds to the table in the database
        /// </summary>
        public class GradedCourse : Course
        {
            [Required]
            [Display(Name = "Assignment\nWeight")]
            [DisplayFormat(DataFormatString = "{0:p}")]
            public double AssignmentWeight { get; set; }

            [Required]
            [Display(Name = "Midterm\nWeight")]
            [DisplayFormat(DataFormatString = "{0:p}")]
            public double MidtermWeight { get; set; }

            [Required]
            [Display(Name = "Final\nWeight")]
            [DisplayFormat(DataFormatString = "{0:p}")]
            public double FinalWeight { get; set; }

            /// <summary>
            /// Incrementa the course number by 1 after every new course added. Puts 'G' in front for Graded Course
            /// </summary>
            public override void setNextCourseNumber()
            {
                long? courseNumber = StoredProcedures.nextNumber("NextGradedCourses");

                if (courseNumber != null)
                    CourseNumber = "G-" + courseNumber;
            }
        }

        /// <summary>
        /// AuditCourse model - derives from the Course model and corresponds to the table in the database
        /// </summary>
        public class AuditCourse : Course
        {
            /// <summary>
            /// Incrementa the course number by 1 after every new course added. Puts 'A' in front for Audit Course
            /// </summary>
            public override void setNextCourseNumber()
            {
                long? courseNumber = StoredProcedures.nextNumber("NextAuditCourses");

                if (courseNumber != null)
                    CourseNumber = "A-" + courseNumber;
            }
        }

        /// <summary>
        /// MasteryCourse model - derives from the Course model and corresponds to the table in the database
        /// </summary>
        public class MasteryCourse : Course
        {
            [Required]
            [Display(Name = "Maximum\nAttempts")]
            public int MaximumAttempts { get; set; }

            /// <summary>
            /// Incrementa the course number by 1 after every new course added. Puts 'M' in front for Mastery Course
            /// </summary>
            public override void setNextCourseNumber()
            {
                long? courseNumber = StoredProcedures.nextNumber("NextMasteryCourses");

                if (courseNumber != null)
                    CourseNumber = "M-" + courseNumber;
            }
        }

        /// <summary>
        /// GPAState model - corresponds to the table in the database
        /// </summary>
        public abstract class GPAState
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();
            
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int GPAStateId { get; set; }

            [Required]
            [Display(Name = "Lower\nLimit")]
            [DisplayFormat(DataFormatString = "{0:n2}")]
            public double LowerLimit { get; set; }

            [Required]
            [Display(Name = "Upper\nLimit")]
            [DisplayFormat(DataFormatString = "{0:n2}")]
            public double UpperLimit { get; set; }

            [Required]
            [Display(Name = "Tuition\nRate\nFactor")]
            [DisplayFormat(DataFormatString = "{0:n2}")]
            public double TuitionRateFactor { get; set; }

            /// <summary>
            /// Returns the state of a students GPA without the word State on the end
            /// </summary>
            [Display(Name = "GPA\nState")]
            public string Description
            {
                get
                {
                    return GetType().Name.Substring(0, (GetType().Name.LastIndexOf("State")));
                }
            }

            public virtual double tuitionRateAdjustment(Student student)
            {
                return 0;
            }

            public virtual void stateChangeCheck(Student student)
            {

            }

            public virtual ICollection<Student> Student { get; set; }
        }

        /// <summary>
        /// RegularState model - derives from the GPAState model and corresponds to the table in the database
        /// </summary>
        public class RegularState : GPAState
        {
            private static RegularState regularState { get; set; }

            /// <summary>
            /// private RegularState constructor setting the lower limit, upper limit, and tuition rate factor
            /// </summary>
            private RegularState()
            {
                LowerLimit = 2.00;
                UpperLimit = 3.70;
                TuitionRateFactor = 1.00;
            }

            /// <summary>
            /// Makes sure there is an instance of RegularState in the db, if no instance, it creates one
            /// </summary>
            /// <returns>regularState</returns>
            public static RegularState getInstance()
            {
                if(regularState == null)
                {
                    regularState = db.RegularStates.SingleOrDefault();

                    if(regularState == null)
                    {
                        regularState = new RegularState();
                        db.RegularStates.Add(regularState);
                        db.SaveChanges();
                    }
                }
                return regularState;
            }

            /// <summary>
            /// adjusts the tuition for RegularState
            /// </summary>
            /// <param name="student"></param>
            /// <returns>tuitionRateAdujustment</returns>
            public override double tuitionRateAdjustment(Student student)
            {
                return base.tuitionRateAdjustment(student);
            }

            /// <summary>
            /// Checks the GPAState and changes it accordingly
            /// </summary>
            /// <param name="student"></param>
            public override void stateChangeCheck(Student student)
            {
                if(student.GradePointAverage < LowerLimit)
                {
                    student.GPAStateId = ProbationState.getInstance().GPAStateId;
                }
                else if(student.GradePointAverage > UpperLimit)
                {
                    student.GPAStateId = HonoursState.getInstance().GPAStateId;
                }
            }
        }

        /// <summary>
        /// HonoursState model - derives from the GPAState model and corresponds to the table in the database
        /// </summary>
        public class HonoursState : GPAState
        {
            private static HonoursState honoursState { get; set; }

            /// <summary>
            /// private HonoursState constructor setting the lower limit, upper limit, and tuition rate factor
            /// </summary>
            private HonoursState()
            {
                LowerLimit = 3.70;
                UpperLimit = 4.50;
                TuitionRateFactor = 0.90;
            }

            /// <summary>
            /// Makes sure there is an instance of HonoursState in the db, if no instance, it creates one
            /// </summary>
            /// <returns>honoursState</returns>
            public static HonoursState getInstance()
            {
                if (honoursState == null)
                {
                    honoursState = db.HonoursStates.SingleOrDefault();

                    if (honoursState == null)
                    {
                        honoursState = new HonoursState();
                        db.HonoursStates.Add(honoursState);
                        db.SaveChanges();
                    }
                }
                return honoursState;
            }

            /// <summary>
            /// adjusts the tuition for HonoursState. if the student has a GPA higher than 4.25 tuition gets lowered by 17%, if the student is taking more than 5 courses, the tuition is lowered by 15%
            /// </summary>
            /// <param name="student"></param>
            /// <returns>tuitionRateAdujustment</returns>
            public override double tuitionRateAdjustment(Student student)
            {
                double tuitionRF = this.TuitionRateFactor;

                IQueryable<Registration> query = from Grade in db.Registrations
                                                 where Grade != null
                                                 where Grade.StudentId == student.StudentId
                                                 select Grade;

                if (query.Count() > 5 && student.GradePointAverage > 4.25)
                {
                    return tuitionRF -= 0.17;
                }

                if (query.Count() > 5)
                {
                    return tuitionRF -= 0.15;
                }

                return base.tuitionRateAdjustment(student);
            }

            /// <summary>
            /// Checks the GPAState and changes it accordingly
            /// </summary>
            /// <param name="student"></param>
            public override void stateChangeCheck(Student student)
            {
                if (student.GradePointAverage < LowerLimit)
                {
                    student.GPAStateId = RegularState.getInstance().GPAStateId;
                }
            }
        }

        /// <summary>
        /// ProbationState model - derives from the GPAState model and corresponds to the table in the database
        /// </summary>
        public class ProbationState : GPAState
        {
            private static ProbationState probationState { get; set; }

            /// <summary>
            /// private ProbationState constructor setting the lower limit, upper limit, and tuition rate factor
            /// </summary>
            private ProbationState()
            {
                LowerLimit = 1.00;
                UpperLimit = 2.00;
                TuitionRateFactor = 1.075;
            }

            /// <summary>
            /// Makes sure there is an instance of ProbationState in the db, if no instance, it creates one
            /// </summary>
            /// <returns>probationState</returns>
            public static ProbationState getInstance()
            {
                if (probationState == null)
                {
                    probationState = db.ProbationStates.SingleOrDefault();

                    if (probationState == null)
                    {
                        probationState = new ProbationState();
                        db.ProbationStates.Add(probationState);
                        db.SaveChanges();
                    }
                }
                return probationState;
            }

            /// <summary>
            /// adjusts the tuition for ProbationState
            /// </summary>
            /// <param name="student"></param>
            /// <returns>tuitionRateAdujustment</returns>
            public override double tuitionRateAdjustment(Student student)
            {
                double tuitionRF = this.TuitionRateFactor;

                IQueryable<Registration> query = from Grade in db.Registrations
                                                 where Grade != null
                                                 where Grade.StudentId == student.StudentId
                                                 select Grade;

                if(query.Count() > 5)
                {
                    return tuitionRF += 0.035;
                }

                return base.tuitionRateAdjustment(student);
            }

            /// <summary>
            /// Checks the GPAState and changes it accordingly
            /// </summary>
            /// <param name="student"></param>
            public override void stateChangeCheck(Student student)
            {
                if (student.GradePointAverage < LowerLimit)
                {
                    student.GPAStateId = SuspendedState.getInstance().GPAStateId;
                }
                else if (student.GradePointAverage > UpperLimit)
                {
                    student.GPAStateId = RegularState.getInstance().GPAStateId;
                }
            }
        }

        /// <summary>
        /// SuspendedState model - derives from the GPAState model and corresponds to the table in the database
        /// </summary>
        public class SuspendedState : GPAState
        {
            private static SuspendedState suspendedState { get; set; }

            /// <summary>
            /// private SuspendedState constructor setting the lower limit, upper limit, and tuition rate factor
            /// </summary>
            private SuspendedState()
            {
                LowerLimit = 0.00;
                UpperLimit = 1.00;
                TuitionRateFactor = 1.10;
            }

            /// <summary>
            /// Makes sure there is an instance of SuspendedState in the db, if no instance, it creates one
            /// </summary>
            /// <returns>suspendedState</returns>
            public static SuspendedState getInstance()
            {
                if (suspendedState == null)
                {
                    suspendedState = db.SuspendedStates.SingleOrDefault();

                    if (suspendedState == null)
                    {
                        suspendedState = new SuspendedState();
                        db.SuspendedStates.Add(suspendedState);
                        db.SaveChanges();
                    }
                }
                return suspendedState;
            }

            /// <summary>
            /// adjusts the tuition for SuspendedState
            /// </summary>
            /// <param name="student"></param>
            /// <returns>tuitionRateAdujustment</returns>
            public override double tuitionRateAdjustment(Student student)
            {
                if(student.GradePointAverage < 0.75 && student.GradePointAverage > 0.50)
                {
                    return TuitionRateFactor += 0.02;
                }

                else if (student.GradePointAverage < 0.50)
                {
                    return TuitionRateFactor += 0.05;
                }
                return base.tuitionRateAdjustment(student);
            }

            /// <summary>
            /// Checks the GPAState and changes it accordingly
            /// </summary>
            /// <param name="student"></param>
            public override void stateChangeCheck(Student student)
            {
                if (student.GradePointAverage > UpperLimit)
                {
                    student.GPAStateId = ProbationState.getInstance().GPAStateId;
                }
            }
        }

        /// <summary>
        /// StudentCard model - corresponds to the table in the db
        /// </summary>
        public class StudentCard
        {
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int StudentCardId { get; set; }

            public long CardNumber { get; set; }

            [Required]
            [ForeignKey("Student")]
            public int StudentId { get; set; }

            public virtual Student Student { get; set; }
        }

        /// <summary>
        /// NextStudentNumber - corresponds to the table in the db
        /// </summary>
        public class NextStudentNumber
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int NextStudentNumberId { get; set; }
            
            public long NextAvailableNumber { get; set; }

            private static NextStudentNumber nextStudentNumber { get; set; }

            /// <summary>
            /// consructor for NextStudentNumber, sets Next available number to 20000000
            /// </summary>
            private NextStudentNumber()
            {
                NextAvailableNumber = 20000000;
            }

            /// <summary>
            /// gets the instance of nextstudentcard, if no instance, one is created
            /// </summary>
            /// <returns>nextStudentNumber</returns>
            public static NextStudentNumber getInstance()
            {
                if (nextStudentNumber == null)
                {
                    nextStudentNumber = db.NextStudentNumbers.SingleOrDefault();

                    if (nextStudentNumber == null)
                    {
                        nextStudentNumber = new NextStudentNumber();
                        db.NextStudentNumbers.Add(nextStudentNumber);
                        db.SaveChanges();
                    }
                }
                    return nextStudentNumber;
            }
        
        }

        /// <summary>
        /// NextRegistrationNumber model - corresponds to the table in the db
        /// </summary>
        public class NextRegistrationNumber
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int NextRegistrationNumberId { get; set; }

            public long NextAvailableNumber { get; set; }

            private static NextRegistrationNumber nextRegistrationNumber { get; set; }

            /// <summary>
            /// consructor for NextRgistrationNumber, sets Next available number to 700
            /// </summary>
            private NextRegistrationNumber()
            {
                NextAvailableNumber = 700;
            }

            /// <summary>
            /// gets the instance of nextRegistrationNumber, if no instance, one is created
            /// </summary>
            /// <returns>nextRegistrationNumber</returns>
            public static NextRegistrationNumber getInstance()
            {
                if (nextRegistrationNumber == null)
                {
                    nextRegistrationNumber = db.NextRegistrationNumbers.SingleOrDefault();

                    if (nextRegistrationNumber == null)
                    {
                        nextRegistrationNumber = new NextRegistrationNumber();
                        db.NextRegistrationNumbers.Add(nextRegistrationNumber);
                        db.SaveChanges();
                    }
                }
                return nextRegistrationNumber;
            }
        }

        /// <summary>
        /// NextGradedCourse model - corresponds to the table in the db
        /// </summary>
        public class NextGradedCourse
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int NextGradedCourseId { get; set; }

            public long NextAvailableNumber { get; set; }

            private static NextGradedCourse nextGradedCourse { get; set; }

            /// <summary>
            /// consructor for NextGradedCourse, sets Next available number to 200000
            /// </summary>
            private NextGradedCourse()
            {
                NextAvailableNumber = 200000;
            }

            /// <summary>
            /// gets the instance of nextGradedCourse, if no instance, one is created
            /// </summary>
            /// <returns>nextGradedCourse</returns>
            public static NextGradedCourse getInstance()
            {
                if (nextGradedCourse == null)
                {
                    nextGradedCourse = db.NextGradedCourses.SingleOrDefault();

                    if (nextGradedCourse == null)
                    {
                        nextGradedCourse = new NextGradedCourse();
                        db.NextGradedCourses.Add(nextGradedCourse);
                        db.SaveChanges();
                    }
                }
                return nextGradedCourse;
            }
        }
        /// <summary>
        /// NextAuditCourse model - corresponds to the table in the db
        /// </summary>
        public class NextAuditCourse
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int NextAuditCourseId { get; set; }

            public long NextAvailableNumber { get; set; }

            private static NextAuditCourse nextAuditCourse { get; set; }

            /// <summary>
            /// consructor for NextAuditCourse, sets Next available number to 2000
            /// </summary>
            private NextAuditCourse()
            {
                NextAvailableNumber = 2000;
            }

            /// <summary>
            /// gets the instance of nextAuditCourse, if no instance, one is created
            /// </summary>
            /// <returns>nextAuditCourse</returns>
            public static NextAuditCourse getInstance()
            {
                if (nextAuditCourse == null)
                {
                    nextAuditCourse = db.NextAuditCourses.SingleOrDefault();

                    if (nextAuditCourse == null)
                    {
                        nextAuditCourse = new NextAuditCourse();
                        db.NextAuditCourses.Add(nextAuditCourse);
                        db.SaveChanges();
                    }
                }
                return nextAuditCourse;
            }
        }

        /// <summary>
        /// NextMasteryCourse model - corresponds to the table in the db
        /// </summary>
        public class NextMasteryCourse
        {
            protected static BITCollege_JSContext db = new BITCollege_JSContext();

            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int NextMasteryCourseId { get; set; }

            public long NextAvailableNumber { get; set; }

            private static NextMasteryCourse nextMasteryCourse { get; set; }

            /// <summary>
            /// consructor for NextMasteryCourse, sets Next available number to 200000
            /// </summary>
            private NextMasteryCourse()
            {
                NextAvailableNumber = 20000;
            }

            /// <summary>
            /// gets the instance of nextMasteryCourse, if no instance, one is created
            /// </summary>
            /// <returns>nextMasteryCourse</returns>
            public static NextMasteryCourse getInstance()
            {
                if (nextMasteryCourse == null)
                {
                    nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();

                    if (nextMasteryCourse == null)
                    {
                        nextMasteryCourse = new NextMasteryCourse();
                        db.NextMasteryCourses.Add(nextMasteryCourse);
                        db.SaveChanges();
                    }
                }
                return nextMasteryCourse;
            }
        }

        /// <summary>
        /// StoredProcedures model - creates and executes an sql command in the db
        /// </summary>
        public static class StoredProcedures
        {
            public static long? nextNumber(string tableName)
            {
                //creates new connection to sql server
                SqlConnection connection = new SqlConnection("Data Source=localhost;" +
                        "Initial Catalog=BITCollege_JSContext; Integrated Security=True");

                //temporary variabe for return value
                long? returnValue = 0;

                //create a new sql command
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                //sets the stored procedure to commandtype stored procedure
                storedProcedure.CommandType = CommandType.StoredProcedure;

                //add paramter TableName to the procedure
                storedProcedure.Parameters.AddWithValue("@TableName", tableName);

                //creates a new sql parameter outputParameter, sets direction to output
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                //adds outputParameter to the storedProcedure
                storedProcedure.Parameters.Add(outputParameter);

                //opens the sql connection
                connection.Open();

                //runs the created sql command on the db
                storedProcedure.ExecuteNonQuery();

                //closes the connection
                connection.Close();

                //sets the outputParameter value to returnValue
                returnValue = (long?)outputParameter.Value;

                //returns returnValue
                return returnValue;
            }
        }
    }