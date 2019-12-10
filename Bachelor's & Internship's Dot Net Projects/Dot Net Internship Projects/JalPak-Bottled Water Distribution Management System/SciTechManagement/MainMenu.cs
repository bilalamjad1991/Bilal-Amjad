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

namespace SciTechManagement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.inventoryDataSet.Items);            
            cmbAddItemName.Items.Add("None");
            cmbAddItemName.Items.Add("Pent");
            cmbAddItemName.Items.Add("Shirt");
            cmbAddItemName.Items.Add("Tie");
            cmbAddItemName.Items.Add("Trouser");
            cmbAddItemName.SelectedIndex = 0;
             dateTimeAddInventoried.Format = DateTimePickerFormat.Custom;
             dateTimeAddInventoried.CustomFormat = "dd/MM/yyyy";
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtAddBrandName.Text = "";
            txtAddItemCode.Text = "";
            txtAddItemColor.Text = "";
            txtIAddtemCost.Text="";
            txtItemSize.Text = "";
            richtxtAddItemDescription.Text = "";
            dateTimeAddInventoried.Format = DateTimePickerFormat.Custom;
            dateTimeAddInventoried.CustomFormat = "dd/MM/yyyy";
            cmbAddItemName.SelectedIndex = 0;
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test Items Added!");
            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Inventory.accdb";
            //try
            //{
            //    int Price=1212;
                
            //    conn.Open();
            //    string my_querry = "INSERT INTO Items(Code,BrandName,ItemName,Size,Description,DateInventoried,DateSold,Cost,Price)VALUES('" + txtAddItemCode.Text.ToString() + "','" + txtAddBrandName.Text.ToString() + "','" + cmbAddItemName.SelectedIndex + "','" + txtItemSize + "','" + richtxtAddItemDescription.Text.ToString() + "','" + DateTime.Now + "','" + DateTime.Now + "','" + txtIAddtemCost.Text.ToString() + "','" + Price + "')";
            //    OleDbCommand cmdd = new OleDbCommand(my_querry, conn);
            //    cmdd.ExecuteNonQuery();
            //    //  Associate PrintPreviewDialog with PrintDocument.
            //    //printPreviewDialog1.Document = printDocument1;
            //    //Show PrintPreview Dialog
            //    //printPreviewDialog1.ShowDialog();

            //    MessageBox.Show("Data saved successfully...!");
            //  //  InvoiceData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed due to" + ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList cstList = new CustomerList();
            cstList.ShowDialog();
        }

        private void lnkbtnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSciTech about = new AboutSciTech();
            about.ShowDialog();
        }

        private void allItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllItemsInventoriedForm allitemsReport = new AllItemsInventoriedForm();
            allitemsReport.ShowDialog();
        }

        
    }
}
