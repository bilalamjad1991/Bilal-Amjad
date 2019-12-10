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
    public partial class PackageDetails : Form
    {
        // write select code for update query
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";

        public PackageDetails()
        {
            InitializeComponent();
        }

        private void PackageDetails_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'packageDataSet.PackageDetail' table. You can move, or remove it, as needed.
            this.packageDetailTableAdapter.Fill(this.packageDataSet.PackageDetail);
            //DealEnddateTimePicker1.Format = DateTimePickerFormat.Custom;
            //DealEnddateTimePicker1.CustomFormat = "MM/dd/yyyy";

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            using (SqlConnection con6 = new SqlConnection(gr))
            {
                SqlCommand cmd6 = new SqlCommand("SELECT ItemName FROM Items", con6);
                con6.Open();
                cmd6.ExecuteNonQuery();
                SqlDataReader rdr6 = cmd6.ExecuteReader();
                if (rdr6.HasRows)
                {
                    while (rdr6.Read())
                    {
                        cmbPackageItems.Items.Add(rdr6[0]);
                    }
                }
            }            
          //  cmbPackageItems.SelectedIndex = 0;
            InvoiceData();
            txtPackageName.Focus();
        }

        string oldText3 = string.Empty;
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtQty.Text;
                txtQty.Text = oldText3;

                txtQty.BackColor = System.Drawing.Color.White;
                txtQty.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtQty.Text = oldText3;
                txtQty.BackColor = System.Drawing.Color.Red;
                txtQty.ForeColor = System.Drawing.Color.White;
            }
            txtQty.SelectionStart = txtQty.Text.Length;
        }

        string oldText4 = string.Empty;
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtRate.Text;
                txtRate.Text = oldText4;

                txtRate.BackColor = System.Drawing.Color.White;
                txtRate.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtRate.Text = oldText4;
                txtRate.BackColor = System.Drawing.Color.Red;
                txtRate.ForeColor = System.Drawing.Color.White;
            }
            txtRate.SelectionStart = txtRate.Text.Length;
        }

        string oldText5 = string.Empty;
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.All(chr => char.IsNumber(chr)))
            {
                oldText5 = txtDiscount.Text;
                txtDiscount.Text = oldText5;

                txtDiscount.BackColor = System.Drawing.Color.White;
                txtDiscount.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtDiscount.Text = oldText5;
                txtDiscount.BackColor = System.Drawing.Color.Red;
                txtDiscount.ForeColor = System.Drawing.Color.White;
            }
            txtDiscount.SelectionStart = txtDiscount.Text.Length;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSavePackage_Click(object sender, EventArgs e)
        {
            if (txtPackageName.Text == "")
            {
                MessageBox.Show("Enter Package Name!","JalPak");
                txtPackageName.Focus();
            }
            else if (cmbPackageItems.SelectedIndex == -1)
            {
                MessageBox.Show("Select Item from list!", "JalPak");
                cmbPackageItems.Focus();
            }
            else if (txtDaystoExpire.Text == "")
            {
                MessageBox.Show("Enter Expiry Date!", "JalPak");
                txtDaystoExpire.Focus();
            }
            else if (txtQty.Text == "")
            {
                MessageBox.Show("Enter Quantity!", "JalPak");
                txtQty.Focus();
            }
            else if (txtRate.Text == "")
            {
                MessageBox.Show("Enter Rate!", "JalPak");
                txtRate.Focus();
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT *FROM PackageDetail WHERE Package_ID = " + txtPackageId.Text.ToString() + "", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        MessageBox.Show("Codes Already Exist...!", "JalPak");
                    }
                    else
                    {
                        rdr.Close();
                        try
                        {
                            //conn.Open();
                            string PackageID = txtPackageId.Text.Trim();
                            string PackageName = txtPackageName.Text.Trim().ToString();
                            string PackageItem = cmbPackageItems.SelectedItem.ToString();
                            //string DealStart = dateTimePicker1.Text.Trim();
                            // string DealEnd = DealEnddateTimePicker1.Text.Trim();
                            string daystoexpire = txtDaystoExpire.Text;
                            string BottleQty = txtQty.Text.ToString();
                            string BottleRate = txtRate.Text.ToString();
                            string Discount = txtDiscount.Text.ToString();
                            string TotalAmount = txtTotalAmount.Text.ToString();

                            using (SqlConnection con2 = new SqlConnection(gr))
                            {
                                // Query will be change
                                //SqlCommand cmdd = new SqlCommand("INSERT INTO PackageDetail(Package_ID,PackageName,ItemName,DealStartDate,DealEndDate,Quantity,Rate,Discount,TotalAmount)VALUES('" + PackageID + "','" + PackageName + "','" + PackageItem + "','" + DealStart + "','" + DealEnd + "','" + BottleQty + "','" + BottleRate + "','" + Discount + "','" + TotalAmount + "')", conn);
                                SqlCommand cmdd = new SqlCommand("INSERT INTO PackageDetail(Package_ID,PackageName,ItemName,ExpiryDays,Quantity,Rate,Discount,TotalAmount)VALUES('" + PackageID + "','" + PackageName + "','" + PackageItem + "','" + daystoexpire + "','" + BottleQty + "','" + BottleRate + "','" + Discount + "','" + TotalAmount + "')", conn);
                                con2.Open();
                                cmdd.ExecuteNonQuery();
                                MessageBox.Show("Package Created", "JalPak");

                                packageDetailTableAdapter.Fill(packageDataSet.PackageDetail);
                                dataGridView1.Invalidate();
                                dataGridView1.Refresh();

                                InvoiceData();
                                txtPackageName.Text = "";
                                cmbPackageItems.SelectedIndex = -1;
                                txtQty.Text = "";
                                txtRate.Text = "";
                                txtDiscount.Text = "";
                                txtTotalAmount.Text = "";
                                txtDaystoExpire.Text = "";
                                txtPackageName.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Enter Correct Value!","JalPak");
                        }
                        finally
                        {
                            conn.Close();
                            rdr.Close();
                        }
                    }
                }
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (txtRate.Text == "")
            {

            }
            else
            {
                int qty = Convert.ToInt32(txtQty.Text);
                int price = Convert.ToInt32(txtRate.Text);
                int deel = qty * price;
                txtTotalAmount.Text = Convert.ToString(deel);
            }            
        }
        private void InvoiceData()
        {                       
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Select Max(Package_ID)+1 from PackageDetail ", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            txtPackageId.Text = rdr[0].ToString();
                        }
                        else
                        {
                            txtPackageId.Text = "1";
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
               // conn.Close();
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {            
            if(txtDiscount.Text == "")
            {

            }
            else
            {
                int total = Convert.ToInt32(txtTotalAmount.Text);
                int discount = Convert.ToInt32(txtDiscount.Text);
                int deel = (total-discount);
                txtTotalAmount.Text = Convert.ToString(deel);
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView1.Rows[e.RowIndex];
                txtPackageId.Text = row.Cells["Package_ID"].Value.ToString();
                txtPackageName.Text = row.Cells["PackageName"].Value.ToString();
                cmbPackageItems.Text = row.Cells["ItemName"].Value.ToString();
                txtDaystoExpire.Text = row.Cells["ExpiryDays"].Value.ToString();
                txtQty.Text = row.Cells["Quantity"].Value.ToString();
                txtRate.Text = row.Cells["Rate"].Value.ToString();
                txtDiscount.Text = row.Cells["Discount"].Value.ToString();
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
            }
        }

        private void btnUpdatePackage_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(gr))
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE PackageDetail SET Package_ID='" + txtPackageId.Text.Trim() + "',PackageName='" + txtPackageName.Text.Trim() + "', ItemName='" + cmbPackageItems.Text.Trim() + "', ExpiryDays='" + txtDaystoExpire.Text.Trim() + "', Quantity='" + txtQty.Text.Trim() + "', Rate='" + txtRate.Text.Trim() + "', Discount='" + txtDiscount.Text.Trim() + "', TotalAmount='" + txtTotalAmount.Text.Trim() + "' where Package_ID='" + txtPackageId.Text + "'", con2);
                    cmd2.CommandType = CommandType.Text;
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Record Updated", "JalPak");

                    packageDetailTableAdapter.Fill(packageDataSet.PackageDetail);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();

                    InvoiceData();
                    txtPackageName.Text = "";
                    cmbPackageItems.SelectedIndex = -1;
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtDiscount.Text = "";
                    txtTotalAmount.Text = "";
                    txtDaystoExpire.Text = "";
                    txtPackageName.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Enter Correct Data!","JalPak");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InvoiceData();
            txtPackageName.Text = "";
            cmbPackageItems.SelectedIndex = -1;
            txtQty.Text = "";
            txtRate.Text = "";
            txtDiscount.Text = "";
            txtTotalAmount.Text = "";
            txtDaystoExpire.Text = "";
            txtPackageName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "JalPak", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        DeleteItem(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
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
        private void DeleteItem(string code)
        {
            // MessageBox.Show(""+code);
            if (string.IsNullOrEmpty(code))
                return;
            try
            {
                using (SqlConnection con8 = new SqlConnection(gr))
                {                  
                    SqlCommand cmd8 = new SqlCommand("DELETE FROM PackageDetail WHERE Package_ID = '" + code + "'", con8);
                    con8.Open();
                    cmd8.ExecuteNonQuery();
                    // rdr.Close();
                    MessageBox.Show("Record Deleted", "JalPak");
                    packageDetailTableAdapter.Fill(packageDataSet.PackageDetail);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
            }
        }
        string oldTextb = string.Empty;
        private void txtDaystoExpire_TextChanged(object sender, EventArgs e)
        {
            if (txtDaystoExpire.Text.All(chr => char.IsNumber(chr)))
            {
                oldTextb = txtDaystoExpire.Text;
                txtDaystoExpire.Text = oldTextb;

                txtDaystoExpire.BackColor = System.Drawing.Color.White;
                txtDaystoExpire.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtDaystoExpire.Text = oldTextb;
                txtDaystoExpire.BackColor = System.Drawing.Color.Red;
                txtDaystoExpire.ForeColor = System.Drawing.Color.White;
            }
            txtDaystoExpire.SelectionStart = txtDaystoExpire.Text.Length;
        }                 
    }
}
