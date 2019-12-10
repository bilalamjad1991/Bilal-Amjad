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
    public partial class Transaction : Form
    {
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public static int debitID;
        public static int creditID;
        public static int AccID;
        public Transaction()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Accounts";
            cmb.Name = "Accounts";
            cmb.MaxDropDownItems = 100;
            dataGridView1.Columns.Add(cmb);

            DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(Description);
            Description.HeaderText = "Description";
            Description.Name = "Description";

            DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(Debit);
            Debit.HeaderText = "Debit";
            Debit.Name = "Debit";

            DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(Credit);
            Credit.HeaderText = "Credit";
            Credit.Name = "Credit";


            dataGridView1.Rows.Add();
            dataGridView1.Refresh();





            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ActiveTree where Active='Yes' And Leaf='Yes'", conn);

                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmb.Items.Add(rdr[4]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }

        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRefNo.Text == "")
            {
                MessageBox.Show("Please Enter Ref No.!");
            }
            else
            {
                try
                {
                    ////////////////////////
                    int dsum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        dsum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                    }
                    txtDebitAmount.Text = dsum.ToString();


                    int csum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        csum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);

                    }
                    txtCreditAmount.Text = csum.ToString();
                    ///////////////////////////////////////////////////////

                    if (dataGridView1.Rows[0].Cells[0].FormattedValue.ToString() == "")
                    {
                        MessageBox.Show("Please Select Account Name!");

                    }
                    else
                    {
                        if (csum == dsum)
                        {
                            try
                            {
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {

                                    using (SqlConnection con3 = new SqlConnection(gr))
                                    {
                                        string SelectedText = Convert.ToString(dataGridView1.Rows[i].Cells[0].FormattedValue.ToString());
                                        SqlCommand cmd3 = new SqlCommand("Select * from ActiveTree where Acct_Name='" + SelectedText + "' ", con3);
                                        con3.Open();
                                        SqlDataReader rdr3 = cmd3.ExecuteReader();

                                        if (rdr3.HasRows)
                                        {
                                            while (rdr3.Read())
                                            {

                                                AccID = Convert.ToInt32(rdr3[3]);

                                            }

                                            // MessageBox.Show("ID is: " + AccID);




                                        }

                                    }

                                    using (SqlConnection con22 = new SqlConnection(gr))
                                    {

                                        SqlCommand cmdd22 = new SqlCommand("Insert into Trnsctns(Ref_ID,Description,Date,Acc_ID,Acc_Name,DrAmount,CrAmount) values ('" + txtRefNo.Text + "','" + dataGridView1.Rows[i].Cells[1].FormattedValue.ToString() + "','" + dateTimePicker1.Value.Date + "','" + AccID + "','" + dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + "','" + dataGridView1.Rows[i].Cells[2].FormattedValue.ToString() + "','" + dataGridView1.Rows[i].Cells[3].FormattedValue.ToString() + "')", con22);
                                        con22.Open();
                                        cmdd22.ExecuteNonQuery();
                                        // MessageBox.Show("Inserted");

                                    }


                                }
                                MessageBox.Show("Transaction Inserted!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }



                        }
                        else
                        {


                            MessageBox.Show("Edit amount");
                        }
                    }
                    ///////////////////////////////////// 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter Correct Value!");
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

            }
            else if (e.ColumnIndex == 1)
            {

            }

            else if (e.ColumnIndex == 2)
            {
               // MessageBox.Show("2");
               
                dataGridView1.Rows[e.RowIndex].Cells[3].ReadOnly = true;
            }
            else if (e.ColumnIndex == 3)
            {
               // MessageBox.Show("3");
               
                dataGridView1.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            }
        }

        private void txtRefNo_Leave(object sender, EventArgs e)
        {

            using (SqlConnection con3 = new SqlConnection(gr))
            {

                SqlCommand cmd3 = new SqlCommand("Select * from Trnsctns where Ref_ID='" + txtRefNo.Text + "' ", con3);
                con3.Open();
                SqlDataReader rdr3 = cmd3.ExecuteReader();

                if (rdr3.HasRows)
                {


                    MessageBox.Show("RefID already exists!");
                    txtRefNo.Focus();
                }

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell.ReadOnly = false;
            
        }

        

       
    }
}
