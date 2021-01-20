using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_JS;
using BITCollege_JS.Models;

namespace BITCollegeSite
{
    /// <summary>
    /// Shows the selected course, the courses information, and gives the user to option to drop the course
    /// </summary>
    public partial class wfDrop : System.Web.UI.Page
    {
        BITCollege_JSContext db = new BITCollege_JSContext();

        /// <summary>
        /// use session varilables from wfStudent and LINQ to SQL to populate the GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BITCollege_JSContext db = new BITCollege_JSContext();

            if (Page.User.Identity.IsAuthenticated)
            {
                try
                {
                    string courseNumber = Session["courseNum"].ToString();
                    Student student = (Student)Session["studentNum"];

                    int courseId =
                        (from course in db.Courses
                        where course.CourseNumber == courseNumber
                        select course.CourseId).SingleOrDefault();

                   IQueryable<Registration> registration =
                        (from registrations in db.Registrations
                         where registrations.CourseId == courseId
                         where registrations.StudentId == student.StudentId
                         select registrations);

                    dvDrop.DataSource = registration.ToList();
                    this.DataBind();

                    
                }
                catch (Exception errors)
                {
                    lblDropError.Text = errors.Message;
                    lblDropError.Visible = true;
                }

                this.DataBind();

                if(dvDrop.Rows[4].Cells[1].Text == "&nbsp;")
                {
                    lbuDropCourse.Enabled = true;
                    lbuDropCourse.Visible = true;
                }
                else
                {
                    lbuDropCourse.Enabled = false;
                    lbuDropCourse.Visible = false;
                }
            }
            else
            {
                Response.Redirect("/Account/Login");
            }

        }

        /// <summary>
        /// creates a paginated report if the student has multiple registrations in the same course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dvDrop_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            BITCollege_JSContext db = new BITCollege_JSContext();

            string courseNumber = Session["courseNum"].ToString();
            Student student = (Student)Session["studentNum"];

            int courseId =
                (from course in db.Courses
                 where course.CourseNumber == courseNumber
                 select course.CourseId).SingleOrDefault();

            IQueryable<Registration> registration =
                (from registrations in db.Registrations
                 where registrations.CourseId == courseId
                 where registrations.StudentId == student.StudentId
                 select registrations);

            dvDrop.DataSource = registration.ToList();
            dvDrop.PageIndex = e.NewPageIndex;
            this.DataBind();

            if (dvDrop.Rows[4].Cells[1].Text == "&nbsp;")
            {
                lbuDropCourse.Enabled = true;
                lbuDropCourse.Visible = true;
            }
            else
            {
                lbuDropCourse.Enabled = false;
                lbuDropCourse.Visible = false;
            }
        }

        /// <summary>
        /// redirects the user to wfStudent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbuRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("/wfStudent.aspx");
        }

        /// <summary>
        /// Drops the course currantly shown in the DetailsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbuDropCourse_Click(object sender, EventArgs e)
        {
            ServiceReference1.CollegeRegistrationClient serviceReference = new ServiceReference1.CollegeRegistrationClient();

            serviceReference.dropCourse(int.Parse(dvDrop.Rows[0].Cells[1].Text));

            Response.Redirect("/wfStudent.aspx");
        }
    }
}