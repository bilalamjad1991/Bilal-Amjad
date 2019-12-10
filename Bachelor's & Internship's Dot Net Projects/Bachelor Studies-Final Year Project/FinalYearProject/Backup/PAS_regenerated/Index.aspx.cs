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
    public partial class Index : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["username"] = txtusername.Text;  // create session for user name
            Session["selection"] = user_selection.SelectedValue;


            //ViewState["username"] = txtusername.Text;
            // ViewState["selection"] = user_selection.SelectedValue;
            if (user_selection.SelectedValue == "-1")
            {
              
                show_msg.Text = "Please select a user";
            }
            
            else if (user_selection.SelectedValue == "1")
            {
                try
                {
                        SqlConnection conn = new SqlConnection(CS);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "SELECT * from admin_login where user_name='" + txtusername.Text.Trim() + "'" + "and password='" + txtuser_password.Text.Trim() + "'";
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {

                            conn.Close();
                            rdr.Close();
                            Response.Redirect("AdminPage.aspx");

                        }
                        else
                        {
                            show_msg.Text = "Incorrect User Name or Password";
                        }
                    


                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }


            else if (user_selection.SelectedValue == "2")
            {

                try
                {
                    
                    SqlConnection conn = new SqlConnection(CS);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * from pharmacist_login where user_name='" + txtusername.Text.Trim() + "'" + "and password='" + txtuser_password.Text.Trim() + "'";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {

                        conn.Close();
                        rdr.Close();
                        Response.Redirect("Bill.aspx");

                    }
                    else
                    {
                        show_msg.Text = "Incorrect User Name or Password";
                    }


                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(CS);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * from cashier_login where user_name='" + txtusername.Text.Trim() + "'" + "and password='" + txtuser_password.Text.Trim() + "'";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {

                        conn.Close();
                        rdr.Close();
                        Response.Redirect("Bill.aspx");

                    }
                    else
                    {
                        show_msg.Text = "Incorrect User Name or Password";
                    }


                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void lnkbtnFrgtPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotPassword.aspx");
        }
    }
}