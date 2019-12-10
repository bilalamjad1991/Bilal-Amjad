using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Login_Module
{
    public partial class EditPass : System.Web.UI.Page
    {

        string str = "Data Source=BILAL-HP\\SQLEXPRESS; Initial Catalog=Medicines;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string IpassAstringfrompage1 = Convert.ToString(Session["test"]);

            UserName.Text = IpassAstringfrompage1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "Update logindata Set username=('"+UserName.Text.Trim() + "'),Password=('" + TextBox2.Text + "'), Contact=('" + TextBox3.Text + "'),E-mail=('" + TextBox4.Text + "') Where UserName=('" + UserName.Text.Trim() + "')";
               // cmd.CommandText = "Update MedTable Set Salt=('" + TextBox1.Text + "'),CompanyName=('" + TextBox2.Text + "') Where ItemName=('" + TextBox3.Text + "')";
                
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    conn.Close();
                    rdr.Close();
                    Success.Text = "Succesfully updated";
                }
                }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}