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
    public partial class AddTitle : Form
    {
        public AddTitle()
        {
            InitializeComponent();
        }

        private void AddTitle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet8.ThirdLevelAcct' table. You can move, or remove it, as needed.
            this.thirdLevelAcctTableAdapter.Fill(this.inventoryDataSet8.ThirdLevelAcct);

        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            CreateTitle ct = new CreateTitle();
            ct.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            using (SqlConnection con2 = new SqlConnection(gr))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE ThirdLevelAcct SET Name='" + txtName.Text + "'  where ID='" + txtID.Text + "'", con2);
                cmd2.CommandType = CommandType.Text;
                con2.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "JalPak");

                this.thirdLevelAcctTableAdapter.Fill(this.inventoryDataSet8.ThirdLevelAcct);
                dataGridView1.Invalidate();
                dataGridView1.Refresh();


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Delete  FROM ActiveTree where TID='" + txtID.Text + "'", conn);
                    SqlCommand cmd2 = new SqlCommand("Delete  FROM ThirdLevelAcct where ID='" + txtID.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    
                    MessageBox.Show("Record Deleted", "JalPak");
                    this.thirdLevelAcctTableAdapter.Fill(this.inventoryDataSet8.ThirdLevelAcct);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }
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

        private void AddTitle_Activated(object sender, EventArgs e)
        {
            this.thirdLevelAcctTableAdapter.Fill(this.inventoryDataSet8.ThirdLevelAcct);
            dataGridView1.Invalidate();
            dataGridView1.Refresh();
        }
    }
}
