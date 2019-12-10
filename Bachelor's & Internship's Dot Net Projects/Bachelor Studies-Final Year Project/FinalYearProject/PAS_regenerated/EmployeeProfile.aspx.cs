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
    public partial class EmployeeProfile : System.Web.UI.Page
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
                else if (Session["selection"].ToString() == "2")
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
           
        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
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

       

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtEmpId.ReadOnly = true;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
           // txtUser.ReadOnly = false;
           
            btnEdit.Visible = false;
            btnUpdate.Visible = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // txtUser.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtEmpId.ReadOnly = false;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
          //  txtUser.ReadOnly = true;
            btnUpdate.Visible = false;
            btnEdit.Visible = false;

            lblUpdate.Visible = false;
            txtEmpId.Text = "";
          
          //  txtDOB.Text = "";

        }

        protected void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection scon = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select EmpId,first_name,last_name,phone_no,[e-mail],address from admin_login where EmpId='" + txtEmpId.Text.Trim() + "' union Select EmpId,first_name,last_name,phone_no,[e-mail],address from cashier_login where EmpId='" + txtEmpId.Text.Trim() + "' union Select EmpId,first_name,last_name,phone_no,[e-mail],address from pharmacist_login where EmpId='" + txtEmpId.Text.Trim() + "'";
                cmd.Connection = scon;
                scon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblError.Visible = false;
                    btnEdit.Visible = true;
                    txtFirstName.Text = rdr[1].ToString();
                    txtLastName.Text = rdr[2].ToString();
                    txtPhone.Text = rdr[3].ToString();
                    txtEmail.Text = rdr[4].ToString();
                    txtAddress.Text = rdr[5].ToString();
               
                    rdr.Close();
                    scon.Close();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Employee ID does not exist";
                    rdr.Close();
                    scon.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                lblError.Visible = true;
                lblError.Text = "Incorrect Entry";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con22 = new SqlConnection(cs);
                SqlCommand cmd33 = new SqlCommand();
                cmd33.Connection = con22;
                con22.Open();

                cmd33.CommandText = "UPDATE admin_login SET [phone_no]='" + txtPhone.Text.Trim() + "',[first_name]='" + txtFirstName.Text.Trim() + "',[last_name]='" + txtLastName.Text.Trim() + "',[e-mail]='" + txtEmail.Text.Trim() + "',[address]='" + txtAddress.Text.Trim() + "' where EmpId='" + txtEmpId.Text.Trim() + "'";
                  
                    cmd33.ExecuteNonQuery();
                    cmd33.CommandText = "UPDATE cashier_login SET [phone_no]='" + txtPhone.Text.Trim() + "',[first_name]='" + txtFirstName.Text.Trim() + "',[last_name]='" + txtLastName.Text.Trim() + "',[e-mail]='" + txtEmail.Text.Trim() + "',[address]='" + txtAddress.Text.Trim() + "' where EmpId='" + txtEmpId.Text.Trim() + "'";
                  
                    cmd33.ExecuteNonQuery();
                    cmd33.CommandText = "UPDATE pharmacist_login SET [phone_no]='" + txtPhone.Text.Trim() + "',[first_name]='" + txtFirstName.Text.Trim() + "',[last_name]='" + txtLastName.Text.Trim() + "',[e-mail]='" + txtEmail.Text.Trim() + "',[address]='" + txtAddress.Text.Trim() + "' where EmpId='" + txtEmpId.Text.Trim() + "'";
                  
                    cmd33.ExecuteNonQuery();
                con22.Close();
                lblUpdate.Visible = true;
                lblUpdate.Text = "Update Successful";
            }
            catch (Exception ex)
            {
                ex.ToString();
                lblUpdate.Visible = true;
                lblUpdate.Text = "Update UnSuccessful";
            }
        }
    }
}