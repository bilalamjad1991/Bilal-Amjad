using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SearchConsole_Module
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentData(null);
            }

        }
        private void GetStudentData(string StudentName)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
               if(!string.IsNullOrEmpty(StudentName))
               {
                   SqlParameter parameter = new SqlParameter("@StudentName", StudentName);
                    cmd.Parameters.Add(parameter);
               }
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                gvStudents.DataSource = rdr;
                gvStudents.DataBind();
            }
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetStudentData(txtStudentName.Text);
        }

        protected void gvStudents_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvStudents_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
           
        }

       
    }
}