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
    public partial class Inventory : Form
    {
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public Inventory()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet3.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.inventoryDataSet3.Items);
            // TODO: This line of code loads data into the 'inventoryDataSet1.Items' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'inventoryDataSet.Items' table. You can move, or remove it, as needed.
           
            //// TODO: This line of code loads data into the 'inventoryDataSet2.Items' table. You can move, or remove it, as needed.
            //this.itemsTableAdapter.Fill(this.inventoryDataSet2.Items);
            // TODO: This line of code loads data into the 'inventoryDataSet1.Items' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'inventoryDataSet.Items' table. You can move, or remove it, as needed.
            //this.itemsTableAdapter.Fill(this.inventoryDataSet.Items);            


            InvoiceData();
            dateTimeAddInventoried.Format = DateTimePickerFormat.Custom;
            dateTimeAddInventoried.CustomFormat = "MM/dd/yyyy";

            //txtSearchItemInventoried.Format = DateTimePickerFormat.Custom;
            //txtSearchItemInventoried.CustomFormat = "MM/dd/yyyy";           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            InvoiceData();
            txtAddBrandName.Text = "";
            //txtAddItemCode.Text = "";
            txtAddItemColor.Text = "";
            txtIAddtemCost.Text="";
            txtItemQuantity.Text = "";
            richtxtAddItemDescription.Text = "";
            //dateTimeAddInventoried.Format = DateTimePickerFormat.Custom;
            //dateTimeAddInventoried.CustomFormat = "MM/dd/yyyy";
            cmbAddItemName.Text=""; //this is textbox
            txtAddItemCodee.Focus();
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {                      
            if(txtAddItemCodee.Text=="")
            {
                MessageBox.Show("Some fields are missing.");
                txtAddItemCodee.Focus();
            }
            else if(txtAddBrandName.Text=="")
            {
                MessageBox.Show("Some fields are missing.");
                txtAddBrandName.Focus();
            }
            else if(cmbAddItemName.Text=="")
            {
                MessageBox.Show("Some fields are missing.");
                cmbAddItemName.Focus();
            }
            else if(txtItemQuantity.Text=="")
            {
                MessageBox.Show("Some fields are missing.");
                txtItemQuantity.Focus();
            }
            //else if(txtAddItemColor.Text=="")
            //{
            //    MessageBox.Show("Some fields are missing.");
            //    txtAddItemColor.Focus();
            //}
            else if(txtIAddtemCost.Text=="")
            {
                MessageBox.Show("Some fields are missing.");
                txtIAddtemCost.Focus();
            }
            //else if (richtxtAddItemDescription.Text == "")
            //{
            //    MessageBox.Show("Some fields are missing.");
            //    richtxtAddItemDescription.Focus();
            //}
            else
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT *FROM Items WHERE Code LIKE '" + txtAddItemCodee.Text.ToString() + "%'", con1);
                    cmd1.CommandType = CommandType.Text;
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    SqlDataReader rdr = cmd1.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        MessageBox.Show("Code Already Exist...!");
                        con1.Close();   
                    }                         
                    else
                    {
                        try
                        {
                            //conn.Open();
                            string itemcode = txtAddItemCodee.Text.Trim();
                            string brandname = txtAddBrandName.Text.Trim().ToString();
                            string itemcolor = txtAddItemColor.Text.Trim().ToString();
                            string inventoryDate = dateTimeAddInventoried.Text.Trim().ToString();
                            string Itemname = cmbAddItemName.Text.ToString(); //this is textbox
                            string itemcost = txtIAddtemCost.Text.ToString();
                            string qty = txtItemQuantity.Text.ToString();
                            string description = richtxtAddItemDescription.Text.ToString();

                            //my_querry = "INSERT INTO Items(Code,BrandName,ItemName,Quantity,Description,DateInventoried,Cost)VALUES('" + itemcode + "','" + brandname + "','" + Itemname + "','" + qty + "','" + description + "','" + inventoryDate + "','" + itemcost + "')";
                            using (SqlConnection con2 = new SqlConnection(gr))
                            {
                                SqlCommand cmd2 = new SqlCommand("INSERT INTO Items(Code,BrandName,ItemName,Quantity,Description,DateInventoried,Cost,Color)VALUES('" + itemcode + "','" + brandname + "','" + Itemname + "','" + qty + "','" + description + "','" + inventoryDate + "','" + itemcost + "','" + itemcolor + "')", con2);
                                cmd2.CommandType = CommandType.Text;
                                con2.Open();
                                cmd2.ExecuteNonQuery();
                            }
                            MessageBox.Show(" Item Inserted","JalPak");                                                                                 
                            
                            itemsTableAdapter.Fill(inventoryDataSet3.Items);                            
                            dataGridView2.Invalidate();
                            dataGridView2.Refresh();

                            InvoiceData();
                            txtAddBrandName.Text = "";
                           // txtAddItemCode.Text = "";
                            txtAddItemColor.Text = "";
                            txtIAddtemCost.Text = "";
                            txtItemQuantity.Text = "";
                            richtxtAddItemDescription.Text = "";
                            //dateTimeAddInventoried.Format = DateTimePickerFormat.Custom;
                            //dateTimeAddInventoried.CustomFormat = "MM/dd/yyyy";
                            cmbAddItemName.Text = ""; //this is textbox
                            txtAddItemCodee.Focus();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed due to : " + ex.Message);
                        }
                        finally
                        {
                            rdr.Close();
                            con1.Close();
                           
                            //con1.Close();
                        }
                    }
                   
                }

                //////////////////////////////
                //    SqlConnection conn = new SqlConnection(gr);
                //    //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
                //    conn.Open();
                //    string my_querry = "SELECT *FROM Items WHERE Code LIKE '" + txtAddItemCode.Text.ToString() + "%'";
                //    SqlCommand cmd = new SqlCommand(my_querry, conn);
                //    cmd.ExecuteNonQuery();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    if (rdr.HasRows)
                //    {
                //        MessageBox.Show("Code Already Exist...!");
                //    }
                //    else
                //    {
                //        try
                //        {
                //            //conn.Open();
                //            string itemcode = txtAddItemCode.Text.Trim();
                //            string brandname = txtAddBrandName.Text.Trim().ToString();
                //            string itemcolor = txtAddItemColor.Text.Trim().ToString();
                //            string inventoryDate = dateTimeAddInventoried.Text.Trim().ToString();
                //            string Itemname = cmbAddItemName.Text.ToString(); //this is textbox
                //            string itemcost = txtIAddtemCost.Text.ToString();
                //            string qty = txtItemQuantity.Text.ToString();
                //            string description = richtxtAddItemDescription.Text.ToString();

                //            my_querry = "INSERT INTO Items(Code,BrandName,ItemName,Quantity,Description,DateInventoried,Cost)VALUES('" + itemcode + "','" + brandname + "','" + Itemname + "','" + qty + "','" + description + "','" + inventoryDate + "','" + itemcost + "')";
                //            SqlCommand cmdd = new SqlCommand(my_querry, conn);
                //            cmdd.ExecuteNonQuery();
                //            MessageBox.Show("Data saved successfuly...!");
                //            dataGridView2.Refresh();
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show("Failed due to" + ex.Message);
                //        }
                //        finally
                //        {
                //            conn.Close();
                //        }
                //    }
                //}


            }  
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSciTech about = new AboutSciTech();
            about.ShowDialog();
        }

        private void allItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {                      
           
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList cstList = new CustomerList();
            cstList.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder expression = new StringBuilder();

            if(txtSearchItemCode.Text.Length>0)
            {
                expression.Append("Code = " + txtSearchItemCode.Text + "");
            }
            if(txtSearchBrandName.Text.Length>0)
            {
               if (expression.Length > 0) expression.Append(" and ");
               expression.Append("BrandName Like '%" + txtSearchBrandName.Text + "%'");
            }
            if (cmbSearchItemName.Text.Length> 0)
            {
                if (expression.Length > 0) expression.Append(" and ");
                expression.Append("ItemName like '%" + cmbSearchItemName.Text + "%'");
            }
            if (txtSearchItemSize.Text.Length > 0)
            {
                if (expression.Length > 0) expression.Append(" and ");
                expression.Append("Quantity = " + txtSearchItemSize.Text + "");
            }
            if (txtSearchItemColor.Text.Length > 0)
            {
                if (expression.Length > 0) expression.Append(" and ");
                expression.Append("Color like '%" + txtSearchItemColor.Text + "%'");
            }
            if (txtSearchItemInventoried.Text.Length > 0)
            {
                DateTime dt = DateTime.Parse(txtSearchItemInventoried.Text);
                if (expression.Length > 0) expression.Append(" and ");
                expression.Append("DateInventoried = '" + dt + "'");
            }
            if (txtSearchItemCost.Text.Length > 0)
            {
                if (expression.Length > 0) expression.Append(" and ");
                expression.Append("Cost = " + txtSearchItemCost.Text + "");
            }            
            itemsBindingSource.Filter = expression.ToString();
        }

        string oldText3 = string.Empty;
        string oldText1 = string.Empty;
        string oldText2 = string.Empty;
        string oldText4 = string.Empty;
       
        private void txtAddItemCode_TextChanged(object sender, EventArgs e)
       {
       //     if (txtAddItemCodee.Text.All(chr => char.IsNumber(chr)))
       //     {
       //         oldText3 = txtAddItemCodee.Text;
       //         txtAddItemCodee.Text = oldText3;

       //         txtAddItemCodee.BackColor = System.Drawing.Color.White;
       //         txtAddItemCodee.ForeColor = System.Drawing.Color.Black;
       //     }
       //     else
       //     {
       //         txtAddItemCodee.Text = oldText3;
       //         txtAddItemCodee.BackColor = System.Drawing.Color.Red;
       //         txtAddItemCodee.ForeColor = System.Drawing.Color.White;
       //     }
       //     txtAddItemCodee.SelectionStart = txtAddItemCodee.Text.Length;  
        }

        private void txtAddBrandName_TextChanged(object sender, EventArgs e)
        {
            //if (txtAddBrandName.Text.All(chr => char.IsLetter(chr)))
            //{
            //    oldText1 = txtAddBrandName.Text;
            //    txtAddBrandName.Text = oldText1;

            //    txtAddBrandName.BackColor = System.Drawing.Color.White;
            //    txtAddBrandName.ForeColor = System.Drawing.Color.Black;
            //}
            //else
            //{
            //    txtAddBrandName.Text = oldText1;
            //    txtAddBrandName.BackColor = System.Drawing.Color.Red;
            //    txtAddBrandName.ForeColor = System.Drawing.Color.White;
            //}
            //txtAddBrandName.SelectionStart = txtAddBrandName.Text.Length;
        }

        private void txtItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtItemQuantity.Text.All(chr => char.IsNumber(chr)))
            {
                oldText2 = txtItemQuantity.Text;
                txtItemQuantity.Text = oldText2;

                txtItemQuantity.BackColor = System.Drawing.Color.White;
                txtItemQuantity.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtItemQuantity.Text = oldText2;
                txtItemQuantity.BackColor = System.Drawing.Color.Red;
                txtItemQuantity.ForeColor = System.Drawing.Color.White;
            }
            txtItemQuantity.SelectionStart = txtItemQuantity.Text.Length;  
        }

        private void txtIAddtemCost_TextChanged(object sender, EventArgs e)
        {
            if (txtIAddtemCost.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtIAddtemCost.Text;
                txtIAddtemCost.Text = oldText4;

                txtIAddtemCost.BackColor = System.Drawing.Color.White;
                txtIAddtemCost.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtIAddtemCost.Text = oldText4;
                txtIAddtemCost.BackColor = System.Drawing.Color.Red;
                txtIAddtemCost.ForeColor = System.Drawing.Color.White;
            }
            txtIAddtemCost.SelectionStart = txtIAddtemCost.Text.Length;  
        }


        string srcholdText1 = string.Empty;
        private void txtSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchItemCode.Text.All(chr => char.IsNumber(chr)))
            {
                srcholdText1 = txtSearchItemCode.Text;
                txtSearchItemCode.Text = srcholdText1;

                txtSearchItemCode.BackColor = System.Drawing.Color.White;
                txtSearchItemCode.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtSearchItemCode.Text = srcholdText1;
                txtSearchItemCode.BackColor = System.Drawing.Color.Red;
                txtSearchItemCode.ForeColor = System.Drawing.Color.White;
            }
            txtSearchItemCode.SelectionStart = txtSearchItemCode.Text.Length;  
        }

        string srcholdText2 = string.Empty;
        private void txtSearchBrandName_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearchBrandName.Text.All(chr => char.IsLetter(chr)))
            //{
            //    srcholdText2 = txtSearchBrandName.Text;
            //    txtSearchBrandName.Text = srcholdText2;

            //    txtSearchBrandName.BackColor = System.Drawing.Color.White;
            //    txtSearchBrandName.ForeColor = System.Drawing.Color.Black;
            //}
            //else
            //{
            //    txtSearchBrandName.Text = srcholdText2;
            //    txtSearchBrandName.BackColor = System.Drawing.Color.Red;
            //    txtSearchBrandName.ForeColor = System.Drawing.Color.White;
            //}
            //txtSearchBrandName.SelectionStart = txtSearchBrandName.Text.Length;
        }
        string srcholdText4 = string.Empty;
        private void txtSearchItemSize_TextChanged(object sender, EventArgs e)
        {
             if (txtSearchItemSize.Text.All(chr => char.IsNumber(chr)))
            {
                srcholdText1 = txtSearchItemSize.Text;
                txtSearchItemSize.Text = srcholdText1;

                txtSearchItemSize.BackColor = System.Drawing.Color.White;
                txtSearchItemSize.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtSearchItemSize.Text = srcholdText1;
                txtSearchItemSize.BackColor = System.Drawing.Color.Red;
                txtSearchItemSize.ForeColor = System.Drawing.Color.White;
            }
            txtSearchItemSize.SelectionStart = txtSearchItemSize.Text.Length;  
        
        }
        string srcholdText5 = string.Empty;
        private void txtSearchItemCost_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchItemCost.Text.All(chr => char.IsNumber(chr)))
            {
                srcholdText5 = txtSearchItemCost.Text;
                txtSearchItemCost.Text = srcholdText5;

                txtSearchItemCost.BackColor = System.Drawing.Color.White;
                txtSearchItemCost.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtSearchItemCost.Text = srcholdText5;
                txtSearchItemCost.BackColor = System.Drawing.Color.Red;
                txtSearchItemCost.ForeColor = System.Drawing.Color.White;
            }
            txtSearchItemCost.SelectionStart = txtSearchItemCost.Text.Length;  
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtSearchBrandName.Text = "";
            txtSearchItemCode.Text = "";
            txtSearchItemColor.Text = "";
            txtSearchItemSize.Text = "";
            txtSearchItemCost.Text = "";
            txtSearchItemInventoried.Text = "";
            cmbSearchItemName.Text = ""; //this is textbox
            txtSearchItemCode.Focus();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView2.Rows[e.RowIndex];
                txtSearchItemCode.Text = row.Cells["Code"].Value.ToString();
                txtSearchBrandName.Text = row.Cells["BrandName"].Value.ToString();
                cmbSearchItemName.Text = row.Cells["ItemName"].Value.ToString();
                txtSearchItemSize.Text = row.Cells["Quantity"].Value.ToString();
                txtSearchItemCost.Text = row.Cells["Cost"].Value.ToString();
                txtSearchItemInventoried.Text = row.Cells["DateInventoried"].Value.ToString();
                txtSearchItemColor.Text = row.Cells["Color"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {


            using (SqlConnection con2 = new SqlConnection(gr))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE Items SET Code='" + txtSearchItemCode.Text.Trim() + "',BrandName='" + txtSearchBrandName.Text.Trim() + "', ItemName='" + cmbSearchItemName.Text.Trim() + "', Quantity='" + txtSearchItemSize.Text.Trim() + "', Color='" + txtSearchItemColor.Text.Trim() + "', DateInventoried='" + txtSearchItemInventoried.Text.Trim() + "', Cost='" + txtSearchItemCost.Text.Trim() + "', Description='" + txtDescription.Text.Trim() + "' where Code='" + txtSearchItemCode.Text + "'", con2);
                cmd2.CommandType = CommandType.Text;
                con2.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully","JalPak");
                itemsTableAdapter.Fill(inventoryDataSet3.Items);
                dataGridView2.Invalidate();
                dataGridView2.Refresh();

                txtDescription.Text = "";
                txtSearchBrandName.Text = "";
                txtSearchItemCode.Text = "";
                txtSearchItemColor.Text = "";
                txtSearchItemSize.Text = "";
                txtSearchItemCost.Text = "";
                txtSearchItemInventoried.Text = "";
                cmbSearchItemName.Text = ""; //this is textbox
                txtSearchItemCode.Focus();
            }
            
        }
        private void InvoiceData()
        {
            try
            {

                using (SqlConnection con7 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Select Max(Code)+1 from Items ", con7);
                    con7.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr7 = cmd.ExecuteReader();
                    if (rdr7.Read())
                    {
                        if (!rdr7.IsDBNull(0))
                        {
                            txtAddItemCodee.Text = rdr7[0].ToString();
                            //rdr.Close();
                        }
                        else
                        {
                            txtAddItemCodee.Text = "1";
                        }
                        // rdr.Close();
                    }
                }
                //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }
            finally
            {
                //    conn.Close();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "JalPak", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        DeleteItem(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                        InvoiceData();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Please Select a Record!","JalPak");
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
                    SqlCommand cmd8 = new SqlCommand("DELETE FROM Items WHERE Code = '" + code + "'", con8);
                    con8.Open();
                    cmd8.ExecuteNonQuery();
                    // rdr.Close();
                    MessageBox.Show("Record Deleted", "JalPak");
                    itemsTableAdapter.Fill(inventoryDataSet3.Items);
                    dataGridView2.Invalidate();
                    dataGridView2.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
            }
        }

        private void txtSearchItemInventoried_Leave(object sender, EventArgs e)
        {
            if (txtSearchItemInventoried.Text.Length > 0)
            {
                DateTime dtInventoried;
                bool result = DateTime.TryParse(txtSearchItemInventoried.Text, out dtInventoried);
                if (!result)
                {
                    MessageBox.Show("The date is not in correct format!", "JalPak");
                    txtSearchItemInventoried.BackColor = System.Drawing.Color.Red;
                    txtSearchItemInventoried.Focus();
                }
                else
                    txtSearchItemInventoried.BackColor = System.Drawing.Color.White;
            }
        }


        
    }
}
