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
    public partial class AttendanceForm : Form
    {
        int id;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Emp_Name FROM Employee ", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmbEmpName.Items.Add(rdr[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : "+ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbEmpName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Enter Your ID", "JalPak");
                cmbEmpName.Focus();
            }
             if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Month", "JalPak");
                comboBox1.Focus();
            }
            if(txtYear.Text=="")
            {
                MessageBox.Show("Please Select an Year", "JalPak");
            }
            else
            {
                 //id ; //= Convert.ToInt32(textBox1.Text);
                decimal Year = Convert.ToDecimal(txtYear.Text);
                this.AttendanceTableAdapter.Fill(this.AttendanceReportDataSet.Attendance, id, comboBox1.Text, Year);
                this.reportViewer1.RefreshReport();
            }
            
        }

        private void cmbEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con5 = new SqlConnection(gr))
                {
                    SqlCommand cmd5 = new SqlCommand("SELECT Emp_ID FROM Employee WHERE Emp_Name = '" + cmbEmpName.SelectedItem.ToString() + "'", con5);
                    con5.Open();
                    cmd5.ExecuteNonQuery();
                    SqlDataReader rdr1 = cmd5.ExecuteReader();
                    if (rdr1.HasRows)
                    {
                        while (rdr1.Read())
                        {
                            id = Convert.ToInt32(rdr1["Emp_ID"]);                            
                        }
                        // MessageBox.Show("package id selected");
                        rdr1.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }
        }

        private void AttendanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
