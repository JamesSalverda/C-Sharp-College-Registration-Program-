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
    /// Class shows the courses the student is registered in
    /// </summary>
    public partial class wfStudent : System.Web.UI.Page
    {
        BITCollege_JSContext db = new BITCollege_JSContext();

        /// <summary>
        /// obtains a collection of Course records for which the student has registered and bind this result set the GridView control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                try
                {

                    int studentNumber = int.Parse(Page.User.Identity.Name.Substring(0, Page.User.Identity.Name.IndexOf('@')));

                    

                   Student studentNumQuery =
                          (from student in db.Students
                          where student.StudentNumber == studentNumber
                          select student).SingleOrDefault();
                    Session["studentNum"] = studentNumQuery;

                    IQueryable<Registration> studentRegistration =
                        from registration in db.Registrations
                        where registration.StudentId == studentNumQuery.StudentId
                        select registration;

                    lblName.Text = studentNumQuery.FullName;
                    gvCourse.DataSource = studentRegistration.ToList();
                    this.DataBind();
                }
                catch (Exception errors)
                {
                    lblStudentError.Text = errors.Message;
                    lblStudentError.Visible = true;
                }
            }
            else
            {
                Response.Redirect("/Account/Login");
            }
        }

        /// <summary>
        /// Sets a Session Variable to the value of the selected Course Number data item and redirects the user to wfDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SelectedIndexChange(object sender, EventArgs e)
        {
            Session["courseNum"] = gvCourse.Rows[gvCourse.SelectedIndex].Cells[1].Text;
            Response.Redirect("wfDrop.aspx");
        }

        /// <summary>
        /// Redirects the user to wfRegister
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbuRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfRegister.aspx");
        }
    }
}