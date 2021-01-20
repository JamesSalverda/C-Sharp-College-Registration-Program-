using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class BITCollege_JSContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public BITCollege_JSContext() : base("name=BITCollege_JSContext")
    {
    }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.GPAState> GPAStates { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.Course> Courses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.Program> Programs { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.Registration> Registrations { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.Student> Students { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.GradedCourse> GradedCourses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.AuditCourse> AuditCourses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.MasteryCourse> MasteryCourses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.RegularState> RegularStates { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.HonoursState> HonoursStates { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.ProbationState> ProbationStates { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.SuspendedState> SuspendedStates { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.StudentCard> StudentCards { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.NextRegistrationNumber> NextRegistrationNumbers { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.NextStudentNumber> NextStudentNumbers { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.NextAuditCourse> NextAuditCourses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.NextGradedCourse> NextGradedCourses { get; set; }

    public System.Data.Entity.DbSet<BITCollege_JS.Models.NextMasteryCourse> NextMasteryCourses { get; set; }
}
