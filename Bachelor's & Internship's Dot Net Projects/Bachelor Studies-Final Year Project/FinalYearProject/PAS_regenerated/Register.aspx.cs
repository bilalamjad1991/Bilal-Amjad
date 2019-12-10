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
    public partial class Register : System.Web.UI.Page
    {
        //string source = "Data Source=WAQAR-PC\\SQLEXPRESS;Initial Catalog=pharmacy;Integrated Security=True";
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }
                else if(Session["selection"].ToString()=="2")
                {
                    lnkbtnRegister.Visible = false;
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
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            txtDOJ.Text = date;

            txtUser.Focus();
            this.generateEmpId();
              
        }
        // SQL QUERY alter table [Pharmacy].[dbo].[pharmacist_login] add EmpId int NOT NULL Default 0
        private void clearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUser.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPwd.Text = "";
            txtCnfrmPwd.Text = "";
            txtDOB.Text = "";
            select_user_registration.SelectedIndex = -1;
 
        }
        private void generateEmpId()
        {
            try
            {
                SqlConnection conI = new SqlConnection(CS);
                SqlCommand cmdI = new SqlCommand();
               cmdI.CommandText=  "SELECT MAX(T.eID)+1 AS EmpID FROM (SELECT Max(EmpId) AS eID FROM admin_login UNION ALL SELECT Max(EmpId) AS eID FROM cashier_login UNION ALL SELECT Max(EmpId) As eID FROM pharmacist_login) AS T ";
             //  cmdI.CommandText = "Select Max(EmpId)+1 from admin_login union Select Max(EmpId)+1 from cashier_login union Select Max(EmpId)+1 from pharmacist_login";
                cmdI.Connection = conI;
                conI.Open();
                SqlDataReader rdr = cmdI.ExecuteReader();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        //TextBox1.Text = rdr.GetString(0);
                        txtEmpId.Text = rdr[0].ToString();

                    }
                    else
                    {
                        txtEmpId.Text = "1";

                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }
       

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (select_user_registration.SelectedValue == "-1")
            {
                rgstr_msglbl.Text = "Please select a user";
            }
            else if (select_user_registration.SelectedValue == "1")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(CS);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select user_name from admin_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from cashier_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from pharmacist_login where user_name='" + txtUser.Text.Trim() + "' ";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        conn.Close();
                        rdr.Close();
                       // rgstr_msglbl.Text = (txtUser.Text.Trim() + " already Exist!");
                    }



                    else
                    {
                        if (txtPwd.Text.Trim() == txtCnfrmPwd.Text.Trim())
                        {
                            if (txtUser.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtAddress.Text.Trim() != "" && txtPwd.Text.Trim() != "" && txtCnfrmPwd.Text.Trim() != "")
                            {
                                using (SqlConnection con = new SqlConnection(CS))
                                {
                                    SqlCommand cmmd = new SqlCommand();
                                    cmmd.CommandText = "INSERT INTO admin_login (first_name,last_name,user_name,phone_no,address,password,[e-mail],dateOfBirth,dateOfJoin,EmpId) values('" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPwd.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtDOB.Text.Trim() + "','" + txtDOJ.Text.Trim() + "','" + txtEmpId.Text.Trim() + "')";
                                    cmmd.Connection = con;
                                    con.Open();
                                    cmmd.ExecuteNonQuery();
                                    //  Response.Redirect(user_registration.aspx");
                                    con.Close();
                                    rgstr_msglbl.Text = "Registered Successfully!";
                                    this.clearFields();
                                    this.generateEmpId();
                                }
                            }
                            else
                            {
                                rgstr_msglbl.Text = ("Some Fields Are Missing");
                            }
                        }
                        else
                        {
                            rgstr_msglbl.Text = ("Password does not match");
                        }
                    }
                }
                catch(Exception ex)
                {
                    ex.ToString();
                }
            }


            else if (select_user_registration.SelectedValue == "2")
            {
                try
                {
                    SqlConnection conn = new SqlConnection(CS);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select user_name from admin_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from cashier_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from pharmacist_login where user_name='" + txtUser.Text.Trim() + "' ";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        conn.Close();
                        rdr.Close();
                       // rgstr_msglbl.Text = (txtUser.Text.Trim() + " already Exist!");
                    }
                    else
                    {
                        if (txtPwd.Text.Trim() == txtCnfrmPwd.Text.Trim())
                        {
                            if (txtUser.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtAddress.Text.Trim() != "" && txtPwd.Text.Trim() != "" && txtCnfrmPwd.Text.Trim() != "")
                            {
                                using (SqlConnection con = new SqlConnection(CS))
                                {
                                    SqlCommand cmmd = new SqlCommand();
                                    cmmd.CommandText = "INSERT INTO pharmacist_login (first_name,last_name,user_name,phone_no,address,password,[e-mail],dateOfBirth,dateOfJoin,EmpId) values('" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPwd.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtDOB.Text.Trim() + "','" + txtDOJ.Text.Trim() + "','" + txtEmpId.Text.Trim() + "')";
                                    cmmd.Connection = con;
                                    con.Open();
                                    cmmd.ExecuteNonQuery();
                                    //  Response.Redirect(user_registration.aspx");
                                    con.Close();
                                    rgstr_msglbl.Text = "Registered Successfully!";
                                    this.clearFields();
                                    this.generateEmpId();


                                }
                            }
                            else
                            {
                                rgstr_msglbl.Text = ("Some Fields Are Missing");
                            }
                        }
                        else
                        {
                            rgstr_msglbl.Text = ("Password does not match");
                        }
                    }
                }
                catch (Exception exx)
                {
                    exx.ToString();
                }
            }

            else
            {
                try
                {

                    SqlConnection conn = new SqlConnection(CS);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select user_name from admin_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from cashier_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from pharmacist_login where user_name='" + txtUser.Text.Trim() + "' ";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        conn.Close();
                        rdr.Close();
                       // rgstr_msglbl.Text = (txtUser.Text.Trim() + " already Exist!");
                    }
                    else
                    {
                        if (txtPwd.Text.Trim() == txtCnfrmPwd.Text.Trim())
                        {
                            if (txtUser.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtAddress.Text.Trim() != "" && txtPwd.Text.Trim() != "" && txtCnfrmPwd.Text.Trim() != "")
                            {
                                using (SqlConnection con = new SqlConnection(CS))
                                {
                                    SqlCommand cmmd = new SqlCommand();
                                    cmmd.CommandText = "INSERT INTO cashier_login (first_name,last_name,user_name,phone_no,address,password,[e-mail],dateOfBirth,dateOfJoin,EmpId) values('" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPwd.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtDOB.Text.Trim() + "','" + txtDOJ.Text.Trim() + "','" + txtEmpId.Text.Trim() + "')";
                                    cmmd.Connection = con;
                                    con.Open();
                                    cmmd.ExecuteNonQuery();
                                    //  Response.Redirect(user_registration.aspx");
                                    con.Close();
                                    rgstr_msglbl.Text = "Registered Successfully!";
                                    this.clearFields();
                                    this.generateEmpId();

                                }
                            }
                            else
                            {
                                rgstr_msglbl.Text = ("Some Fields Are Missing");
                            }
                        }
                        else
                        {
                            rgstr_msglbl.Text = ("Password does not match");
                        }
                    }
                }
                catch(Exception exx)
                {
                    exx.ToString();
                }
            }
        }

      

        

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.clearFields();
            txtUser.Focus();
        }

        protected void lnkbtnChangePassword_Click1(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
        }

        protected void lnkbtnSignout_Click1(object sender, EventArgs e)
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

        protected void btnCheckUsername_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection conn = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select user_name from admin_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from cashier_login where user_name='" + txtUser.Text.Trim() + "' union select user_name from pharmacist_login where user_name='" + txtUser.Text.Trim() + "' ";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    conn.Close();
                    rdr.Close();
                    lbluserStatus.Visible = true;

                    lbluserStatus.Text = ("Username : " +txtUser.Text.Trim() + " already taken, Try another");
                }
                else
                {
                    lbluserStatus.Visible = true;

                    lbluserStatus.Text = "Available";
                       
                }
            }
            catch (Exception exx)
            {
                exx.ToString();
            }
        }


        

    }
}