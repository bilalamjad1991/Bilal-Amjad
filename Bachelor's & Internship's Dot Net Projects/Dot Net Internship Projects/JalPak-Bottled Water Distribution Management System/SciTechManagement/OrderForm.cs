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

namespace SciTechManagement
{
    public partial class OrderForm : Form
    {
        int SN_Count=1;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public OrderForm()
        {
            InitializeComponent();
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
           
            txtOrderNo.Text = SN_Count.ToString();
            txtQuantity.Text = "";
           // txtRate.Text = "1";
            txtOrderdDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            //using (SqlConnection conn = new SqlConnection(gr))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT Cust_Name FROM CustomerDetails", conn);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.HasRows)
            //    {
            //        while (rdr.Read())
            //        {
            //            cmbCustName.Items.Add(rdr[0]);
            //        }
            //        cmbCustName.SelectedIndex = 0;
            //    }
               InvoiceData();
            //}                                  
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if(txtDescription.Text=="")
            {
                MessageBox.Show("Enter Product Description");
                txtDescription.Focus();
            }
            else if (txtOrderBy.Text == "")
            {
                MessageBox.Show("Enter the name of Salesman");
                txtOrderBy.Focus();
            }
            else if(txtQuantity.Text=="")
            {
                MessageBox.Show("Enter the Orderd Quantity");
                txtQuantity.Focus();
            }
            else
            {
                
                //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
                
                try
                {
                    //conn.Open();
                    //string CustomerID = txtCustomerID.Text.Trim();
                    string OrderID = txtOrderNo.Text;
                    string OrderDate = txtOrderdDate.Text;
                    string orderby = txtOrderBy.Text.Trim();
                    string Description = txtDescription.Text.Trim();
                    string qty = txtQuantity.Text.Trim();
                    //string Rate = txtRate.Text.ToString();
                    //string Amount = txtAmount.Text.ToString();
                    
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        //SqlCommand cmdd = new SqlCommand("INSERT INTO OrderDetails(Ordre_ID,Cust_ID,OrderDate,Description,Rate,Amount)VALUES('" + OrderID + "','" + CustomerID + "','" + OrderDate + "','" + Description + "','" + Rate + "','" + Amount + "')", conn);
                        SqlCommand cmdd = new SqlCommand("INSERT INTO OrderDetails(Ordre_ID,Quantity,OrderBy,OrderDate,Description)VALUES('" + OrderID + "','" + qty + "','" + orderby + "','" + DateTime.Now + "','" + Description + "')", conn);
                        conn.Open();
                        cmdd.ExecuteNonQuery();

                        // below messagebox should be removed
                        MessageBox.Show("Data saved successfuly...!");

                        int RowIndex = 0;
                        dataGridView1.Rows.Add();
                        RowIndex = dataGridView1.Rows.Count - 2;
                        // insert values from textboxes to DataGridView
                        dataGridView1[0, RowIndex].Value = SN_Count;
                        dataGridView1[1, RowIndex].Value = txtDescription.Text;
                        dataGridView1[2, RowIndex].Value = txtQuantity.Text;
                        //dataGridView1[3, RowIndex].Value = txtAmount.Text;
                        SN_Count++;
                        txtDescription.Text = "";
                        txtQuantity.Text = "";
                        txtDescription.Focus();
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
                                                               
        }

        //string oldText3 = string.Empty;
        string oldText4 = string.Empty;
        //private void txtRate_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtRate.Text.All(chr => char.IsNumber(chr)))
        //    {
        //        oldText3 = txtRate.Text;
        //        txtRate.Text = oldText3;

        //        txtRate.BackColor = System.Drawing.Color.White;
        //        txtRate.ForeColor = System.Drawing.Color.Black;
        //    }
        //    else
        //    {
        //        txtRate.Text = oldText3;
        //        txtRate.BackColor = System.Drawing.Color.Red;
        //        txtRate.ForeColor = System.Drawing.Color.White;
        //    }
        //    txtRate.SelectionStart = txtRate.Text.Length;
        //}

       

        //private void cmbCustName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    using (SqlConnection conn = new SqlConnection(gr))
        //    {

        //        SqlCommand cmd = new SqlCommand("SELECT Cust_ID,ContactNO,Address FROM CustomerDetails WHERE Cust_Name LIKE '" + cmbCustName.SelectedItem.ToString() + "%'", conn);
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                txtCustomerID.Text = (rdr["Cust_ID"].ToString());
        //                txtCustContact.Text = (rdr["ContactNO"].ToString());
        //                txtCustAddress.Text = (rdr["Address"].ToString());
        //            }
        //        }
        //    }
        //    //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            
            
        //}
        private void InvoiceData()
        {
           
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Select Max(Ordre_ID)+1 from OrderDetails", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            txtOrderNo.Text = rdr[0].ToString();
                        }
                        else
                        {
                            txtOrderNo.Text = "1";
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
                //conn.Close();
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            //int Rate = Convert.ToInt32(txtRate.Text);
            //int Qty = Convert.ToInt32(txtQuantity.Text);
            //int T_Amount = Rate * Qty;
            //txtAmount.Text = Convert.ToString(T_Amount.ToString());
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtQuantity.Text;
                txtQuantity.Text = oldText4;

                txtQuantity.BackColor = System.Drawing.Color.White;
                txtQuantity.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtQuantity.Text = oldText4;
                txtQuantity.BackColor = System.Drawing.Color.Red;
                txtQuantity.ForeColor = System.Drawing.Color.White;
            }
            txtQuantity.SelectionStart = txtQuantity.Text.Length;
        }

        public static string oid, cid;
        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            //cid = cmbCustName.Text;
            oid = txtOrderNo.Text;
            OrderFormReport ofreport = new OrderFormReport();
            ofreport.ShowDialog();

            //cmbCustName.SelectedIndex = 0;
            txtOrderBy.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
           // txtRate.Text = "1";
            //txtAmount.Text = "";
            InvoiceData();
            this.dataGridView1.Rows.Clear();
            txtOrderBy.Focus();
        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List.OrderdList OL = new List.OrderdList();
            OL.ShowDialog();
        }

    }
}
