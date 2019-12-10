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
    public partial class BonusAndCommision : Form
    {
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public BonusAndCommision()
        {
            InitializeComponent();
        }

        private void BonusAndCommision_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bonusDataSet.Bonus' table. You can move, or remove it, as needed.
            this.bonusTableAdapter.Fill(this.bonusDataSet.Bonus);
            // TODO: This line of code loads data into the 'commissionDataSet.Commission' table. You can move, or remove it, as needed.
            this.commissionTableAdapter.Fill(this.commissionDataSet.Commission);
            // initalize comboBox
            cmbBonus.Items.Add("Base");
            cmbBonus.Items.Add("Percent");
            cmbBonus.SelectedIndex = 0;

            // initalize comboBox
            cmbBonusRate.Items.Add("1");
            cmbBonusRate.Items.Add("2");
            cmbBonusRate.Items.Add("3");
            cmbBonusRate.Items.Add("4");
            cmbBonusRate.SelectedIndex = 0;            
        }        

        private void btnSaveBonus_Click(object sender, EventArgs e)
        {
            
            if(rdbtnAnnually.Checked==true)
            {
                using (SqlConnection con = new SqlConnection(gr))
                {
                    DateTime now = DateTime.Now;
                    DateTime date = new DateTime(now.Year, now.Month, 1);

                    SqlCommand cmd2 = new SqlCommand("Delete from Bonus", con);
                    //  insert record into Bonus table
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bonus(BonusName,BonusType,BonusAmount)VALUES('" + rdbtnAnnually.Text + "','" + cmbBonus.SelectedItem.ToString() + "','" + cmbBonusRate.SelectedItem.ToString() + "')", con);
                   // update query
                    SqlCommand cmd13 = new SqlCommand("UPDATE Employee SET Emp_Bonus='" + cmbBonusRate.SelectedItem.ToString() + "' where Emp_Bonus<>'" + 0 + "'", con);
                    SqlCommand cmd14 = new SqlCommand("UPDATE PayRoll SET Bonus='" + cmbBonusRate.SelectedItem.ToString() + "',Bonus_Type='" + cmbBonus.SelectedItem.ToString() + "',BonusStartDate='" + date + "',BonusExpiryDate='" + date.AddMonths(12) + "' where Bonus<>'" + 0 + "'", con);
                    con.Open();
                    cmd2.ExecuteNonQuery();  // Delete all rows in Bonus Table
                    cmd.ExecuteNonQuery();
                    cmd13.ExecuteNonQuery();
                    cmd14.ExecuteNonQuery();
                    MessageBox.Show("Bonus Saved!", "JalPak");
                    cmbBonus.SelectedIndex = 0;
                    cmbBonusRate.SelectedIndex = 0;
                    rdbtnAnnually.Checked = true;
                    
                    bonusTableAdapter.Fill(bonusDataSet.Bonus);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();

                }
            }
            else if (rdbtnBiannually.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(gr))
                {
                    DateTime now = DateTime.Now;
                    DateTime date = new DateTime(now.Year, now.Month, 1);

                    SqlCommand cmd2 = new SqlCommand("Delete from Bonus", con);
                    //  insert record into Bonus table
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bonus(BonusName,BonusType,BonusAmount)VALUES('" + rdbtnBiannually.Text + "','" + cmbBonus.SelectedItem.ToString() + "','" + cmbBonusRate.SelectedItem.ToString() + "')", con);
                    // update query
                    SqlCommand cmd13 = new SqlCommand("UPDATE Employee SET Emp_Bonus='" + cmbBonusRate.SelectedItem.ToString() + "' where Emp_Bonus<>'" + 0 + "'", con);
                    SqlCommand cmd14 = new SqlCommand("UPDATE PayRoll SET Bonus='" + cmbBonusRate.SelectedItem.ToString() + "',Bonus_Type='" + cmbBonus.SelectedItem.ToString() + "',BonusStartDate='" + date + "',BonusExpiryDate='" + date.AddMonths(6) + "' where Bonus<>'" + 0 + "'", con);
                    con.Open();
                    cmd2.ExecuteNonQuery();  // Delete all rows in Bonus Table
                    cmd.ExecuteNonQuery();
                    cmd13.ExecuteNonQuery();
                    cmd14.ExecuteNonQuery();
                    MessageBox.Show("Bonus Saved!", "JalPak");
                    cmbBonus.SelectedIndex = 0;
                    cmbBonusRate.SelectedIndex = 0;
                    rdbtnAnnually.Checked = true;

                    bonusTableAdapter.Fill(bonusDataSet.Bonus);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            else if(rdbtnQuaterly.Checked==true)
            {
                using (SqlConnection con = new SqlConnection(gr))
                {
                    DateTime now = DateTime.Now;
                    DateTime date = new DateTime(now.Year, now.Month, 1);

                    SqlCommand cmd2 = new SqlCommand("Delete from Bonus", con);
                    //  insert record into Bonus table
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bonus(BonusName,BonusType,BonusAmount)VALUES('" + rdbtnQuaterly.Text + "','" + cmbBonus.SelectedItem.ToString() + "','" + cmbBonusRate.SelectedItem.ToString() + "')", con);
                    SqlCommand cmd13 = new SqlCommand("UPDATE Employee SET Emp_Bonus='" + cmbBonusRate.SelectedItem.ToString() + "' where Emp_Bonus<>'" + 0 + "'", con);
                    SqlCommand cmd14 = new SqlCommand("UPDATE PayRoll SET Bonus='" + cmbBonusRate.SelectedItem.ToString() + "',Bonus_Type='" + cmbBonus.SelectedItem.ToString() + "',BonusStartDate='" + date + "',BonusExpiryDate='" + date.AddMonths(3) + "' where Bonus<>'" + 0 + "'", con);
                    con.Open();
                    cmd2.ExecuteNonQuery();  // Delete all rows in Bonus Table
                    cmd.ExecuteNonQuery();
                    cmd13.ExecuteNonQuery();
                    cmd14.ExecuteNonQuery();
                    MessageBox.Show("Bonus Saved!", "JalPak");
                    cmbBonus.SelectedIndex = 0;
                    cmbBonusRate.SelectedIndex = 0;
                    rdbtnAnnually.Checked = true;

                    bonusTableAdapter.Fill(bonusDataSet.Bonus);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            else if (rdbtnMonthly.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(gr))
                {
                    DateTime now = DateTime.Now;
                    DateTime date = new DateTime(now.Year, now.Month, 1);

                    SqlCommand cmd2 = new SqlCommand("Delete from Bonus", con);
                    //  insert record into Bonus table
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bonus(BonusName,BonusType,BonusAmount)VALUES('" + rdbtnMonthly.Text + "','" + cmbBonus.SelectedItem.ToString() + "','" + cmbBonusRate.SelectedItem.ToString() + "')", con);
                    SqlCommand cmd13 = new SqlCommand("UPDATE Employee SET Emp_Bonus='" + cmbBonusRate.SelectedItem.ToString() + "' where Emp_Bonus<>'" + 0 + "'", con);
                    SqlCommand cmd14 = new SqlCommand("UPDATE PayRoll SET Bonus='" + cmbBonusRate.SelectedItem.ToString() + "',Bonus_Type='" + cmbBonus.SelectedItem.ToString() + "',BonusStartDate='" + date + "',BonusExpiryDate='" + date.AddMonths(1) + "' where Bonus<>'" + 0 + "'", con);
                    con.Open();
                    cmd2.ExecuteNonQuery();  // Delete all rows in Bonus Table
                    cmd.ExecuteNonQuery();
                    cmd13.ExecuteNonQuery();
                    cmd14.ExecuteNonQuery();
                    MessageBox.Show("Bonus Saved!", "JalPak");
                    cmbBonus.SelectedIndex = 0;
                    cmbBonusRate.SelectedIndex = 0;
                    rdbtnAnnually.Checked = true;

                    bonusTableAdapter.Fill(bonusDataSet.Bonus);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select Bonus Type!","JalPak");
            }            
        }

        private void btnSaveCommission_Click(object sender, EventArgs e)
        {

            if (txtNewSale.Text == "" && txtRetention.Text=="")
            {
                MessageBox.Show("Some fields are missing","JalPak");
                txtNewSale.Focus();
            }
            else
            {
                try
                {
                    using (SqlConnection con5 = new SqlConnection(gr))
                    {
                        SqlCommand cmd5 = new SqlCommand("Delete from Commission", con5);
                        //  insert record into Bonus table
                        SqlCommand cmd51 = new SqlCommand("INSERT INTO Commission(NewSale,Retention)VALUES('" + txtNewSale.Text + "','" + txtRetention.Text + "')", con5);
                        SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET Retention='" + txtRetention.Text + "' where Retention<>'" + 0 + "'", con5);
                        con5.Open();
                        cmd5.ExecuteNonQuery();  // Delete all rows in Bonus Table
                        cmd51.ExecuteNonQuery();
                        cmd13.ExecuteNonQuery();
                        MessageBox.Show("Commission Saved!", "JalPak");
                        txtNewSale.Text = "";
                        txtRetention.Text = "";
                        commissionTableAdapter.Fill(commissionDataSet.Commission);
                        dataGridView2.Invalidate();
                        dataGridView2.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Failed due to : " + ex.Message);
                }
            }
                        
        }

        string oldText3 = string.Empty;
        private void txtNewSale_TextChanged(object sender, EventArgs e)
        {
            if (txtNewSale.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtNewSale.Text;
                txtNewSale.Text = oldText3;

                txtNewSale.BackColor = System.Drawing.Color.White;
                txtNewSale.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtNewSale.Text = oldText3;
                txtNewSale.BackColor = System.Drawing.Color.Red;
                txtNewSale.ForeColor = System.Drawing.Color.White;
            }
            txtNewSale.SelectionStart = txtNewSale.Text.Length;
        }

        string oldText4 = string.Empty;
        private void txtRetention_TextChanged(object sender, EventArgs e)
        {
            if (txtRetention.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtRetention.Text;
                txtRetention.Text = oldText4;

                txtRetention.BackColor = System.Drawing.Color.White;
                txtRetention.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtRetention.Text = oldText4;
                txtRetention.BackColor = System.Drawing.Color.Red;
                txtRetention.ForeColor = System.Drawing.Color.White;
            }
            txtRetention.SelectionStart = txtRetention.Text.Length;
        }
     
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView2.Rows[e.RowIndex];
                txtNewSale.Text = row.Cells["NewSale"].Value.ToString();
                txtRetention.Text = row.Cells["Retention"].Value.ToString();
            }
        }
    }
}
