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
    public partial class AddAccounts : Form
    {
        public AddAccounts()
        {
            InitializeComponent();
        }

        private void AddAccounts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet7.SecLevelAcct' table. You can move, or remove it, as needed.
            this.secLevelAcctTableAdapter.Fill(this.inventoryDataSet7.SecLevelAcct);

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            CreateAccounts ca = new CreateAccounts();
            ca.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    //Send the first cell value into textbox'
                    txtID.Text = row.Cells[0].Value.ToString(); // or row.Cells["ColumnName"].Value;
                    txtName.Text = row.Cells[1].Value.ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Delete  FROM SecLevelAcct where ID='" + txtID.Text + "'", conn);
                    SqlCommand cmd2 = new SqlCommand("Delete  FROM ThirdLevelAcct where SID='" + txtID.Text + "'", conn);
                    SqlCommand cmd3 = new SqlCommand("Delete  FROM ActiveTree where SID='" + txtID.Text + "'", conn);
                    conn.Open();

                    cmd2.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted", "JalPak");
                    this.secLevelAcctTableAdapter.Fill(this.inventoryDataSet7.SecLevelAcct);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can Not Be Deleted untill Title Accounts Are Deleted ");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            using (SqlConnection con2 = new SqlConnection(gr))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE SecLevelAcct SET Name='" + txtName.Text + "'  where ID='" + txtID.Text + "'", con2);
                cmd2.CommandType = CommandType.Text;
                con2.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "JalPak");

                this.secLevelAcctTableAdapter.Fill(this.inventoryDataSet7.SecLevelAcct);
                dataGridView1.Invalidate();
                dataGridView1.Refresh();


            }
        }

        private void AddAccounts_Activated(object sender, EventArgs e)
        {
            this.secLevelAcctTableAdapter.Fill(this.inventoryDataSet7.SecLevelAcct);
            dataGridView1.Invalidate();
            dataGridView1.Refresh();
        }

      
    }
}
