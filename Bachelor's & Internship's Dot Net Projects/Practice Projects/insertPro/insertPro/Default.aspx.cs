using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace insertPro
{
    public partial class _Default : System.Web.UI.Page
    {
        string gr = "Data Source=BILAL-HP\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(gr);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * from Register where Fname='" + txt_username.Text.Trim() + "'";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    conn.Close();
                    rdr.Close();

                    rgstr.Text = (txt_username.Text.Trim() + "already exist");
                }
                else
                {
                    if(txt_username.Text.Trim() !="")
                    {
                    using (SqlConnection con = new SqlConnection(gr))
                    {
                        SqlCommand cmmd = new SqlCommand();
                        cmmd.CommandText = "INSERT INTO Register (Fname,Lname)  values('" + txt_username.Text.Trim() +"','"+ txt_lastname.Text.Trim() + "', '0' )";
                        cmmd.Connection = con;
                        con.Open();
                        cmmd.ExecuteNonQuery();
                        Response.Redirect("Default.aspx");
                        con.Close();

                    }

                }
                }
            }
            catch(SqlException ex)
            {
                rgstr.Text=ex.Message;
            }

            
        }
    }
    }
