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
    public partial class changePassword : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "3")
                {
                   // lnkbtnRegister.Visible = true;
                  //  lnkbtnRegister.Enabled = false;

                   
                }

                else if (Session["selection"].ToString() == "1")
                {
                    lnkbtnRegister.Visible = true;
                    lnkbtnRegister.Enabled = true;
                    //lbltest.Text=Session["username"].ToString();
                }
                else if (Session["selection"].ToString() == "2")
                {
                   //some text
                }
                //Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
            
        }

        protected void pwdUpdate_Click(object sender, EventArgs e)
        {
            string userName = Session["username"].ToString();
            string selectedindex = Session["selection"].ToString();
            //lbltest.Text = userName;
            if (txtuser_oldpassword.Text.Trim() != "" && txtuser_newpassword.Text.Trim() != "" && txtuser_cnfrmpassword.Text.Trim() != "")
            {
                if (selectedindex == "1")
                {

                    try
                    {
                        SqlConnection conn = new SqlConnection(CS);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "SELECT * from admin_login where user_name='" + userName.Trim() + "'" + "and password='" + txtuser_oldpassword.Text.Trim() + "'";
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Close();
                            cmd.CommandText = "UPDATE admin_login SET [password]='" + txtuser_newpassword.Text.Trim() + "' where user_name='" + userName.Trim() + "'";

                            cmd.ExecuteNonQuery();
                            conn.Close();
                            // rdr.Close();
                            show_msg.Text = "Updated!";

                        }
                        else
                        {
                            show_msg.Text = "Old Password does not match!";
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }


                else if (selectedindex == "2")
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(CS);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "SELECT * from pharmacist_login where user_name='" + userName + "'" + "and password='" + txtuser_oldpassword.Text.Trim() + "'";
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Close();
                            cmd.CommandText = "UPDATE phamacist_login SET [password]='" + txtuser_newpassword.Text.Trim() + "' where user_name='" + userName + "'";
                            cmd.ExecuteNonQuery();                      
                            conn.Close();
                            show_msg.Text = "Updated!";

                        }
                        else
                        {
                            show_msg.Text = "Old Password does not match!";
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
                        cmd.CommandText = "SELECT * from cashier_login where user_name='" + userName + "'" + "and password='" + txtuser_oldpassword.Text.Trim() + "'";
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Close();
                            cmd.CommandText = "UPDATE cashier_login SET [password]='" + txtuser_newpassword.Text.Trim() + "' where user_name='" + userName + "'";
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            
                            show_msg.Text = "Updated!";

                        }
                        else
                        {
                            show_msg.Text = "Old Password does not match!";
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            else
            {
                show_msg.Text = "Some fields are missing!";
            }
        }

        protected void lnkbtnSignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Index.aspx");
        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
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