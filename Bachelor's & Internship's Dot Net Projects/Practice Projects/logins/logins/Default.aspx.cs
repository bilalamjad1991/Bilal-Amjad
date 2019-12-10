using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace logins
{
    public partial class _Default : System.Web.UI.Page
    {
        string gr = "Data Source=BILAL-HP\\SQLEXPRESS;Initial Catalog=pharma;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsignin_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection(gr);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from login where user_name='" + txtuser.Text.Trim() + "' ";
                
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                conn.Close();
                rdr.Close();
       
                lblmsg.Text = (txtuser.Text.Trim() + " already exist");
            }
         
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
