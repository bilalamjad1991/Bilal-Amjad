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
    public partial class GrossSalary : Form
    {
        DateTime updatedExpiryDate;
        decimal newCustAmount;
        decimal calCommissionAmount;
        DateTime BonusStartDate;
        DateTime BonusExpiryDate;
        string BonusName, BonusType;
        decimal BonusAmount;
        decimal calBonusAmount;
        double bonusDays;
        decimal calSalary;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";


        public GrossSalary()
        {
            InitializeComponent();
        }

        private void GrossSalary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'salaryDataSet9.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.salaryDataSet9.Employee);

            DataGridViewTextBoxColumn month = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(month);
            month.HeaderText = "Month";
            month.Name = "Month";
            month.ReadOnly = true;
            DateTime now = DateTime.Now;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                this.dataGridView1.Rows[i].Cells["Month"].Value = Convert.ToString(now.ToString("MMMM"));

            }


            DataGridViewTextBoxColumn dt = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(dt);
            dt.HeaderText = "Date";
            dt.Name = "dateToday";
            dt.ReadOnly = true;
            dt.Width = 120;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                this.dataGridView1.Rows[i].Cells["dateToday"].Value = Convert.ToString(DateTime.Now);

            }


            DataGridViewTextBoxColumn slry = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(slry);
            slry.HeaderText = "Salary";
            slry.Name = "Salary";
            slry.ReadOnly = true;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                this.dataGridView1.Rows[i].Cells["Salary"].Value = "";

            }


            DataGridViewLinkColumn Pay = new DataGridViewLinkColumn();
            dataGridView1.Columns.Add(Pay);
            Pay.Name = "Pay";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                this.dataGridView1.Rows[i].Cells["Pay"].Value = Convert.ToString("Pay");

            }
            /////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[i].Cells[0].Value + "'", con1);
                    con1.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                            DateTime sd = Convert.ToDateTime(rdr["StartDate"]);
                            decimal salary = Convert.ToDecimal(rdr["Salary"]);
                            decimal perDaySalary = salary / 30;
                            DateTime today = DateTime.Today;

                            double days = (today - sd).TotalDays;

                            calSalary = perDaySalary * Convert.ToDecimal(days);

                            dataGridView1.Rows[i].Cells[4].Value = Math.Round(calSalary, 2);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found!", "JalPak");
                    }
                }




            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ////////////////////////////////////////comission calculation///////////////////
            try
            {



                using (SqlConnection con13 = new SqlConnection(gr))
                {
                    SqlCommand cmd13 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con13);
                    con13.Open();
                    SqlDataReader rdr = cmd13.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            decimal retention = Convert.ToDecimal(rdr["Retention"]);
                            decimal empSales = Convert.ToDecimal(rdr["Emp_Sales"]);

                            calCommissionAmount = (retention * empSales) / 100;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            /////////////////////////////////////////////////////////////////for getting new customer amount//////
            try
            {



                using (SqlConnection con13 = new SqlConnection(gr))
                {
                    SqlCommand cmd13 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con13);
                    con13.Open();
                    SqlDataReader rdr = cmd13.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            newCustAmount = Convert.ToDecimal(rdr["NewCust"]);



                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }






            ////////////////////////////////////////////////////////////////////////////////
            try
            {



                using (SqlConnection con13 = new SqlConnection(gr))
                {
                    SqlCommand cmd13 = new SqlCommand("Select * from Bonus", con13);
                    con13.Open();
                    SqlDataReader rdr = cmd13.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            BonusName = Convert.ToString(rdr["BonusName"]);
                            BonusType = Convert.ToString(rdr["BonusType"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            if (BonusName == "Biannual" && BonusType == "Percent")
            {

                //DateTime today = DateTime.Today;
                //    //DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                //    ////MessageBox.Show("" + endOfMonth.Day);
                //    //int EOM = endOfMonth.Day;

                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus) / 100;
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 180, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }
            }
            else if (BonusName == "Biannual" && BonusType == "Base")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus);
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 180, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Annually" && BonusType == "Percent")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus) / 100;
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 365, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Annually" && BonusType == "Base")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus);
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 365, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Quaterly" && BonusType == "Percent")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus) / 100;
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 90, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Quaterly" && BonusType == "Base")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus);
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 90, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Monthly" && BonusType == "Percent")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus) / 100;
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 30, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }

            else if (BonusName == "Monthly" && BonusType == "Base")
            {
                using (SqlConnection con1 = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {             //local variable bonusStartDate
                            DateTime bonusStartDate = Convert.ToDateTime(rdr["BonusStartDate"]);

                            //if (bonusStartDate.Day == 1)
                            //{
                            //    MessageBox.Show("Yes");

                            //}

                            //else// incase start date is greater than 1
                            //{
                            DateTime today = DateTime.Today;
                            bonusDays = (today - bonusStartDate).TotalDays;

                            using (SqlConnection con11 = new SqlConnection(gr))
                            {
                                SqlCommand cmd11 = new SqlCommand(" SELECT * from PayRoll where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con11);
                                con11.Open();


                                SqlDataReader rdr11 = cmd11.ExecuteReader();
                                if (rdr11.HasRows)
                                {
                                    while (rdr11.Read())
                                    {

                                        decimal Salary = Convert.ToDecimal(rdr11["Salary"]);
                                        decimal Bonus = Convert.ToDecimal(rdr11["Bonus"]);
                                        BonusAmount = (Salary * Bonus);
                                        decimal tempcalBonusAmount = (BonusAmount / 30);
                                        //calBonusAmount = Math.Round(tempcalBonusAmount * Convert.ToDecimal(bonusDays), 2);
                                        calBonusAmount = Math.Round(tempcalBonusAmount * 30, 2);

                                        MessageBox.Show("Bonus: " + calBonusAmount);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Record Not Found!", "JalPak");
                                }


                            }

                            // }  ///////////////////////////////////////////////////
                        }

                    }

                }


            }
            ///////////////////////////////////////////////////////////////////Salary Insertion///////////////////////////////////////////////////////////////////////////


            using (SqlConnection con1 = new SqlConnection(gr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Salary where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'" + " and Date ='" + DateTime.Today + "'", con1);
                con1.Open();
                //cmd.ExecuteNonQuery();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    MessageBox.Show("Already Paid!", "JalPak");
                }
                else
                {
                    //////////////////////////////////////////////////////check for date of bonus giving////////////////////
                    using (SqlConnection con111 = new SqlConnection(gr))
                    {
                        SqlCommand cmd111 = new SqlCommand("SELECT * from PayRoll where Emp_Id='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con111);
                        con111.Open();


                        SqlDataReader rdr111 = cmd111.ExecuteReader();
                        if (rdr111.HasRows)
                        {
                            while (rdr111.Read())
                            {
                                BonusExpiryDate = Convert.ToDateTime(rdr111["BonusExpiryDate"]);
                            }
                        }
                    }

                    /////////////////////////////////////////////////////////////get BonusStartDate






                    DateTime today2 = DateTime.Today;
                    int result = DateTime.Compare(today2, BonusExpiryDate);
                    //double bst = (today2 - BonusStartDate).TotalDays;
                    if (result < 0)
                    {

                        using (SqlConnection con2 = new SqlConnection(gr))
                        {
                            decimal assignGross = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value) + calCommissionAmount + newCustAmount;

                            SqlCommand cmd2 = new SqlCommand(" INSERT into Salary (Emp_ID,Emp_Name,Month,Date,GrossSalary) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + assignGross + "')", con2);
                            con2.Open();
                            cmd2.ExecuteNonQuery();


                            MessageBox.Show("Record Inserted!", "JalPak");


                        }


                        try
                        {



                            using (SqlConnection con13 = new SqlConnection(gr))
                            {
                                SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET StartDate='" + DateTime.Today + "',Emp_Sales='" + 0 + "',NewCust='" + 0 + "' where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con13);
                                con13.Open();
                                cmd13.ExecuteNonQuery();

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (result == 0)
                    {

                        using (SqlConnection con2 = new SqlConnection(gr))
                        {
                            decimal assignGross = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value) + calBonusAmount + calCommissionAmount + newCustAmount;

                            SqlCommand cmd2 = new SqlCommand(" INSERT into Salary (Emp_ID,Emp_Name,Month,Date,GrossSalary) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + assignGross + "')", con2);
                            con2.Open();
                            cmd2.ExecuteNonQuery();


                            MessageBox.Show("Record Inserted!", "JalPak");


                        }


                        try
                        {
                            //chk for bonus policy to update bonus expiry date
                            if (BonusName == "Annually")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(12);
                            }
                            else if (BonusName == "Biannual")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(6);
                            }
                            else if (BonusName == "Quaterly")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(4);
                            }
                            else if (BonusName == "Monthly")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(1);

                            }
                            ///////////////////////////////////////////////////
                            using (SqlConnection con13 = new SqlConnection(gr))
                            {
                                SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET StartDate='" + DateTime.Today + "', BonusStartDate='" + BonusExpiryDate + "', BonusExpiryDate='" + updatedExpiryDate + "' ,Emp_Sales='" + 0 + "',NewCust='" + 0 + "' where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con13);
                                con13.Open();
                                cmd13.ExecuteNonQuery();

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {

                        using (SqlConnection con2 = new SqlConnection(gr))
                        {
                            decimal assignGross = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value) + calBonusAmount + calCommissionAmount + newCustAmount;

                            SqlCommand cmd2 = new SqlCommand(" INSERT into Salary (Emp_ID,Emp_Name,Month,Date,GrossSalary) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + assignGross + "')", con2);
                            con2.Open();
                            cmd2.ExecuteNonQuery();


                            MessageBox.Show("Record Inserted!", "JalPak");


                        }


                        try
                        {
                            //chk for bonus policy to update bonus expiry date
                            if (BonusName == "Annually")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(12);
                            }
                            else if (BonusName == "Biannual")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(6);
                            }
                            else if (BonusName == "Quaterly")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(4);
                            }
                            else if (BonusName == "Monthly")
                            {
                                updatedExpiryDate = BonusExpiryDate.AddMonths(1);

                            }
                            ///////////////////////////////////////////////////


                            using (SqlConnection con13 = new SqlConnection(gr))
                            {
                                SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET StartDate='" + DateTime.Today + "', BonusStartDate='" + BonusExpiryDate + "', BonusExpiryDate='" + updatedExpiryDate + "', Emp_Sales='" + 0 + "',NewCust='" + 0 + "' where Emp_ID='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con13);
                                con13.Open();
                                cmd13.ExecuteNonQuery();

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                    }
                    ////////////////////////////////////////////////////////////////////////////////////
                }
            }








            //////////////////////////////////////////
        }
    }
}
