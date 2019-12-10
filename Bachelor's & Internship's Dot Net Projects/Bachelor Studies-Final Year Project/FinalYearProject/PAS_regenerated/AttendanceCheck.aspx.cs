using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace PAS_regenerated
{
    public partial class AttendanceCheck : System.Web.UI.Page
    {
        string cs=ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }

                else if (Session["selection"].ToString() == "1")
                {
                    lnkbtnRegister.Visible = true;
                }
                //Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }

            txtemp.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection connn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();

                SqlCommand cmddd = new SqlCommand();

                cmd.CommandText = "SELECT EmpId from EmployeeAttendance WHERE EmpId='" + txtemp.Text.Trim() + "' ";
                cmd.Connection = connn;

                cmddd.CommandText = "SELECT count(dateToday) from EmployeeAttendance WHERE EmpId='" + txtemp.Text.Trim() + "' " + " and DATEPART(mm,dateToday)='" + DropDownList1.SelectedValue.ToString() + "' " + " and DATEPART(yyyy,dateToday)='" + txtYear.Text.Trim() + "'";
                //cmddd.Connection = connn;
                connn.Open();
                // DATEPART(yyyy,dateToday)

                //if (DropDownList1.SelectedValue == "-1")
                //{
                //    lblTotalPresent.Visible = false;
                //    lblErr.Visible = true;
                //    lblErr.Text = "* Please select a month";
                //}

               
                    //lblErr.Visible = false;
                   
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //     SqlDataReader rdrrr = cmddd.ExecuteReader();
                    if (rdr.Read())   //check employee id exist
                    {
                        lblErr1.Visible = false;
                        rdr.Close();
                        //connn.Close();
                         if (DropDownList1.SelectedValue == "-1")
                         {
                             lblTotalPresent.Visible = false;
                             lblErr.Visible = true;
                             lblErr.Text = "* Please select a month";
                         }
                        else
                         {
                             cmddd.Connection = connn;
                             SqlDataReader rdrrr = cmddd.ExecuteReader();
                             if (rdrrr.Read())
                             {
                                 lblErr.Visible = false;
                                 lblErr1.Visible = false;
                                 lblTotalPresent.Visible = true;
                                 lblTotalPresent.Text = "Total Presents : " + rdrrr[0].ToString() + " Days";
                                 rdrrr.Close();
                                 connn.Close();
                             }
                         }
                       
                    }

                    else
                    {
                        lblTotalPresent.Visible = false;
                        lblErr1.Visible = true;
                        lblErr1.Text = "Invalid Employee";
                       
                        rdr.Close();
                        connn.Close();

                    }
                }
            
            catch(Exception exx)
            {
                lblTotalPresent.Visible = false;
                lblErr1.Visible = true;
                lblErr1.Text = "Invalid Employee";
                exx.ToString();
                

            }

        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void lnkbtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
        }

        protected void lnkbtnSignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Index.aspx");
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }
                else if (Session["selection"].ToString() == "2")
                {
                    Response.Redirect("Bill.aspx");
                }
                else if (Session["selection"].ToString() == "1")
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                //Response.Redirect("Index.aspx");
                ex.ToString();

            }
        }
    }
}