using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement
{
    public partial class CreateAccounts : Form
    {
        public CreateAccounts()
        {
            InitializeComponent();
        }

        private void btnAddAccounts_Click(object sender, EventArgs e)
        {
            int fid = Accounts.id;
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection con13 = new SqlConnection(gr))
                {
                    SqlCommand cmd13 = new SqlCommand("INSERT INTO SecLevelAcct(ID,FID,Name)VALUES('" + txtID.Text + "','" + fid + "','" + txtName.Text + "' )", con13);
                    con13.Open();
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Account Added!");
                    this.Close();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(gr))
            {

                SqlCommand cmd = new SqlCommand("SELECT * from SecLevelAcct where ID='" + txtID.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    MessageBox.Show("ID Already Exist!", "JalPak");
                    txtID.Focus();
                    txtID.SelectAll();
                }
                else
                {
                    rdr.Close();
                    //SqlCommand cmdd = new SqlCommand("INSERT INTO Department(Dept_ID,Dept_Name,Dept_Manager)VALUES('" + txtDeptID.Text.ToString() + "','" + txtDeptName.Text.ToString() + "','" + txtDeptManager.Text.ToString() + "')", con);
                    //cmdd.ExecuteNonQuery();
                    //MessageBox.Show("Deparment Created.", "JalPak");

                }
            }
        }
         string oldText3 = string.Empty;
        private void txtID_TextChanged(object sender, EventArgs e)
        {


            if (txtID.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtID.Text;
                txtID.Text = oldText3;

                txtID.BackColor = System.Drawing.Color.White;
                txtID.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtID.Text = oldText3;
                txtID.BackColor = System.Drawing.Color.Red;
                txtID.ForeColor = System.Drawing.Color.White;
            }
            txtID.SelectionStart = txtID.Text.Length;
        
        }
        string oldText4 = string.Empty;
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.All(chr => char.IsLetterOrDigit(chr)))
            {
                
                    oldText4 = txtName.Text;
                    txtName.Text = oldText4;

                    txtName.BackColor = System.Drawing.Color.White;
                    txtName.ForeColor = System.Drawing.Color.Black;
                
            }
            else
            {
                txtName.Text = oldText4;
                txtName.BackColor = System.Drawing.Color.Red;
                txtName.ForeColor = System.Drawing.Color.White;
            }
            txtName.SelectionStart = txtName.Text.Length;
        
        }

        private void CreateAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
