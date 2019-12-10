using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement.PayRoll
{
    public partial class Department : Form
    {
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";

        public Department()
        {
            InitializeComponent();
        }

        private void btnSaveDept_Click(object sender, EventArgs e)
        {
            if (txtDeptName.Text == "")
            {
                MessageBox.Show("Enter Department Name", "JalPak");
                txtDeptName.Focus();
            }
            else if (txtDeptManager.Text == "")
            {
                MessageBox.Show("Enter Manager Name", "JalPak");
                txtDeptManager.Focus();
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(gr))
                    {
                        //     Select customer id from customer package to delete it, if customer type change deal to regular 

                        SqlCommand cmd222 = new SqlCommand("SELECT * from Department where Dept_Name='" + txtDeptName.Text + "'", con);
                        con.Open();
                        cmd222.ExecuteNonQuery();
                        SqlDataReader rdr222 = cmd222.ExecuteReader();
                        if (rdr222.HasRows)
                        {
                            MessageBox.Show("Department Name Already Exist. Try Another One!", "JalPak");
                            txtDeptName.Focus();
                        }
                        else
                        {
                            rdr222.Close();
                            using (SqlConnection con1 = new SqlConnection(gr))
                            {
                                //     Select customer id from customer package to delete it, if customer type change deal to regular 
                                SqlCommand cmd = new SqlCommand("SELECT * from Department where Dept_ID='" + txtDeptID.Text + "'", con1);
                                con1.Open();
                                cmd.ExecuteNonQuery();
                                SqlDataReader rdr = cmd.ExecuteReader();
                                if (rdr.HasRows)
                                {
                                    MessageBox.Show("Department Code Already Exist!", "JalPak");
                                    rdr.Close();
                                }
                                else
                                {
                                    rdr.Close();
                                    SqlCommand cmdd = new SqlCommand("INSERT INTO Department(Dept_ID,Dept_Name,Dept_Manager)VALUES('" + txtDeptID.Text.ToString() + "','" + txtDeptName.Text.ToString() + "','" + txtDeptManager.Text.ToString() + "')", con);
                                    cmdd.ExecuteNonQuery();
                                    MessageBox.Show("Deparment Created.", "JalPak");
                                    ClearDeptInput();

                                    departmentTableAdapter.Fill(departmentDataSet.Department);
                                    dataGridView1.Invalidate();
                                    dataGridView1.Refresh();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

        }
        private void Department_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'departmentDataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.departmentDataSet.Department);
            InvoiceData();
        }

        //    Function : To auto assign department ID
        private void InvoiceData()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd1 = new SqlCommand("Select Max(Dept_ID)+1 from Department ", con1);
                    con1.Open();
                    cmd1.ExecuteNonQuery();

                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    if (rdr1.Read())
                    {
                        if (!rdr1.IsDBNull(0))
                        {
                            txtDeptID.Text = rdr1[0].ToString();
                            //rdr.Close();
                        }
                        else
                        {
                            txtDeptID.Text = "1";
                        }
                        // rdr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }
            finally
            {

            }
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "JalPak", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        DeleteItem(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        InvoiceData();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Please Select a Record!", "JalPak");
                    }

                }
                else
                {
                    // MessageBox.Show("Not deleted", "JalPak");
                }
            }
        }

        // Function to delete department

        private void DeleteItem(string code)
        {
            if (string.IsNullOrEmpty(code))
                return;
            try
            {
                using (SqlConnection con2 = new SqlConnection(gr))
                {

                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Department WHERE Dept_ID = '" + code + "'", con2);
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    // rdr.Close();
                    MessageBox.Show("Record Deleted!", "JalPak");
                    departmentTableAdapter.Fill(departmentDataSet.Department);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
            }
        }

        private void btnUpdateDept_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(gr))
                {
                    //     Select customer id from customer package to delete it, if customer type change deal to regular 

                    SqlCommand cmd22 = new SqlCommand("SELECT * from Department where Dept_Name='" + txtDeptName.Text + "'", con);
                    con.Open();
                    cmd22.ExecuteNonQuery();
                    SqlDataReader rdr22 = cmd22.ExecuteReader();
                    if (rdr22.HasRows)
                    {
                        MessageBox.Show("Department Name Already Exist. Record cannot be updated!", "JalPak");
                        txtDeptName.Focus();

                    }
                    else
                    {
                        rdr22.Close();
                        // update query
                        using (SqlConnection con3 = new SqlConnection(gr))
                        {
                            SqlCommand cmd3 = new SqlCommand("UPDATE Department SET Dept_ID='" + txtDeptID.Text.Trim() + "',Dept_Name='" + txtDeptName.Text.Trim() + "', Dept_Manager='" + txtDeptManager.Text.Trim() + "' where Dept_ID='" + txtDeptID.Text.Trim() + "'", con3);
                            con3.Open();
                            cmd3.ExecuteNonQuery();
                            MessageBox.Show("Record Updated!", "JalPak");
                            //     Refresh gridview
                            departmentTableAdapter.Fill(departmentDataSet.Department);
                            dataGridView1.Invalidate();
                            dataGridView1.Refresh();
                            ClearDeptInput(); //                
                        }
                    }
                }
            }
            catch(Exception exx)
            {
                MessageBox.Show("Failed due to : " +exx.Message);
            }
           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView1.Rows[e.RowIndex];
                txtDeptID.Text = row.Cells["Dept_ID"].Value.ToString();
                txtDeptName.Text = row.Cells["Dept_Name"].Value.ToString();
                txtDeptManager.Text = row.Cells["Dept_Manager"].Value.ToString();
            }
        }
        private void ClearDeptInput()
        {
            InvoiceData();
            txtDeptName.Text = "";
            txtDeptManager.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDeptInput();
        }
    }
}
