using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace PAS_regenerated
{
    public partial class AttendanceTimeIn : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblShowDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            lblDate.Text = DateTime.Now.ToShortDateString();  //2014/02/01 in db
            lblTime.Text = DateTime.Now.ToShortTimeString();   // 01:07:00.0000000 am
            // lblTimeout.Text = DateTime.Now.ToShortTimeString();
            // lblDate.Text = DateTime.Now.ToLongTimeString();
            txtID.Focus();
        }

        protected void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();

                // where user_name='" + txtusername.Text.Trim() + "'" + "and password='" + txtuser_password.Text.Trim() + "'"
                //   cmd.CommandText = "SELECT * from emp2 where empID='" + txtID.Text.Trim() + "'";
                cmd.CommandText = "select EmpId from admin_login where EmpId='" + txtID.Text.Trim() + "' union select EmpId from cashier_login where EmpId='" + txtID.Text.Trim() + "' union select EmpId from pharmacist_login where EmpId='" + txtID.Text.Trim() + "' ";
                cmd2.CommandText = "SELECT * from EmployeeAttendance where EmpId='" + txtID.Text.Trim() + "'" + " and dateToday ='" + lblDate.Text.Trim() + "'";

                cmd.Connection = conn;
                cmd2.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)  // check if employee exist 
                {
                    rdr.Close();
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    if (rdr2.HasRows) // check if attendance is already marked
                    {
                        lblstatus.Visible = true;
                        //lblempstatus.Visible = true;
                        lblstatus.Text = "Attendace already added";

                        //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "Script", "callMyJSFunction();", true);
                        //  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", "<script>alert('hi');</script>");
                        rdr2.Close();

                    }
                    else
                    {
                        //conn.Close();
                        rdr2.Close();
                        //conn.Open();
                        //    SqlCommand scmd = new SqlCommand(" INSERT INTO temp (empID,datein) VALUES('" + txtID.Text + "','" + lblDate.Text + "')", conn);
                        SqlCommand scmd = new SqlCommand(" INSERT INTO EmployeeAttendance (EmpId,timeIn,dateToday) VALUES('" + txtID.Text + "','" + lblTime.Text + "','" + lblDate.Text + "')", conn);
                        scmd.ExecuteNonQuery();
                        lblstatus.Visible = true;
                        lblstatus.Text = "Attendance saved";

                    }
                    conn.Close();

                }


                else
                {
                    lblstatus.Visible = true;
                    lblstatus.Text = "Employee does not exist";
                    txtID.Text = "";
                    conn.Close();
                    rdr.Close();

                }
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
                ///////////////////////////////////////////////////////////////////////////////////////
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
                //else { }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Index.aspx");
                ex.ToString();

            }
        }
    }
}