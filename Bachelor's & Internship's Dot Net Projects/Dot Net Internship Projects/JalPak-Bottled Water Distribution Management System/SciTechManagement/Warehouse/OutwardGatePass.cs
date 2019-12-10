using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement.Warehouse
{
    public partial class OutwardGatePass : Form
    {
        int result;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        int count = 1;
        public OutwardGatePass()
        {
            InitializeComponent();
        }
        private void OutwardGatePass_Load(object sender, EventArgs e)
        {
            using (SqlConnection con1 = new SqlConnection(gr))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT ItemName FROM Items", con1);
                cmd1.CommandType = CommandType.Text;
                con1.Open();
                cmd1.ExecuteNonQuery();
            //OleDbConnection conn = new OleDbConnection();
                //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            //    conn.Open();
            //    string my_querry = "SELECT ItemName FROM Items";
            //    SqlCommand cmd = new SqlCommand(my_querry, conn);
            ////OleDbCommand cmd = new OleDbCommand(my_querry, conn);
            //    cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd1.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                        {                            
                            cmbOGPParticulars.Items.Add(rdr[0]);
                        }                    
                }
            }
            InvoiceData();
           // cmbOGPParticulars.SelectedIndex = 0;
            OGPdateTimePicker1.Format = DateTimePickerFormat.Custom;
            OGPdateTimePicker1.CustomFormat = "MM/dd/yyyy";
          //  cmbOGPRemarks.SelectedIndex = 0;            
            txtOGPThrough.Focus();
        }
        private void btnAddOGPItem_Click(object sender, EventArgs e)
        {
            
            int rdrtemp;
            int temp;

            if(txtOGPThrough.Text=="")
            {
                MessageBox.Show("Field is Missing...","JalPak");
                txtOGPThrough.Focus();
            }

            else if(txtOGPQuantity.Text=="")
            {
                MessageBox.Show("Field is Missing...", "JalPak");
                txtOGPQuantity.Focus();
            }
           else if(txtOGPFor.Text=="")
            {
                MessageBox.Show("Field is Missing...", "JalPak");
                txtOGPFor.Focus();
            }
            else if(txtOGPBy.Text=="")
            {
                MessageBox.Show("Field is Missing...", "JalPak");
                txtOGPBy.Focus();
            }
            else if (cmbOGPParticulars.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Particular", "JalPak");
                cmbOGPParticulars.Focus();
            }
            else if (cmbOGPRemarks.SelectedIndex == -1)
            {
                MessageBox.Show("Select Remarks", "JalPak");
                cmbOGPRemarks.Focus();
            }
            else if (txtOGPQuantity.Text == "0")
            {
                MessageBox.Show("Quantity Cannot be Zero or Null", "JalPak");
                txtOGPQuantity.Focus();
            }

            else
            {
                try
                {
                    using (SqlConnection con2 = new SqlConnection(gr))
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbOGPParticulars.SelectedItem.ToString() + "' ", con2);
                        cmd2.CommandType = CommandType.Text;
                        con2.Open();
                        cmd2.ExecuteNonQuery();
                        SqlDataReader rdr = cmd2.ExecuteReader();
                        rdr.Read();
                        //MessageBox.Show("This is outer readers value : " + rdr[0].ToString());
                        temp = Convert.ToInt32(txtOGPQuantity.Text);
                        rdrtemp = Convert.ToInt32(rdr[0]);
                        if (temp > rdrtemp)
                        {
                            MessageBox.Show("Orderd Quantity is not available. Maximum Available Quantity is : " + rdrtemp, "JalPak");
                            // txtOGPQuantity.Text = rdrtemp.ToString();
                            txtOGPQuantity.Focus();

                        }
                        else
                        {
                            result = rdrtemp - temp;
                            using (SqlConnection con3 = new SqlConnection(gr))
                            {
                                SqlCommand cmd3 = new SqlCommand("UPDATE Items SET [Quantity]='" + result + "' where ItemName='" + cmbOGPParticulars.SelectedItem.ToString() + "'", con3);
                                cmd3.CommandType = CommandType.Text;
                                con3.Open();
                                cmd3.ExecuteNonQuery();


                            }

                            //string my_querry2 = "UPDATE Items SET [Quantity]='" + result + "' where ItemName='" + cmbOGPParticulars.SelectedItem.ToString() + "'";
                            //SqlCommand cmdd = new SqlCommand(my_querry2, conn);
                            //cmdd.ExecuteNonQuery();
                            // insert query 
                            using (SqlConnection con4 = new SqlConnection(gr))
                            {
                                SqlCommand cmd4 = new SqlCommand("Insert into OutwardGatePass(OGP_ID,OGP_Date,OGP_Through,OGP_By,OGP_For,OGP_Particulars,OGP_Qty,OGT_Remarks) Values('" + txtOGPNo.Text.Trim().ToString() + "','" + OGPdateTimePicker1.Value + "','" + txtOGPThrough.Text.Trim().ToString() + "','" + txtOGPBy.Text.Trim().ToString() + "','" + txtOGPFor.Text.Trim().ToString() + "','" + cmbOGPParticulars.SelectedItem.ToString() + "','" + txtOGPQuantity.Text.Trim().ToString() + "','" + cmbOGPRemarks.SelectedItem.ToString() + "')", con4);
                                cmd4.CommandType = CommandType.Text;
                                con4.Open();
                                cmd4.ExecuteNonQuery();
                                // MessageBox.Show("Insert Successfully...!");
                                int RowIndex = 0;
                                ogpDataGridView1.Rows.Add();
                                RowIndex = ogpDataGridView1.Rows.Count - 2;
                                // insert values from textboxe to DataGridView            
                                ogpDataGridView1[0, RowIndex].Value = count;
                                ogpDataGridView1[1, RowIndex].Value = cmbOGPParticulars.SelectedItem.ToString();
                                ogpDataGridView1[2, RowIndex].Value = txtOGPQuantity.Text;
                                ogpDataGridView1[3, RowIndex].Value = cmbOGPRemarks.SelectedItem.ToString();
                                count++;

                                txtOGPQuantity.Text = "";
                                cmbOGPParticulars.SelectedIndex = -1;
                                cmbOGPRemarks.SelectedIndex = 0;
                            }
                            //string my_querry3 = "Insert into OutwardGatePass(OGP_ID,OGP_Date,OGP_Through,OGP_By,OGP_For,OGP_Particulars,OGP_Qty,OGT_Remarks) Values('" + txtOGPNo.Text.Trim().ToString() + "','" + OGPdateTimePicker1.Text.ToString() + "','" + txtOGPThrough.Text.Trim().ToString() + "','" + txtOGPBy.Text.Trim().ToString() + "','" + txtOGPFor.Text.Trim().ToString() + "','" + cmbOGPParticulars.SelectedItem.ToString() + "','" + txtOGPQuantity.Text.Trim().ToString() + "','" + cmbOGPRemarks.SelectedItem.ToString() + "')";
                            //SqlCommand cmdOGPInsert = new SqlCommand(my_querry3, conn);
                            //cmdOGPInsert.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter Correct Data!");
                }
                finally
                {

                }
            }            
            
        }
        public static string ogpid;
        private void btnPrintOutwardGatepass_Click(object sender, EventArgs e)
        {
            ogpid = txtOGPNo.Text;
            OGPReport ogp = new OGPReport();
            ogp.ShowDialog();

            txtOGPFor.Text = "";
            txtOGPBy.Text = "";
            txtOGPThrough.Text = "";
            txtOGPQuantity.Text = "";
            cmbOGPParticulars.SelectedIndex = -1;
            cmbOGPRemarks.SelectedIndex = -1;

            InvoiceData();
            this.ogpDataGridView1.Rows.Clear();
        }

        string oldText3 = string.Empty;
        private void txtOGPQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtOGPQuantity.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtOGPQuantity.Text;
                txtOGPQuantity.Text = oldText3;

                txtOGPQuantity.BackColor = System.Drawing.Color.White;
                txtOGPQuantity.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtOGPQuantity.Text = oldText3;
                txtOGPQuantity.BackColor = System.Drawing.Color.Red;
                txtOGPQuantity.ForeColor = System.Drawing.Color.White;
            }
            txtOGPQuantity.SelectionStart = txtOGPQuantity.Text.Length; 
        }

        //private void txtOGPQuantity_Leave(object sender, EventArgs e)
        //{
        //    if(txtOGPQuantity.Text=="")
        //    {
        //        MessageBox.Show("Quatity must be Entered!");
        //        txtOGPQuantity.Focus();
        //    }
        //        else if(Convert.ToInt32(txtOGPQuantity.Text) < 0) 
        //    {
        //        MessageBox.Show("Enter An Appropriate value");
        //        txtOGPQuantity.Focus();
        //        }
        //    else
        //    {
        //        using (SqlConnection con5 = new SqlConnection(gr))
        //        {
        //            SqlCommand cmd5 = new SqlCommand("SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbOGPParticulars.SelectedItem.ToString() + "' ", con5);
        //            cmd5.CommandType = CommandType.Text;
        //            con5.Open();
        //            cmd5.ExecuteNonQuery();
        //            SqlDataReader rdr = cmd5.ExecuteReader();
        //            if (rdr.Read())
        //            {
        //                // MessageBox.Show("this is reader : " + rdr[0].ToString());
        //                int temp = Convert.ToInt32(txtOGPQuantity.Text);
        //                int rdrtemp = Convert.ToInt32(rdr[0]);
        //                if (rdrtemp < temp)
        //                {
        //                    MessageBox.Show("Maximum available Quantity is : " + rdrtemp);
        //                    //txtOGPQuantity.Text = "";
        //                    txtOGPQuantity.Focus();
        //                }
        //            }
        //        }



        //        //SqlConnection conn = new SqlConnection(gr);
        //        ////conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
        //        //conn.Open();
        //        //string my_querry = "SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbOGPParticulars.SelectedItem.ToString() + "' ";
        //        //SqlCommand cmd = new SqlCommand(my_querry, conn);
        //        //cmd.ExecuteNonQuery();
        //        //SqlDataReader rdr = cmd.ExecuteReader();
        //        //if (rdr.Read())
        //        //{
        //        //    // MessageBox.Show("this is reader : " + rdr[0].ToString());
        //        //    int temp = Convert.ToInt32(txtOGPQuantity.Text);
        //        //    int rdrtemp = Convert.ToInt32(rdr[0]);
        //        //    if (rdrtemp < temp)
        //        //    {
        //        //        MessageBox.Show("Maximum available Quantity is : " + rdrtemp);
        //        //        //txtOGPQuantity.Text = "";
        //        //        txtOGPQuantity.Focus();
        //        //    }
        //        //}
        //    }
            
        //}
        private void InvoiceData()
        {
            try
            {
                using (SqlConnection con6 = new SqlConnection(gr))
                {
                    SqlCommand cmd6 = new SqlCommand("Select Max(OGP_ID)+1 from OutwardGatePass", con6);
                    cmd6.CommandType = CommandType.Text;
                    con6.Open();
                    cmd6.ExecuteNonQuery();
                    SqlDataReader rdr = cmd6.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            txtOGPNo.Text = rdr[0].ToString();
                        }
                        else
                        {
                            txtOGPNo.Text = "1";
                        }
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

             //SqlConnection conn = new SqlConnection(gr);
            ////conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            //try
            //{
            //    conn.Open();
            //    string my_querry = "Select Max(OGP_ID)+1 from OutwardGatePass '";
            //    SqlCommand cmd = new SqlCommand(my_querry, conn);
            //    cmd.ExecuteNonQuery();

            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        if (!rdr.IsDBNull(0))
            //        {
            //            txtOGPNo.Text = rdr[0].ToString();
            //        }
            //        else
            //        {
            //            txtOGPNo.Text = "1";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed due to : " + ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void oGPListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List.OGPList ogpl = new List.OGPList();
            ogpl.ShowDialog();
        }
    }
}
