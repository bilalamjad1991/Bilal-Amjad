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
    public partial class SearchTransaction : Form
    {
        public static string dateFrom;
        public static string dateTo;
        public static int RefID;


        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public SearchTransaction()
        {
            InitializeComponent();
        }

        private void SearchTransaction_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con3 = new SqlConnection(gr))
            {

                SqlCommand cmd3 = new SqlCommand("Select Ref_ID,Description,Date,Acc_ID,Acc_Name,DrAmount,CrAmount from Trnsctns where Date between'" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "' AND Ref_ID='" + textBox1.Text + "' ", con3);
                con3.Open();
               
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd3.Connection = con3;
                    sda.SelectCommand = cmd3;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;

                    }
                }
                
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Ref#!", "JalPak");
            }
            ////////////////////////////////////edited today
            else
            {
                using (SqlConnection con3 = new SqlConnection(gr))
                {

                    SqlCommand cmd3 = new SqlCommand("Select * from Trnsctns where Ref_ID='" + textBox1.Text + "' ", con3);
                    con3.Open();
                    SqlDataReader rdr3 = cmd3.ExecuteReader();

                    if (rdr3.HasRows)
                    {
//was empty
                    }
                    else
                    {

                        MessageBox.Show("RefID Does Not Exists!");
                    }

                }
            }
                ////////////////////////////////////edited today
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Enter RefID!");
            }
            else{
            dateFrom = Convert.ToString(dateTimePicker1.Value.Date);
            dateTo = Convert.ToString(dateTimePicker2.Value.Date);
            RefID = Convert.ToInt32(textBox1.Text);
            //TransactionReportForm trf = new TransactionReportForm();
            //trf.Show();
            TransactionReportForm trf = new TransactionReportForm();
            trf.ShowDialog();
            }

        }
    }
}
