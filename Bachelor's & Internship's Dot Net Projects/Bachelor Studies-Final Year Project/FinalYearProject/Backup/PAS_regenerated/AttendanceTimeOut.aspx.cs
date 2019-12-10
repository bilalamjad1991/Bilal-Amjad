using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PAS_regenerated
{
    public partial class AttendanceTimeOut : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate1.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"); //2014/02/01 in db
            lblDates.Text = DateTime.Now.ToShortDateString();   // just date only
            lblTimeout1.Text = DateTime.Now.ToShortTimeString();
            txtEmpId.Focus();

        }

        protected void btnSaveTimeOut_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(CS);

                SqlCommand cmd2 = new SqlCommand();

                // where user_name='" + txtusername.Text.Trim() + "'" + "and password='" + txtuser_password.Text.Trim() + "'"

                cmd2.CommandText = "SELECT * from EmployeeAttendance where EmpId='" + txtEmpId.Text.Trim() + "'" + " and dateToday ='" + lblDates.Text.Trim() + "'";

                //  cmd.Connection = conn;
                cmd2.Connection = conn;
                conn.Open();
                SqlDataReader rdr3 = cmd2.ExecuteReader();

                if (rdr3.HasRows)
                {
                    rdr3.Close();
                    SqlCommand scmd1 = new SqlCommand("UPDATE EmployeeAttendance SET timeOut='" + lblTimeout1.Text + "' where EmpId='" + txtEmpId.Text.Trim() + "'" + " and dateToday ='" + lblDates.Text.Trim() + "'", conn);
                    scmd1.ExecuteNonQuery();
                    lblTimeout1.Visible = true;
                    lblTimeout1.Text = "Attendace Saved";

                    conn.Close();
                }
                else
                {
                    lblTimeout1.Visible = true;
                    lblTimeout1.Text = "Invalid Employee ID";
                    rdr3.Close();
                    conn.Close();

                }
                conn.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        //
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)
                {
                    if (Session["selection"].ToString() == "3")
                    {
                        Response.Redirect("Cashier.aspx");
                    }

                    else if (Session["selection"].ToString() == "1")
                    {
                        Response.Redirect("AdminPage.aspx");
                    }

                    else if (Session["selection"].ToString() == "2")
                    {
                        Response.Redirect("Bill.aspx");
                    }
                    //Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
                /////////////////////////////////////////////////////////////////////
                //if (Session["selection"].ToString() == "3")
                //{
                //    Response.Redirect("Cashier.aspx");
                //}
                //else if (Session["selection"].ToString() == "2")
                //{
                //    Response.Redirect("Bill.aspx");
                //}
                //else if (Session["selection"].ToString() == "1")
                //{
                //    Response.Redirect("AdminPage.aspx");
                //}
                //else
                //{

                //}

            }
            catch (Exception ex)
            {
                //Response.Redirect("Index.aspx");
                ex.ToString();

            }
        }
    }
}