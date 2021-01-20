using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_JS.Models;

namespace BITCollegeSite
{
    /// <summary>
    /// Form to allow the user to register for a course
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        BITCollege_JSContext db = new BITCollege_JSContext();

        /// <summary>
        /// Displays the students name, courses, and text box for notes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BITCollege_JSContext db = new BITCollege_JSContext();

                    Student student = (Student)Session["studentNum"];

                    lblStudentName.Text = student.FullName;

                    IQueryable<Course> courses = db.Courses.Where(x => x.ProgramId == student.ProgramId);

                    ddlCourses.DataSource = courses.ToList();
                    ddlCourses.DataTextField = "Title";
                    ddlCourses.DataValueField = "CourseId";
                    this.DataBind();
                }
                catch (Exception errors)
                {
                    lblError.Text = errors.Message;
                    lblError.Visible = true;
                }
            }
            
        }

        /// <summary>
        /// grabs the inputted values and registers the student for the selected course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbuRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRegistrationNotes.Text == "")
                {

                }
                else
                {
                    Student currantStudent = (Student)Session["studentNum"];

                    ServiceReference1.CollegeRegistrationClient collegeRegistrationClient = new ServiceReference1.CollegeRegistrationClient();

                    int errorCode = collegeRegistrationClient.registerCourse(currantStudent.StudentId, int.Parse(ddlCourses.SelectedValue), txtRegistrationNotes.Text);

                    if(errorCode != 0)
                    {
                        lblError.Text = Utility.BusinessRules.registerError(errorCode);
                        lblError.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("/wfStudent.aspx");
                    }
                }
            }
            catch (Exception errors)
            {
                lblError.Text = errors.Message;
                lblError.Visible = true;
            }
        }

        /// <summary>
        /// redirects the user to wfStudent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbuReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/wfStudent.aspx");
        }
    }
}