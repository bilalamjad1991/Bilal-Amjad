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
    public partial class SaveNewMed : System.Web.UI.Page
    {
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
                    lnkbtnRegister.Enabled = true;
                    lnkbtnRegister.Visible = true;
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
            txtMedName.Focus();
        }



        protected void btnSaveMedicine_Click(object sender, EventArgs e)
        {
            try
            {

                string conn = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                SqlConnection objsqlconn = new SqlConnection(conn);
                objsqlconn.Open();
                if (txtMedCompany.Text.Length < 1 || txtMedName.Text.Length<1 || txtMedPrice.Text.Length<1 || txtMedQty.Text.Length<1 || txtMedSalt.Text.Length<1)
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "* Some fields missing";
                }
                else
                {
                    SqlCommand objcmd = new SqlCommand("Insert into Medicines(ProductName,P_Salt,P_Company,P_Price,P_Qty) Values('" + txtMedName.Text + "','" + txtMedSalt.Text + "','" + txtMedCompany.Text + "','" + txtMedPrice.Text + "','" + txtMedQty.Text + "')", objsqlconn);
                    objcmd.ExecuteNonQuery();
                    lblStatus.Visible = true;
                    lblStatus.Text = "Medicine saved successfully";
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
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