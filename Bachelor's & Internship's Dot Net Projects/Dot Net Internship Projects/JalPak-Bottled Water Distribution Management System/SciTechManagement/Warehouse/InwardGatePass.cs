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
    public partial class InwardGatePass : Form
    {
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        int count = 1;
        public InwardGatePass()
        {
            InitializeComponent();
        }

        private void InwardGatePass_Load(object sender, EventArgs e)
        {
               
            txtIGPNo.Text = "1";
            SqlConnection conn = new SqlConnection(gr);
            conn.Open();
            string my_querry = "SELECT ItemName FROM Items";
            SqlCommand cmd = new SqlCommand(my_querry, conn);
            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
           // OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    cmbIGPParticulars.Items.Add(rdr[0]);
                }

            }
            rdr.Close();
           // cmbIGPParticulars.SelectedIndex = 0;
            IGPdateTimePicker1.Format = DateTimePickerFormat.Custom;
            IGPdateTimePicker1.CustomFormat = "MM/dd/yyyy";
            cmbIGPRemarks.SelectedIndex = 0;
            //igpDataGridView1.Select();
            //int rowindex = 0;
            //igpDataGridView1[0, rowindex].Value = count;
            InvoiceData();
            txtIGPThrough.Focus();
                     
        }

        private void btnAddIGPItem_Click(object sender, EventArgs e)
        {
            int result;
            int rdrtemp;
            int temp;

            if(txtIGPThrough.Text == "")
            {
                MessageBox.Show("Field Missing...");
                txtIGPThrough.Focus();                
            }
            else if(txtIGPFor.Text=="")
            {
                MessageBox.Show("Field Missing...");
                txtIGPFor.Focus();
            }
            else if(txtIGPBy.Text=="")
            {
                MessageBox.Show("Field Missing...");
                txtIGPBy.Focus();
            }
            else if (cmbIGPParticulars.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Particular", "JalPak");
                cmbIGPParticulars.Focus();
            }
            else if (cmbIGPRemarks.SelectedIndex == -1)
            {
                MessageBox.Show("Select Remarks", "JalPak");
                cmbIGPRemarks.Focus();
            }
            else if(txtIGPQuantity.Text=="")
            {
                MessageBox.Show("Field Missing...");
                txtIGPQuantity.Focus();
            }
                else if(txtIGPQuantity.Text=="0")
            {
                MessageBox.Show("Quantity Cannot be Zero or Null");
                txtIGPQuantity.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(gr);

                //OleDbConnection conn = new OleDbConnection();
                //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
                conn.Open();
                try
                {
                    using (SqlConnection con1 = new SqlConnection(gr))
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbIGPParticulars.SelectedItem.ToString() + "' ", con1);
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        SqlDataReader rdr = cmd1.ExecuteReader();
                        rdr.Read();                        
                        temp = Convert.ToInt32(txtIGPQuantity.Text);
                        rdrtemp = Convert.ToInt32(rdr[0]);
                        result = rdrtemp + temp;
                      //  MessageBox.Show("Data selected");
                        // MessageBox.Show("data");
                    }

                    string my_querry = "SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbIGPParticulars.SelectedItem.ToString() + "' ";

                    SqlCommand cmd = new SqlCommand(my_querry, conn);
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr1 = cmd.ExecuteReader();
                    rdr1.Read();
                    // MessageBox.Show("This is outer readers value : " + rdr[0].ToString());
                    temp = Convert.ToInt32(txtIGPQuantity.Text);
                    rdrtemp = Convert.ToInt32(rdr1[0]);
                    result = rdrtemp + temp;
                    rdr1.Close();

                    string my_querry2 = "UPDATE Items SET [Quantity]='" + result + "' where ItemName='" + cmbIGPParticulars.SelectedItem.ToString() + "'";
                    SqlCommand cmdd = new SqlCommand(my_querry2, conn);
                    //OleDbCommand cmdd = new OleDbCommand(my_querry2, conn);                    
                    cmdd.ExecuteNonQuery();

                    using (SqlConnection connn = new SqlConnection(gr))
                    {
                        SqlCommand cmddd = new SqlCommand("INSERT INTO InwardGatePass (IGP_ID,IGP_DATE,IGP_Through,IGP_By,IGP_For,IGP_Particulars,IGP_Qty,IGT_Remarks) VALUES ('" + txtIGPNo.Text.Trim().ToString() + "','" + IGPdateTimePicker1.Value + "', '" + txtIGPThrough.Text.Trim().ToString() + "', '" + txtIGPBy.Text.Trim().ToString() + "', '" + txtIGPFor.Text.Trim().ToString() + "', '" + cmbIGPParticulars.Text.Trim().ToString() + "', '" + txtIGPQuantity.Text.Trim().ToString() + "', '" + cmbIGPRemarks.Text.Trim().ToString() + "')", connn);
                        cmddd.CommandType = CommandType.Text;
                        connn.Open();
                        cmddd.ExecuteNonQuery();
                       // MessageBox.Show("Data Insert Successfully...!");
                        // MessageBox.Show("data");
                    }

                    //Insert query for IGP
                    //string my_querry3 = "INSERT INTO InwardGatePass (IGP_ID,IGP_DATE,IGP_Through,IGP_By,IGP_For,IGP_Particulars,IGP_Qty,IGT_Remarks) VALUES ('" + txtIGPNo.Text.Trim().ToString() + "','" + IGPdateTimePicker1.Text.Trim().ToString() + "', '" + txtIGPThrough.Text.Trim().ToString() + "', '" + txtIGPBy.Text.Trim().ToString() + "', '" + txtIGPFor.Text.Trim().ToString() + "', '" + cmbIGPParticulars.Text.Trim().ToString() + "', '" + txtIGPQuantity.Text.Trim().ToString() + "', '" + cmbIGPRemarks.Text.Trim().ToString() + "')";

                    //SqlCommand cmdIGPInsert = new SqlCommand(my_querry, conn);
                    ////OleDbCommand cmdIGPInsert = new OleDbCommand(my_querry3, conn);
                    //cmdIGPInsert.ExecuteNonQuery();

                    int RowIndex = 0;
                    igpDataGridView1.Rows.Add();
                    RowIndex = igpDataGridView1.Rows.Count - 2;
                    // insert values from textboxe to DataGridView
                    igpDataGridView1[0, RowIndex].Value = count;
                    igpDataGridView1[1, RowIndex].Value = cmbIGPParticulars.SelectedItem.ToString();
                    igpDataGridView1[2, RowIndex].Value = txtIGPQuantity.Text;
                    igpDataGridView1[3, RowIndex].Value = cmbIGPRemarks.SelectedItem.ToString();
                    count++;
                    txtIGPQuantity.Text = "";
                    cmbIGPParticulars.SelectedIndex = -1;
                    cmbIGPRemarks.SelectedIndex = -1;
                    cmbIGPParticulars.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter Correct Data! ");
                }
                finally
                {
                    //connn.Close();
                }

                //int RowIndex = 0;
                //igpDataGridView1.Rows.Add();
                //RowIndex = igpDataGridView1.Rows.Count - 2;
                //// insert values from textboxe to DataGridView
                //igpDataGridView1[0, RowIndex].Value = count;
                //igpDataGridView1[1, RowIndex].Value = cmbIGPParticulars.SelectedItem.ToString();
                //igpDataGridView1[2, RowIndex].Value = txtIGPQuantity.Text;
                //igpDataGridView1[3, RowIndex].Value = cmbIGPRemarks.SelectedItem.ToString();
                //count++;
                //txtIGPQuantity.Text = "";
                //cmbIGPParticulars.SelectedIndex = -1;
                //cmbIGPRemarks.SelectedIndex = -1;
                //cmbIGPParticulars.Focus();
            }           
        }
        string oldText3 = string.Empty;
        private void txtIGPQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtIGPQuantity.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtIGPQuantity.Text;
                txtIGPQuantity.Text = oldText3;

                txtIGPQuantity.BackColor = System.Drawing.Color.White;
                txtIGPQuantity.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtIGPQuantity.Text = oldText3;
                txtIGPQuantity.BackColor = System.Drawing.Color.Red;
                txtIGPQuantity.ForeColor = System.Drawing.Color.White;
            }
            txtIGPQuantity.SelectionStart = txtIGPQuantity.Text.Length; 



            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            //conn.Open();
            //string my_querry = "SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbIGPParticulars.SelectedItem.ToString() + "' ";
            //OleDbCommand cmd = new OleDbCommand(my_querry, conn);
            //cmd.ExecuteNonQuery();
            //OleDbDataReader rdr = cmd.ExecuteReader();
            //if (rdr.Read())
            //{
            //   // MessageBox.Show("this is reader : " + rdr[0].ToString());
            //    int temp = Convert.ToInt32(txtIGPQuantity.Text);
            //    int rdrtemp = Convert.ToInt32(rdr[0]);
            //    if (rdrtemp < temp)
            //    {
            //        MessageBox.Show("Maximum available Quantity is : " + rdrtemp);
            //        txtIGPQuantity.Text = Convert.ToString(rdrtemp);
            //    }
            //    ////while (rdr.Read())
            //    //{
            //    //    cmbIGPParticulars.Items.Add(rdr[0]);
            //    //}

            //}
        }
        public static string igptext;
        private void btnPrintInwardGatepass_Click(object sender, EventArgs e)
        {
            igptext = txtIGPNo.Text;
            IGPReport igpreport = new IGPReport();
            igpreport.ShowDialog();


            txtIGPThrough.Text = "";
            txtIGPFor.Text = "";
            txtIGPBy.Text = "";
            txtIGPQuantity.Text = "";
            cmbIGPParticulars.SelectedIndex = -1;
            cmbIGPRemarks.SelectedIndex = -1;
            txtIGPThrough.Focus();
            InvoiceData();
            this.igpDataGridView1.Rows.Clear();
        }
        private void InvoiceData()
        {


                        
            try
            {
                using (SqlConnection con2 = new SqlConnection(gr))
                {
                    SqlCommand cmdinvoice = new SqlCommand("Select Max(IGP_ID)+1 from InwardGatePass", con2);
                    cmdinvoice.CommandType = CommandType.Text;
                    con2.Open();
                    cmdinvoice.ExecuteNonQuery();
                    SqlDataReader rdr = cmdinvoice.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            txtIGPNo.Text = rdr[0].ToString();
                           // MessageBox.Show("invoice data");
                        }
                        else
                        {
                            txtIGPNo.Text = "1";
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
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    using (SqlConnection conn = new SqlConnection(gr))
        //    {
        //     SqlCommand cmd = new SqlCommand("INSERT INTO InwardGatePass (IGP_ID,IGP_DATE,IGP_Through,IGP_By,IGP_For,IGP_Particulars,IGP_Qty,IGT_Remarks) VALUES ('" + txtIGPNo.Text.Trim().ToString() + "','" + IGPdateTimePicker1.Text.Trim().ToString() + "', '" + txtIGPThrough.Text.Trim().ToString() + "', '" + txtIGPBy.Text.Trim().ToString() + "', '" + txtIGPFor.Text.Trim().ToString() + "', '" + cmbIGPParticulars.Text.Trim().ToString() + "', '" + txtIGPQuantity.Text.Trim().ToString() + "', '" + cmbIGPRemarks.Text.Trim().ToString() + "')",conn);
        //     cmd.CommandType = CommandType.Text;
        //     conn.Open();
        //     cmd.ExecuteNonQuery();
        //    // MessageBox.Show("data");
        //    }

             
        }

        private void iGPListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List.IGPList igpl = new List.IGPList();
            igpl.ShowDialog();
        } 
    }
}
