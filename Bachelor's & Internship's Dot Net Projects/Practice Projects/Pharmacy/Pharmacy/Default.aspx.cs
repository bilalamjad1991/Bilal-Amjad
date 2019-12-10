using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Pharmacy
{
    public partial class _Default : System.Web.UI.Page
    {
        string str = "Data Source=BILAL-HP\\SQLEXPRESS; Initial Catalog=Medicines;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection conn=new SqlConnection(str);
                SqlCommand cmd=new SqlCommand();
              //  cmd.CommandText="Select * from MedTable where ItemName='" + TextBox1.Text.Trim()+"'";
                //cmd.CommandText = "UPDATE MedTable SET ItemName= '"+TextBox1.Text.Trim() + "where salt=asd'"+"'";
                cmd.CommandText = "Update MedTable Set Salt=('" + TextBox1.Text + "'),CompanyName=('" + TextBox2.Text + "') Where ItemName=('" + TextBox3.Text + "')";
               // cmd.CommandText = "Update MedTable Set CompanyName=('" + TextBox2.Text + "') Where Salt='asd'";
                cmd.Connection=conn;
                conn.Open();
                SqlDataReader rdr=cmd.ExecuteReader();

                //SqlCommand cmd = new SqlCommand("Update Loc_mast Set Loc =('" + txtrnme.Text + "') Where Loc =('" + Droploc.SelectedItem.Text + "')", con1);

//                UPDATE table_name
//                SET column1=value1,column2=value2,...
//                WHERE some_column=some_value;

               /* if(rdr.HasRows)
                {
                conn.Close();
                rdr.Close();
                    Label1.Text=(TextBox1.Text.Trim()+" is Availabe");

                
                }
                else {
                Label1.Text=(TextBox1.Text.Trim()+" is not Availabe");
                }*/
                conn.Close();
                rdr.Close();
            
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
