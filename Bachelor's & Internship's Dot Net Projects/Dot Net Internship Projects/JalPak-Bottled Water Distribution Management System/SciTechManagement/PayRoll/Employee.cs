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
    public partial class Employee : Form
    {
        DateTime date;
        int Bonus;
        string bonusName;
        string bonusType;
        int newCust;
        double retention;
        double grossPay;
        DateTime days;

        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'employeeDetailsDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.employeeDetailsDataSet.Employee);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            
            InvoiceData();
           
            cmbEmpType.Items.Add("Fixed Salary");
            cmbEmpType.Items.Add("Commission");
            cmbEmpType.Items.Add("Fixed Salary + Commission");
            //cmbEmpType.Items.Add("No Salary");

            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Dept_Name FROM Department", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmbDept.Items.Add(rdr[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }



        }
        // function to get max value
        private void InvoiceData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("Select Max(Emp_ID)+1 from Employee ", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            txtEmpID.Text = rdr[0].ToString();
                            //rdr.Close();
                        }
                        else
                        {
                            txtEmpID.Text = "1";
                        }
                        // rdr.Close();
                    }
                }
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
        // save employee
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmpType.SelectedIndex == -1)
            {
                MessageBox.Show("Select Employee Type", "JalPak");
                cmbEmpType.Focus();
            }
            else if (txtEmpName.Text == "")
            {
                MessageBox.Show("Enter Employee Name", "JalPak");
                txtEmpName.Focus();
            }
            else if (txtEmpContact.Text == "")
            {
                MessageBox.Show("Enter Contact No", "JalPak");
                txtEmpContact.Focus();
            }
            else if (cmbArea.Text == "")
            {
                MessageBox.Show("Enter Area", "JalPak");
                cmbArea.Focus();
            }
            else if (cmbDept.SelectedIndex == -1)
            {
                MessageBox.Show("Select Department", "JalPak");
                cmbDept.Focus();
            }
            else if (txtBaseSalary.Text == "")
            {
                MessageBox.Show("Enter Base Salary", "JalPak");
                txtBaseSalary.Focus();
            }
            else
            {
                if (cmbEmpType.SelectedIndex == 0)    // if employee type is Fixed salary
                {
                    // check the Bonus value
                    if (chkbxBonus.Checked == true)
                    {
                        using (SqlConnection con1 = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM Bonus", con1);
                            con1.Open();
                            // cmd.ExecuteNonQuery();                    
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Bonus = Convert.ToInt32(rdr["BonusAmount"]);
                                    bonusName = Convert.ToString(rdr["BonusName"]);
                                    bonusType = Convert.ToString(rdr["BonusType"]);
                                }
                                rdr.Close();
                            }
                            // check if bonus is annually
                            if (bonusName == "Annually")
                            {
                                //int annual = 365;
                                //days = annual;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(12);

                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";  //  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);                                   
                                }
                                else
                                {
                                    bonusType = "Percent"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ///////////
                            else if (bonusName == "Biannual")
                            {
                                //int biannual = 182;
                                //days = biannual;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(6);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";   // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);                                   
                                }
                                else
                                {
                                    bonusType = "Percent"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Quaterly")
                            {
                                //int quaterly = 91;
                                //days = quaterly;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(3);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";//  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);
                                }
                                else
                                {
                                    bonusType = "Percent";//  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Monthly")
                            {
                                //int monthly = 30;
                                //days = monthly;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(1);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);
                                }
                                else
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            // calculate salary in  perecentage                     
                        }
                    }
                    insertEmp();// function is used to insert Emp
                    // insert in payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,StartDate,BonusStartDate,BonusExpiryDate,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + DateTime.Now + "','" + DateTime.Now + "','" + date + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    ////////////////////////////////////////////////////////////
                    //   insertEmp();// function is used to insert Emp
                    clearInput();
                }
                else if (cmbEmpType.SelectedIndex == 1) // if employee type is commission
                {
                    // if commission value is checked
                    if (chkbxCommission.Checked == true)
                    {
                        try
                        {       // selects all the items in Commission Table
                            using (SqlConnection con12 = new SqlConnection(gr))
                            {
                                SqlCommand cmd12 = new SqlCommand("SELECT * FROM Commission", con12);
                                con12.Open();
                                // cmd.ExecuteNonQuery();                                
                                SqlDataReader rdr12 = cmd12.ExecuteReader();
                                if (rdr12.HasRows)
                                {
                                    while (rdr12.Read())
                                    {
                                        // newCust = Convert.ToInt32(rdr12["NewSale"]);
                                        retention = Convert.ToDouble(rdr12["Retention"]);
                                    }
                                    // MessageBox.Show("bonus is selected"+Bonus);
                                    rdr12.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    insertEmp();// function is used to insert Emp
                    // insert data into payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,StartDate,BonusStartDate,BonusExpiryDate,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + DateTime.Now + "','" + DateTime.Now + "','" + date + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    //                    insertEmp();// function is used to insert Emp
                    clearInput();
                }
                else if (cmbEmpType.SelectedIndex == 2) // If Selected index is Fixed+Commission
                {
                    // check the Bonus value
                    if (chkbxBonus.Checked == true)
                    {
                        using (SqlConnection con1 = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM Bonus", con1);
                            con1.Open();
                            // cmd.ExecuteNonQuery();                    
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Bonus = Convert.ToInt32(rdr["BonusAmount"]);
                                    bonusName = Convert.ToString(rdr["BonusName"]);
                                    bonusType = Convert.ToString(rdr["BonusType"]);
                                }
                                rdr.Close();
                            }

                            // check if bonus is annual
                            if (bonusName == "Annually")
                            {
                                //int annual = 365;
                                //days = annual;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(12);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ///////////
                            else if (bonusName == "Biannual")
                            {
                                //int biannual = 182;
                                //days = biannual;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(6);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base"; //grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Quaterly")
                            {
                                //int quaterly = 91;
                                //days = quaterly;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(3);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base"; //  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Monthly")
                            {
                                //int monthly = 30;
                                //days = monthly;
                                DateTime now = DateTime.Now;
                                date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(1);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base"; //  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////

                            // calculate salary in  perecentage                     
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////
                    // if commission value is checked
                    if (chkbxCommission.Checked == true)
                    {
                        try
                        {       // selects all the items in Commission Table
                            using (SqlConnection con12 = new SqlConnection(gr))
                            {
                                SqlCommand cmd12 = new SqlCommand("SELECT * FROM Commission", con12);
                                con12.Open();
                                // cmd.ExecuteNonQuery();                                
                                SqlDataReader rdr12 = cmd12.ExecuteReader();
                                if (rdr12.HasRows)
                                {
                                    while (rdr12.Read())
                                    {
                                        // newCust = Convert.ToInt32(rdr12["NewSale"]);
                                        retention = Convert.ToDouble(rdr12["Retention"]);
                                    }
                                    // MessageBox.Show("bonus is selected"+Bonus);
                                    rdr12.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    insertEmp();// function is used to insert Emp
                    // insert data into payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,StartDate,BonusStartDate,BonusExpiryDate,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + DateTime.Now + "','" + DateTime.Now + "','" + date + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                           // clearInput();// added by bilal
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    clearInput();
                }
            }
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
                        InvoiceData();
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

        //   Function is ussed to Delete  the Record
        private void DeleteItem(string code)
        {
           // MessageBox.Show(""+code);
            if (string.IsNullOrEmpty(code))
                return;
          
                using (SqlConnection con8 = new SqlConnection(gr))
                {
                   
                    SqlCommand cmd8 = new SqlCommand("DELETE FROM Employee WHERE Emp_ID = '" + code + "'", con8);
                    con8.Open();
                    cmd8.ExecuteNonQuery();
                    
                    // rdr.Close();
                    MessageBox.Show("Record Deleted!", "JalPak");
                    employeeTableAdapter.Fill(employeeDetailsDataSet.Employee);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();                                       
                }
            }
        
        //   //////////////////////////////////////////////////////// /
        

        private void insertEmp()
        {

            //    This code is used to insert Employee Details 
            try
            {
                using (SqlConnection con22 = new SqlConnection(gr))
                {
                    SqlCommand cmd22 = new SqlCommand("INSERT INTO Employee(Emp_ID,Emp_Type,Emp_JoinDate,Emp_Name,Emp_Email,Emp_Contact,Emp_Area,Emp_Dept,Emp_BaseSalary,Emp_Bonus,Emp_Address)VALUES('" + txtEmpID.Text + "','" + cmbEmpType.SelectedItem.ToString() + "','" + dateTimePicker1.Text + "','" + txtEmpName.Text.Trim().ToString() + "','" + txtEmpEmail.Text.Trim() + "','" + txtEmpContact.Text.Trim() + "','" + cmbArea.Text.Trim() + "','" + cmbDept.SelectedItem.ToString() + "','" + txtBaseSalary.Text.Trim() + "','" + Bonus + "','" + txtEmpAddress.Text.Trim() + "')", con22);
                    con22.Open();
                    cmd22.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!", "JalPak");
                    //clearInput(); bilal
                    //InvoiceData(); bilal
                    employeeTableAdapter.Fill(employeeDetailsDataSet.Employee);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed due To:"+ ex.Message );
            }
           
        }

        private void clearInput()
        {
            InvoiceData();
            txtBaseSalary.Text = "";
            txtEmpAddress.Text = "";
            txtEmpContact.Text = "";
            txtEmpEmail.Text = "";
            txtEmpName.Text = "";
            cmbDept.SelectedIndex = -1;
            cmbArea.Text="";
            cmbEmpType.SelectedIndex = 0;
            chkbxBonus.Checked = false;
            chkbxCommission.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearInput();
            btnSave.Enabled = true;
           // InvoiceData(); bilal
        }

        private void cmbEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpType.SelectedIndex == 0)
            {
                chkbxCommission.Checked = false;
                chkbxBonus.Enabled = true;
                chkbxCommission.Enabled = false;
            }
            else if (cmbEmpType.SelectedIndex == 1)
            {
                chkbxBonus.Checked = false;
                chkbxBonus.Enabled = false;
                chkbxCommission.Enabled = true;
            }
            else if (cmbEmpType.SelectedIndex == 2)
            {
                chkbxBonus.Enabled = true;
                chkbxCommission.Enabled = true;
            }

        }

        private void txtEmpEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmpEmail.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtEmpEmail.Text))
                {
                    txtEmpEmail.BackColor = System.Drawing.Color.Red;
                    txtEmpEmail.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmpEmail.SelectAll();

                    e.Cancel = true;

                }
                else
                {
                    txtEmpEmail.BackColor = System.Drawing.Color.White;
                    txtEmpEmail.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        string oldText3 = string.Empty;
        private void txtEmpContact_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpContact.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtEmpContact.Text;
                txtEmpContact.Text = oldText3;

                txtEmpContact.BackColor = System.Drawing.Color.White;
                txtEmpContact.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtEmpContact.Text = oldText3;
                txtEmpContact.BackColor = System.Drawing.Color.Red;
                txtEmpContact.ForeColor = System.Drawing.Color.White;
            }
            txtEmpContact.SelectionStart = txtEmpContact.Text.Length;
        }

        string oldText4 = string.Empty;
        private void txtBaseSalary_TextChanged(object sender, EventArgs e)
        {
            if (txtBaseSalary.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtBaseSalary.Text;
                txtBaseSalary.Text = oldText4;

                txtBaseSalary.BackColor = System.Drawing.Color.White;
                txtBaseSalary.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtBaseSalary.Text = oldText4;
                txtBaseSalary.BackColor = System.Drawing.Color.Red;
                txtBaseSalary.ForeColor = System.Drawing.Color.White;
            }
            txtBaseSalary.SelectionStart = txtBaseSalary.Text.Length;
        }
        // update query here
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text == "" && txtEmpContact.Text == "" && txtEmpEmail.Text == "" && txtBaseSalary.Text == "")
            {
                MessageBox.Show("Some Fields are missing!", "JalPak");

            }
            else if (cmbEmpType.SelectedItem == null && cmbDept.SelectedIndex == -1 && cmbArea.Text == "")
            {
                MessageBox.Show("Select some values", "JalPak");
            }
            else
            {
                if (cmbEmpType.SelectedIndex == 0) // if employee type is Fixed salary
                {
                    // check the Bonus value
                    if (chkbxBonus.Checked == true)
                    {
                        using (SqlConnection con1 = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM Bonus", con1);
                            con1.Open();
                            // cmd.ExecuteNonQuery();                    
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Bonus = Convert.ToInt32(rdr["BonusAmount"]);
                                    bonusName = Convert.ToString(rdr["BonusName"]);
                                    bonusType = Convert.ToString(rdr["BonusType"]);
                                }
                                rdr.Close();
                            }

                            // check if bonus is annual
                            if (bonusName == "Annually")
                            {
                                //int annual = 365;
                                //days = annual;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(12);
                                if (bonusType == "Base")
                                {
                                    bonusType ="Base";//  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ///////////
                            else if (bonusName == "Biannual")
                            {
                                //int biannual = 182;
                                //days = biannual;
                                DateTime now = DateTime.Now;
                                DateTime bnsExpirydate = new DateTime(now.Year, now.Month, 1);
                                days = bnsExpirydate.AddMonths(6);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Quaterly")
                            {
                                //int quaterly = 91;
                                //days = quaterly;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(3);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base"; //  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent"; //  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Monthly")
                            {
                                //int monthly = 30;
                                //days = monthly;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(1);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent";  // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }

                            // calculate salary in  perecentage                     
                        }
                    }
                    // insert in payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET Emp_ID='" + txtEmpID.Text + "',Salary='" + txtBaseSalary.Text + "', Bonus='" + Bonus + "', Retention='" + retention + "', BonusStartDate='" + date + "', Retention='" + 0 + "', Bonus_Type='" + bonusType + "' where Emp_ID='" + txtEmpID.Text + "'", con13);
                            //SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,GrossCreationDays,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + dateTimePicker1.Text + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    ////////////////////////////////////////////////////////////
                    try
                    {
                        using (SqlConnection con22 = new SqlConnection(gr))
                        {
                            SqlCommand cmd22 = new SqlCommand("UPDATE Employee SET Emp_ID='" + txtEmpID.Text + "',Emp_Type='" + cmbEmpType.SelectedItem.ToString() + "',  Emp_Name='" + txtEmpName.Text.Trim().ToString() + "', Emp_Email='" + txtEmpEmail.Text.Trim() + "', Emp_Contact='" + txtEmpContact.Text.Trim() + "', Emp_Area='" + cmbArea.Text.Trim() + "', Emp_Dept='" + cmbDept.SelectedItem.ToString() + "', Emp_BaseSalary='" + txtBaseSalary.Text.Trim() + "', Emp_Bonus='" + Bonus + "', Emp_Address='" + txtEmpAddress.Text.Trim() + "' where Emp_ID='" + txtEmpID.Text + "'", con22);
                            //SqlCommand cmd22 = new SqlCommand("INSERT INTO Employee(Emp_ID,Emp_Type,Emp_JoinDate,Emp_Name,Emp_Email,Emp_Contact,Emp_Area,Emp_Dept,Emp_BaseSalary,Emp_Bonus,Emp_Address)VALUES('" + txtEmpID.Text + "','" + cmbEmpType.SelectedItem.ToString() + "','" + dateTimePicker1.Text + "','" + txtEmpName.Text.Trim().ToString() + "','" + txtEmpEmail.Text.Trim() + "','" + txtEmpContact.Text.Trim() + "','" + cmbArea.SelectedItem.ToString() + "','" + cmbDept.SelectedItem.ToString() + "','" + txtBaseSalary.Text.Trim() + "','" + Bonus + "','" + txtEmpAddress.Text.Trim() + "')", con22);
                            con22.Open();
                            cmd22.ExecuteNonQuery();
                            // MessageBox.Show("Employee Added!", "JalPak");
                            employeeTableAdapter.Fill(employeeDetailsDataSet.Employee);
                            dataGridView1.Invalidate();
                            dataGridView1.Refresh();

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                    ///////////////////////////////////////////////////////////
                }
                else if (cmbEmpType.SelectedIndex == 1) // if employee type is commission
                {
                    // if commission value is checked
                    if (chkbxCommission.Checked == true)
                    {
                        try
                        {       // selects all the items in Commission Table
                            using (SqlConnection con12 = new SqlConnection(gr))
                            {
                                SqlCommand cmd12 = new SqlCommand("SELECT * FROM Commission", con12);
                                con12.Open();
                                // cmd.ExecuteNonQuery();                                
                                SqlDataReader rdr12 = cmd12.ExecuteReader();
                                if (rdr12.HasRows)
                                {
                                    while (rdr12.Read())
                                    {
                                        // newCust = Convert.ToInt32(rdr12["NewSale"]);
                                        retention = Convert.ToDouble(rdr12["Retention"]);
                                    }
                                    // MessageBox.Show("bonus is selected"+Bonus);
                                    rdr12.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    // insert data into payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET Emp_ID='" + txtEmpID.Text + "',Salary='" + txtBaseSalary.Text + "', Bonus='" + Bonus + "', Retention='" + retention + "', BonusStartDate='" + date + "', Bonus_Type='" + bonusType + "' where Emp_ID='" + txtEmpID.Text + "'", con13);
                            //SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,GrossCreationDays,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + dateTimePicker1.Text + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    ////////////////////////////////////////////////////////////
                    try
                    {
                        using (SqlConnection con22 = new SqlConnection(gr))
                        {
                            SqlCommand cmd22 = new SqlCommand("UPDATE Employee SET Emp_ID='" + txtEmpID.Text + "',Emp_Type='" + cmbEmpType.SelectedItem.ToString() + "', Emp_Name='" + txtEmpName.Text.Trim().ToString() + "', Emp_Email='" + txtEmpEmail.Text.Trim() + "', Emp_Contact='" + txtEmpContact.Text.Trim() + "', Emp_Area='" + cmbArea.Text.Trim() + "', Emp_Dept='" + cmbDept.SelectedItem.ToString() + "', Emp_BaseSalary='" + txtBaseSalary.Text.Trim() + "', Emp_Bonus='" + Bonus + "', Emp_Address='" + txtEmpAddress.Text.Trim() + "' where Emp_ID='" + txtEmpID.Text + "'", con22);
                            //SqlCommand cmd22 = new SqlCommand("INSERT INTO Employee(Emp_ID,Emp_Type,Emp_JoinDate,Emp_Name,Emp_Email,Emp_Contact,Emp_Area,Emp_Dept,Emp_BaseSalary,Emp_Bonus,Emp_Address)VALUES('" + txtEmpID.Text + "','" + cmbEmpType.SelectedItem.ToString() + "','" + dateTimePicker1.Text + "','" + txtEmpName.Text.Trim().ToString() + "','" + txtEmpEmail.Text.Trim() + "','" + txtEmpContact.Text.Trim() + "','" + cmbArea.SelectedItem.ToString() + "','" + cmbDept.SelectedItem.ToString() + "','" + txtBaseSalary.Text.Trim() + "','" + Bonus + "','" + txtEmpAddress.Text.Trim() + "')", con22);
                            con22.Open();
                            cmd22.ExecuteNonQuery();
                            //  MessageBox.Show("Employee Added!", "JalPak");
                            employeeTableAdapter.Fill(employeeDetailsDataSet.Employee);
                            dataGridView1.Invalidate();
                            dataGridView1.Refresh();

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                    ///////////////////////////////////////////////////////////
                    clearInput();
                }
                else if (cmbEmpType.SelectedIndex == 2) // If Selected index is Fixed+Commission
                {
                    // check the Bonus value
                    if (chkbxBonus.Checked == true)
                    {
                        using (SqlConnection con1 = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM Bonus", con1);
                            con1.Open();
                            // cmd.ExecuteNonQuery();                    
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Bonus = Convert.ToInt32(rdr["BonusAmount"]);
                                    bonusName = Convert.ToString(rdr["BonusName"]);
                                    bonusType = Convert.ToString(rdr["BonusType"]);
                                }
                                rdr.Close();
                            }

                            // check if bonus is annual
                            if (bonusName == "Annually")
                            {
                                //int annual = 365;
                                //days = annual;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(12);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ///////////
                            else if (bonusName == "Biannual")
                            {
                                //int biannual = 182;
                                //days = biannual;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(6);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";//grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent"; // grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Quaterly")
                            {
                                //int quaterly = 91;
                                //days = quaterly;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(3);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";//  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////
                            else if (bonusName == "Monthly")
                            {
                                //int monthly = 30;
                                //days = monthly;
                                DateTime now = DateTime.Now;
                                DateTime date = new DateTime(now.Year, now.Month, 1);
                                days = date.AddMonths(1);
                                if (bonusType == "Base")
                                {
                                    bonusType = "Base";//  grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus);

                                }
                                else if (bonusType == "Percent")
                                {
                                    bonusType = "Percent";// grossPay = (Convert.ToDouble(txtBaseSalary.Text) * Bonus) / 100;
                                }
                            }
                            ////////////

                            // calculate salary in  perecentage                     
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////
                    // if commission value is checked
                    if (chkbxCommission.Checked == true)
                    {
                        try
                        {       // selects all the items in Commission Table
                            using (SqlConnection con12 = new SqlConnection(gr))
                            {
                                SqlCommand cmd12 = new SqlCommand("SELECT * FROM Commission", con12);
                                con12.Open();
                                // cmd.ExecuteNonQuery();                                
                                SqlDataReader rdr12 = cmd12.ExecuteReader();
                                if (rdr12.HasRows)
                                {
                                    while (rdr12.Read())
                                    {
                                        // newCust = Convert.ToInt32(rdr12["NewSale"]);
                                        retention = Convert.ToDouble(rdr12["Retention"]);
                                    }
                                    // MessageBox.Show("bonus is selected"+Bonus);
                                    rdr12.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    // insert data into payroll table
                    try
                    {
                        using (SqlConnection con13 = new SqlConnection(gr))
                        {
                            SqlCommand cmd13 = new SqlCommand("UPDATE PayRoll SET Emp_ID='" + txtEmpID.Text + "',Salary='" + txtBaseSalary.Text + "', Bonus='" + Bonus + "', Retention='" + retention + "', BonusStartDate='" + days + "', Bonus_Type='" + bonusType + "' where Emp_ID='" + txtEmpID.Text + "'", con13);
                            //SqlCommand cmd13 = new SqlCommand("INSERT INTO PayRoll(Emp_ID,Salary,Bonus,Retention,JoinDate,GrossCreationDays,Bonus_Type)VALUES('" + txtEmpID.Text + "','" + txtBaseSalary.Text + "','" + Bonus + "','" + retention + "','" + dateTimePicker1.Text + "','" + days + "','" + bonusType + "')", con13);
                            con13.Open();
                            cmd13.ExecuteNonQuery();
                            // MessageBox.Show("Values added into Payroll Table!", "JalPak");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    ////////////////////////////////////////////////////////////
                    try
                    {
                        using (SqlConnection con22 = new SqlConnection(gr))
                        {
                            SqlCommand cmd22 = new SqlCommand("UPDATE Employee SET Emp_ID='" + txtEmpID.Text + "',Emp_Type='" + cmbEmpType.SelectedItem.ToString() + "', Emp_Name='" + txtEmpName.Text.Trim().ToString() + "', Emp_Email='" + txtEmpEmail.Text.Trim() + "', Emp_Contact='" + txtEmpContact.Text.Trim() + "', Emp_Area='" + cmbArea.Text.Trim() + "', Emp_Dept='" + cmbDept.SelectedItem.ToString() + "', Emp_BaseSalary='" + txtBaseSalary.Text.Trim() + "', Emp_Bonus='" + Bonus + "', Emp_Address='" + txtEmpAddress.Text.Trim() + "' where Emp_ID='" + txtEmpID.Text + "'", con22);
                            //SqlCommand cmd22 = new SqlCommand("INSERT INTO Employee(Emp_ID,Emp_Type,Emp_JoinDate,Emp_Name,Emp_Email,Emp_Contact,Emp_Area,Emp_Dept,Emp_BaseSalary,Emp_Bonus,Emp_Address)VALUES('" + txtEmpID.Text + "','" + cmbEmpType.SelectedItem.ToString() + "','" + dateTimePicker1.Text + "','" + txtEmpName.Text.Trim().ToString() + "','" + txtEmpEmail.Text.Trim() + "','" + txtEmpContact.Text.Trim() + "','" + cmbArea.SelectedItem.ToString() + "','" + cmbDept.SelectedItem.ToString() + "','" + txtBaseSalary.Text.Trim() + "','" + Bonus + "','" + txtEmpAddress.Text.Trim() + "')", con22);
                            con22.Open();
                            cmd22.ExecuteNonQuery();
                            //  MessageBox.Show("Employee Added!", "JalPak");
                            employeeTableAdapter.Fill(employeeDetailsDataSet.Employee);
                            dataGridView1.Invalidate();
                            dataGridView1.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                    ///////////////////////////////////////////////////////////
                    clearInput();
                }
            }

            MessageBox.Show("Updated Successfully!", "JalPak");
            InvoiceData();
            clearInput();
            btnSave.Enabled = true; //by bilal
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView1.Rows[e.RowIndex];
                txtEmpID.Text = row.Cells["Emp_ID"].Value.ToString();
                txtBaseSalary.Text = row.Cells["Emp_BaseSalary"].Value.ToString();
                txtEmpAddress.Text = row.Cells["Emp_Address"].Value.ToString();
                txtEmpContact.Text = row.Cells["Emp_Contact"].Value.ToString();
                txtEmpEmail.Text = row.Cells["Emp_Email"].Value.ToString();
                txtEmpName.Text = row.Cells["Emp_Name"].Value.ToString();
                cmbDept.SelectedItem = row.Cells["Emp_Dept"].Value.ToString();
                cmbArea.Text = row.Cells["Emp_Area"].Value.ToString();
                cmbEmpType.SelectedItem = row.Cells["Emp_Type"].Value.ToString(); ;
                btnSave.Enabled = false; //by bilal
            }
        }

        private void txtEmpAddress_Validating(object sender, CancelEventArgs e)
        {

            System.Text.RegularExpressions.Regex rAddress = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9., ]+$");

            if (txtEmpAddress.Text.Length > 0)
            {

                if (!rAddress.IsMatch(txtEmpAddress.Text))
                {
                    txtEmpAddress.BackColor = System.Drawing.Color.Red;
                    txtEmpAddress.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmpAddress.SelectAll();

                    e.Cancel = true;

                }
                else
                {
                    txtEmpAddress.BackColor = System.Drawing.Color.White;
                    txtEmpAddress.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
}
