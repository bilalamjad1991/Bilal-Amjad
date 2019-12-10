using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAS_regenerated
{
    public partial class searchConsole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }
                //Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        private void GetMedicineData(string MedicineName)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<string> medicineNames = new List<string>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spGetMedicines", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(MedicineName))
                    {
                        SqlParameter parameter = new SqlParameter("@MedicineName", MedicineName);
                        cmd.Parameters.Add(parameter);
                    }
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    gvMedicines.DataSource = rdr;
                    gvMedicines.DataBind();

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }





        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    GetMedicineData(txtMedicineName.Text);
        //}

        //protected void btnSubmit2_Click(object sender, EventArgs e)
        //{
        //    GetCompanyData(txtMedicineCompany.Text);
        //}

        private void GetCompanyData(string CompanyName)
        {
            try
            {

                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<string> companyNames = new List<string>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spGetCompanies", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(CompanyName))
                    {
                        SqlParameter parameter = new SqlParameter("@CompanyName", CompanyName);
                        cmd.Parameters.Add(parameter);
                    }
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    gvMedicines.DataSource = rdr;
                    gvMedicines.DataBind();

                }

            }
            catch(Exception ex)
            {
                ex.ToString();
            }




        }
        protected void txtMedicineCompany_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            GetMedicineData(txtMedicineName.Text);
            this.headerText();
            txtMedicineName.Text = "";
            txtMedicineName.Focus();
        }

        protected void btnSubmit2_Click1(object sender, EventArgs e)
        {
            GetCompanyData(txtMedicineCompany.Text);
            this.headerText();
            txtMedicineCompany.Text = "";
            txtMedicineCompany.Focus();

        }

        protected void headerText()
        {
            if (gvMedicines.Rows.Count > 0)
            {
                gvMedicines.HeaderRow.Cells[0].Text = " Product Name ";
                gvMedicines.HeaderRow.Cells[1].Text = " Salt ";
                gvMedicines.HeaderRow.Cells[2].Text = "Company ";
                gvMedicines.HeaderRow.Cells[3].Text = " Unit Price ";
                gvMedicines.HeaderRow.Cells[4].Text = " Stock Quantity ";
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