using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace SciTechManagement
{
    public partial class CustomerDetails : Form
    {
        int pacID;
        int qty;
        int expirydays;
        string DealDate;
        string bttleCnsmed; ////ad by bil
        string CustomerID;
        int PackageID;
        int empID;
        int rsOnNewSale;  // Rs for new custmer creation
        int NewCreation; // payroll value

        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerDetailsDataSet7.CustomerDetails' table. You can move, or remove it, as needed.
            this.customerDetailsTableAdapter.Fill(this.customerDetailsDataSet7.CustomerDetails);
            //// TODO: This line of code loads data into the 'customerDetailDataSet7.CustomerDetails' table. You can move, or remove it, as needed.
            //this.customerDetailsTableAdapter.Fill(this.customerDetailDataSet7.CustomerDetails);
            
            InvoiceData();
            cmbCustType.Items.Add("Regular");
            cmbCustType.Items.Add("Deal");


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

           // cmbCustType.SelectedIndex = 0;
            cmbPackage.Items.Add("No Deal");
            // Fetch package name from PackageDetail Table
            using (SqlConnection conn = new SqlConnection(gr))
             {
                 SqlCommand cmd = new SqlCommand("SELECT PackageName FROM PackageDetail", conn);
                 conn.Open();
                 cmd.ExecuteNonQuery();
                 SqlDataReader rdr = cmd.ExecuteReader();
                 if (rdr.HasRows)
                 {
                     while (rdr.Read())
                     {
                         cmbPackage.Items.Add(rdr[0]);
                     }                    
                 }
             }

            // Fetch employee name from employee table
            using (SqlConnection conn1 = new SqlConnection(gr))
            {
                SqlCommand cmdd1 = new SqlCommand("SELECT Emp_Name FROM Employee", conn1);
                conn1.Open();
                cmdd1.ExecuteNonQuery();
                SqlDataReader rdrr1 = cmdd1.ExecuteReader();
                if (rdrr1.HasRows)
                {
                    while (rdrr1.Read())
                    {
                       cmbEmployee.Items.Add(rdrr1[0]);
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////

            using (SqlConnection conn1 = new SqlConnection(gr))
            {
                SqlCommand cmdd1 = new SqlCommand("SELECT Emp_Area FROM Employee", conn1);
                conn1.Open();
                cmdd1.ExecuteNonQuery();
                SqlDataReader rdrr1 = cmdd1.ExecuteReader();
                if (rdrr1.HasRows)
                {
                    while (rdrr1.Read())
                    {
                        txtArea.Items.Add(rdrr1[0]);
                    }
                }
            }



            // TODO: This line of code loads data into the 'customerDetailsDataSet.CustomerDetails' table. You can move, or remove it, as needed.
            //this.customerDetailsTableAdapter.Fill(this.customerDetailsDataSet.CustomerDetails);//cmbPackage.SelectedIndex = 0; 
        }

        private void btnCloseCustForm_Click(object sender, EventArgs e)
        {
            this.Close();                             
        }

        int rate;
        private void btnSaveCust_Details_Click(object sender, EventArgs e)
        {

            //if (txtAddCompany.Text == "" && txtAddContact.Text == "" && txtAddEmail.Text == "" && txtAddFName.Text == "" && txtArea.SelectedIndex == -1 && cmbEmployee.SelectedIndex == -1 && txtAddress.Text == "" && txtAddSecurityDeposit.Text == "" && cmbEmployee.SelectedIndex==-1)
            //{
            //    MessageBox.Show("Some Fields are missing!","JalPak");
            //}
            //else if (txtAddress.Text == "" && txtAddSecurityDeposit.Text == "")
            //{
            //    MessageBox.Show("Some Fields are missing!", "JalPak");
            //}
            if (txtAddCompany.Text == "")
            {
                MessageBox.Show("Enter company name","JalPak");
            }
            else if (txtAddContact.Text == "" )
            {
                MessageBox.Show("Enter contact no", "JalPak");
            }           
            else if (txtAddFName.Text == "")
            {
                MessageBox.Show("Enter name", "JalPak");
            }
            else if (txtArea.SelectedIndex == -1)
            {
                MessageBox.Show("Select are from the list", "JalPak");
            }
            else if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Select employee from the list", "JalPak");
            }
            //else if (txtAddress.Text == "")
            //{
            //    MessageBox.Show("Enter address", "JalPak");
            //}
            else if(txtAddSecurityDeposit.Text == "")
            {
                MessageBox.Show("Enter security deposit","JalPak");
            }
            else
            {
                //string CustomerID;
                //int PackageID;
                if (cmbPackage.SelectedIndex == 0)
                {
                    using (SqlConnection contemp = new SqlConnection(gr))
                    {
                        SqlCommand cmd5 = new SqlCommand("SELECT Cust_ID FROM CustomerDetails WHERE Cust_ID = '" + txtAddCust_ID.Text + "'", contemp);
                        contemp.Open();
                        cmd5.ExecuteNonQuery();
                        SqlDataReader rdrtemp = cmd5.ExecuteReader();
                        if (rdrtemp.HasRows)
                        {
                            MessageBox.Show("Record Already Exist", "JalPak");
                            rdrtemp.Close();
                        }
                        else
                        {
                            /////////////////////////////////////    This code is used to insert Regular customer        /////////////////////////////////////
                            CustomerID = txtAddCust_ID.Text.Trim().ToString();
                            string Company = txtAddCompany.Text.Trim().ToString();
                            string CustomerName = txtAddFName.Text.Trim().ToString();
                            string ContactNo = txtAddContact.Text.Trim().ToString();
                            string Email = txtAddEmail.Text.Trim().ToString();
                            string CustomerType = cmbCustType.SelectedItem.ToString();
                            string Address = txtAddress.Text.ToString();
                            DealDate = dateTimePicker1.Text.ToString();
                            PackageID = pacID;                                         // some thing wrong
                            string Package = cmbPackage.SelectedItem.ToString();
                            string area = txtArea.SelectedItem.ToString();
                            string dealingemployee = cmbEmployee.SelectedItem.ToString();
                            string SecurityDeposit = txtAddSecurityDeposit.Text.ToString();
                            try
                            {
                                using (SqlConnection con2 = new SqlConnection(gr))
                                {
                                    SqlCommand cmdd = new SqlCommand("INSERT INTO CustomerDetails(Cust_ID,ContactNO,Cust_Name,Cust_Type,Email,Address,Company,Package,DealStartDate,Area,DealingEmployee,SecurityDeposit)VALUES('" + CustomerID + "','" + ContactNo + "','" + CustomerName + "','" + CustomerType + "','" + Email + "','" + Address + "','" + Company + "','" + Package + "','" + DealDate + "','" + area + "','" + dealingemployee + "','" + SecurityDeposit + "')", con2);
                                    con2.Open();
                                    cmdd.ExecuteNonQuery();
                                    MessageBox.Show("Regular Customer Added!", "JalPak");

                                    EmployeeCreationBonus(); // fucnction to calculate the employee bonus on new customer creation

                                    customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                                    dataGridView1.Invalidate();
                                    dataGridView1.Refresh();

                                    InvoiceData();
                                    txtAddCompany.Text = "";
                                    txtAddFName.Text = "";
                                    txtAddContact.Text = "";
                                    txtAddEmail.Text = "";
                                    txtAddSecurityDeposit.Text = "";
                                    txtAddress.Text = "";
                                    txtArea.SelectedIndex = -1;
                                    cmbEmployee.SelectedIndex = -1;
                                    cmbCustType.SelectedIndex = 0;
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Enter Correct Data!");
                            }
                        }
                    }
                }
                else
                {
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //string CustomerID;
                    //int PackageID;
                    //string DealDate;
                    try
                    {
                        using (SqlConnection con5 = new SqlConnection(gr))
                        {
                            SqlCommand cmd5 = new SqlCommand("SELECT Package_ID,Quantity,Rate,ExpiryDays FROM PackageDetail WHERE PackageName = '" + cmbPackage.SelectedItem.ToString() + "'", con5);
                            con5.Open();
                            cmd5.ExecuteNonQuery();
                            SqlDataReader rdr1 = cmd5.ExecuteReader();
                            if (rdr1.HasRows)
                            {
                                while (rdr1.Read())
                                {
                                    qty = Convert.ToInt32(rdr1["Quantity"]);
                                    expirydays = Convert.ToInt32(rdr1["ExpiryDays"].ToString());
                                    pacID = Convert.ToInt32(rdr1["Package_ID"]);
                                    rate = Convert.ToInt32(rdr1["Rate"]);
                                }
                                // MessageBox.Show("package id selected");
                                rdr1.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to: " + ex.ToString());
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                    try
                    {
                        //conn.Open();
                        CustomerID = txtAddCust_ID.Text.Trim().ToString();
                        string Company = txtAddCompany.Text.Trim().ToString();
                        string CustomerName = txtAddFName.Text.Trim().ToString();
                        string ContactNo = txtAddContact.Text.Trim().ToString();
                        string Email = txtAddEmail.Text.Trim().ToString();
                        string CustomerType = cmbCustType.SelectedItem.ToString();
                        string Address = txtAddress.Text.ToString();
                        DealDate = dateTimePicker1.Text.ToString();
                        PackageID = pacID;                                         // some thing wrong
                        string Package = cmbPackage.SelectedItem.ToString();
                        string area = txtArea.SelectedItem.ToString();
                        string dealingemployee = cmbEmployee.SelectedItem.ToString();
                        string SecurityDeposit = txtAddSecurityDeposit.Text.ToString();
                        using (SqlConnection con2 = new SqlConnection(gr))
                        {
                            SqlCommand cmdd = new SqlCommand("INSERT INTO CustomerDetails(Cust_ID,ContactNO,Cust_Name,Cust_Type,Email,Address,Company,Package,DealStartDate,Area,DealingEmployee,SecurityDeposit)VALUES('" + CustomerID + "','" + ContactNo + "','" + CustomerName + "','" + CustomerType + "','" + Email + "','" + Address + "','" + Company + "','" + Package + "','" + DealDate + "','" + area + "','" + dealingemployee + "','" + SecurityDeposit + "')", con2);
                            con2.Open();
                            cmdd.ExecuteNonQuery();
                            MessageBox.Show("Dealed Customer Added!", "JalPak");

                            EmployeeCreationBonus(); // fucnction to calculate the employee bonus on new customer creation

                            customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                            dataGridView1.Invalidate();
                            dataGridView1.Refresh();

                            InvoiceData();
                            txtAddCompany.Text = "";
                            txtAddFName.Text = "";
                            txtAddContact.Text = "";
                            txtAddEmail.Text = "";
                            txtAddSecurityDeposit.Text = "";
                            txtAddress.Text = "";
                            txtArea.SelectedIndex = -1;
                            cmbEmployee.SelectedIndex = -1;
                            cmbCustType.SelectedIndex = 0;
                        }
                        try
                        {
                            ///////////////////insert into temporary table for data manipulation/////////////////////////////////////////
                            using (SqlConnection con3 = new SqlConnection(gr))
                            {
                                SqlCommand cmd3 = new SqlCommand("INSERT INTO Customer_Package(Cust_ID,Package_ID,BottlesAllowed,DateDeal,Rate,DateExpire)VALUES('" + CustomerID + "','" + PackageID + "','" + qty + "','" + DealDate + "','" + rate + "','" + expirydays + "')", con3);
                                con3.Open();
                                cmd3.ExecuteNonQuery();
                                // MessageBox.Show("Customer_Package Added to Table ...!");
                            }
                            ////////////////////////////////////////////////
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show("Failed due to : " + exx.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                    finally
                    {
                        //conn.Close();
                        //rdr.Close();
                    }
                }
            }
        }

        private void InvoiceData()
        {
            try
            {                                
            
            using (SqlConnection conn = new SqlConnection(gr))
            {
                SqlCommand cmd = new SqlCommand("Select Max(Cust_ID)+1 from CustomerDetails ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        txtAddCust_ID.Text = rdr[0].ToString();
                        //rdr.Close();
                    }
                    else
                    {
                        txtAddCust_ID.Text = "1";
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
             
        private void cmbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCustType.SelectedIndex==0)
            {
                //cmbPackage.SelectedIndex = 0;  
                txtAddSecurityDeposit.Enabled = true;
                cmbPackage.Enabled = false;
                cmbPackage.SelectedIndex = 0;
            }
            else
            {
               // txtAddSecurityDeposit.Enabled = false;
                //cmbPackage.SelectedIndex = 1;
                cmbPackage.Enabled = true;
            }
        }

       // string oldText1 = string.Empty;                     
        string oldText3 = string.Empty;
        private void txtAddContact_TextChanged(object sender, EventArgs e)
        {
            if (txtAddContact.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtAddContact.Text;
                txtAddContact.Text = oldText3;

                txtAddContact.BackColor = System.Drawing.Color.White;
                txtAddContact.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtAddContact.Text = oldText3;
                txtAddContact.BackColor = System.Drawing.Color.Red;
                txtAddContact.ForeColor = System.Drawing.Color.White;
            }
            txtAddContact.SelectionStart = txtAddContact.Text.Length;
        }

        private void txtAddEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtAddEmail.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtAddEmail.Text))

                {
                    txtAddEmail.BackColor = System.Drawing.Color.Red;
                    txtAddEmail.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtAddEmail.SelectAll();

                    e.Cancel = true;

                }
                else
                {
                    txtAddEmail.BackColor = System.Drawing.Color.White;
                    txtAddEmail.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustType.SelectedIndex == 0)
            {
                cmbPackage.SelectedText="No Deal";
            }
            else 
            {
                cmbCustType.SelectedIndex = 1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con1 = new SqlConnection(gr))
            //{
            //    SqlCommand cmd = new SqlCommand(" SELECT [Cust_ID], [Cust_Type], [Company], [Cust_Name], [ContactNO], [Email], [Address] FROM CustomerDetails WHERE Cust_Name LIKE '" + txtSearchCust.Text.ToString().Trim() + "%'", con1);
            //    con1.Open();
            //    cmd.ExecuteNonQuery();

            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.HasRows)
            //    {
                    
            //        while (rdr.Read())
            //        {
                        //txtAddCust_ID.Text = (rdr["Cust_ID"].ToString());
                        //cmbCustType.SelectedItem = (rdr["Cust_Type"].ToString());
                        //txtAddCompany.Text = (rdr["Company"].ToString());
                        //txtAddFName.Text = (rdr["Cust_Name"].ToString());
                        //txtAddContact.Text = (rdr["ContactNO"].ToString());
                        //txtAddEmail.Text = (rdr["Email"].ToString());
                        //txtAddress.Text = (rdr["Address"].ToString());
                        ////  cmbDeprtName.Enabled = false;                       
                        //// txtbxTempDepartment.Visible = true;
                        try
                        {

                            SqlConnection con = new SqlConnection(gr);//connection name

                            con.Open();

                            SqlCommand cmdh = new SqlCommand(" SELECT * FROM CustomerDetails WHERE Cust_Name LIKE '" + txtSearchCust.Text.ToString().Trim() + "%'" , con);

                            cmdh.CommandType = CommandType.Text;

                            SqlDataAdapter da = new SqlDataAdapter(cmdh);

                            DataSet ds = new DataSet();

                            da.Fill(ds, "ss");

                            dataGridView1.DataSource = ds.Tables["ss"]; ;

                            // dataGridView1.DataBind();
                            

                        }

                        catch
                        {

                            MessageBox.Show("No Record Found");

                        }

                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Record Not Found!","JalPak");
                //}
           // }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InvoiceData();            
            txtAddCompany.Text = "";
            txtAddFName.Text = "";
            txtAddContact.Text = "";
            txtAddEmail.Text = "";
            txtAddSecurityDeposit.Text = "";
            txtAddress.Text = "";
            txtSearchCust.Text = "";
            txtArea.SelectedIndex=-1;
            cmbEmployee.SelectedIndex = -1;
            cmbCustType.SelectedIndex = 0;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (txtAddCompany.Text == "" && txtAddContact.Text == "" && txtAddEmail.Text == "" && txtAddFName.Text == "" && txtArea.SelectedIndex == -1 && cmbEmployee.SelectedIndex == -1 && txtAddress.Text == "" && txtAddSecurityDeposit.Text == "")
            //{
            //    MessageBox.Show("Some Fields Are Missing!","Jalpak");
            //}
            if (txtAddCompany.Text == "")
            {
                MessageBox.Show("Enter company name", "JalPak");
            }
            else if (txtAddContact.Text == "")
            {
                MessageBox.Show("Enter contact no", "JalPak");
            }         
            else if (txtAddFName.Text == "")
            {
                MessageBox.Show("Enter name", "JalPak");
            }
            else if (txtArea.SelectedIndex == -1)
            {
                MessageBox.Show("Select are from the list", "JalPak");
            }
            else if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Select employee from the list", "JalPak");
            }
            else if (cmbCustType.SelectedIndex == -1)
            {
                MessageBox.Show("Select customer from the list", "JalPak");
            }
            else if (txtAddSecurityDeposit.Text == "")
            {
                MessageBox.Show("Enter security deposit", "JalPak");
            }
            else
            {
            if (cmbCustType.SelectedIndex == 0)      /////// select customer type
            {
                using (SqlConnection con44 = new SqlConnection(gr))
                {
                    
                    SqlCommand cmd2 = new SqlCommand("UPDATE CustomerDetails SET Cust_ID='" + txtAddCust_ID.Text.Trim() + "',Cust_Type='" + cmbCustType.SelectedItem.ToString() + "', Company='" + txtAddCompany.Text.Trim() + "', Cust_Name='" + txtAddFName.Text.Trim() + "', ContactNO='" + txtAddContact.Text.Trim() + "', Email='" + txtAddEmail.Text.Trim() + "', Address='" + txtAddress.Text.Trim() + "', Package='" + cmbPackage.SelectedItem.ToString() + "', SecurityDeposit='" + txtAddSecurityDeposit.Text.Trim() + "', Area='" + txtArea.SelectedItem.ToString() + "', DealingEmployee='" + cmbEmployee.SelectedItem.ToString() + "', DealStartDate='" + dateTimePicker1.Text.Trim() + "' where Cust_ID='" + txtAddCust_ID.Text + "'", con44);
                    //////////////////////////////////// Select customer id from customer package to delete it, if customer type change deal to regular //////////////////////////////////////////////////////////////////////
                    SqlCommand cmd20 = new SqlCommand("SELECT * from Customer_Package where Cust_ID='" + txtAddCust_ID.Text + "'", con44);
                    con44.Open();
                    cmd2.ExecuteNonQuery();

                    EmployeeCreationBonus(); // fucnction to calculate the employee bonus on new customer creation
                    
                    cmd20.ExecuteNonQuery();
                    SqlDataReader rdr20 = cmd20.ExecuteReader();
                    if (rdr20.HasRows)
                    {
                        rdr20.Close();
                        
                        SqlCommand cmd211 = new SqlCommand("Delete from Customer_Package where Cust_ID='" + txtAddCust_ID.Text + "'", con44);
                        cmd211.ExecuteNonQuery();
                        MessageBox.Show("Customer Changed From Deal to Regular","JalPak");
                        //     refresh gridview
                        customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                        dataGridView1.Invalidate();
                        dataGridView1.Refresh();                        
                        ClearInput(); //  reset or clear all input field                       
                    }
                }
            }
            else
            {
               try
                {
                    using (SqlConnection con3 = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * from CustomerDetails where Cust_ID='" + txtAddCust_ID.Text + "'", con3);
                        con3.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Close();

                            using (SqlConnection con4 = new SqlConnection(gr))
                            {
                                SqlCommand cmd2 = new SqlCommand("UPDATE CustomerDetails SET Cust_ID='" + txtAddCust_ID.Text.Trim() + "',Cust_Type='" + cmbCustType.SelectedItem.ToString() + "', Company='" + txtAddCompany.Text.Trim() + "', Cust_Name='" + txtAddFName.Text.Trim() + "', ContactNO='" + txtAddContact.Text.Trim() + "', Email='" + txtAddEmail.Text.Trim() + "', Address='" + txtAddress.Text.Trim() + "', Package='" + cmbPackage.SelectedItem.ToString() + "', SecurityDeposit='" + txtAddSecurityDeposit.Text.Trim() + "', Area='" + txtArea.SelectedItem.ToString() + "', DealingEmployee='" + cmbEmployee.SelectedItem.ToString() + "', DealStartDate='" + dateTimePicker1.Text.Trim() + "' where Cust_ID='" + txtAddCust_ID.Text + "'", con4);
                                /////////////////////// Select customer detail ID from customer package for deal renew operation //////////////////////////////////////////////////////////////////////
                                SqlCommand cmd20 = new SqlCommand("SELECT * from Customer_Package where Cust_ID='" + txtAddCust_ID.Text + "'", con4);
                                con4.Open();
                                cmd2.ExecuteNonQuery();
                                
                                EmployeeCreationBonus(); // fucnction to calculate the employee bonus on new customer creation
                                
                                cmd20.ExecuteNonQuery();
                                SqlDataReader rdr20 = cmd20.ExecuteReader();
                                if (rdr20.HasRows)
                                {
                                    ///////////////////// This query fetch data from PackageDetails Table for updating customer package ////////////////////////////
                                    using (SqlConnection con5 = new SqlConnection(gr))
                                    {
                                        SqlCommand cmd5 = new SqlCommand("SELECT Package_ID,Quantity,Rate,ExpiryDays FROM PackageDetail WHERE PackageName = '" + cmbPackage.SelectedItem.ToString() + "'", con5);
                                        con5.Open();
                                        cmd5.ExecuteNonQuery();
                                        SqlDataReader rdr1 = cmd5.ExecuteReader();
                                        if (rdr1.HasRows)
                                        {
                                            while (rdr1.Read())
                                            {
                                                qty = Convert.ToInt32(rdr1["Quantity"]);
                                                expirydays = Convert.ToInt32(rdr1["ExpiryDays"].ToString());
                                                pacID = Convert.ToInt32(rdr1["Package_ID"]);
                                                rate = Convert.ToInt32(rdr1["Rate"]);
                                            }
                                            // MessageBox.Show("package id selected");
                                            rdr1.Close();
                                            //////////////////////////////////////////////////// This query update data in customer package Table or Renew deal ////////////////////////////////////////////////////////////                              
                                            bttleCnsmed = "0";
                                            SqlCommand cmd3 = new SqlCommand("UPDATE Customer_Package SET [Package_ID]='" + pacID + "',[BottlesAllowed]='" + qty + "',[DateDeal]='" + dateTimePicker1.Text.ToString() + "',[Rate]='" + rate + "',[BottleConsumed]='" + bttleCnsmed + "',[DateExpire]='" + expirydays + "' where Cust_ID='" + txtAddCust_ID.Text.Trim() + "'", con5);
                                            cmd3.ExecuteNonQuery();
                                            // rdr.Close();
                                            MessageBox.Show("Record Updated!", "JalPak");
                                            //////// refresh gridview
                                            customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                                            dataGridView1.Invalidate();
                                            dataGridView1.Refresh();

                                            ClearInput(); //  reset or clear all input fields

                                        }
                                    }
                                }
                                else
                                {
                                    // MessageBox.Show("This is else of customer package update if customer id not found in table!");
                                    ////////////////////////////////////// select data from package detail////////////////////
                                    using (SqlConnection con5 = new SqlConnection(gr))
                                    {
                                        SqlCommand cmd5 = new SqlCommand("SELECT Package_ID,Quantity,Rate,ExpiryDays FROM PackageDetail WHERE PackageName = '" + cmbPackage.SelectedItem.ToString() + "'", con5);
                                        con5.Open();
                                        cmd5.ExecuteNonQuery();
                                        SqlDataReader rdr1 = cmd5.ExecuteReader();
                                        if (rdr1.HasRows)
                                        {
                                            while (rdr1.Read())
                                            {
                                                qty = Convert.ToInt32(rdr1["Quantity"]);
                                                expirydays = Convert.ToInt32(rdr1["ExpiryDays"].ToString());
                                                pacID = Convert.ToInt32(rdr1["Package_ID"]);
                                                rate = Convert.ToInt32(rdr1["Rate"]);

                                            }
                                            // MessageBox.Show("package id selected");
                                            rdr1.Close();
                                        }

                                    }
                                    ////////////////////////////////// Insert package data if customer deal update/////////////////////////////
                                    using (SqlConnection conn = new SqlConnection(gr))
                                    {
                                        SqlCommand cmdd = new SqlCommand("INSERT INTO Customer_Package(Cust_ID,Package_ID,BottlesAllowed,DateDeal,Rate,DateExpire)VALUES('" + txtAddCust_ID.Text.Trim() + "','" + pacID + "','" + qty + "','" + dateTimePicker1.Text + "','" + rate + "','" + expirydays + "')", conn);
                                        conn.Open();
                                        cmdd.ExecuteNonQuery();
                                        MessageBox.Show("Customer Changed to Dealed!", "JalPak");
                                    }
                                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                                }
                                customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                                dataGridView1.Invalidate();
                                dataGridView1.Refresh();

                                InvoiceData();
                                txtAddCompany.Text = "";
                                txtAddFName.Text = "";
                                txtAddContact.Text = "";
                                txtAddEmail.Text = "";
                                txtAddSecurityDeposit.Text = "";
                                txtAddress.Text = "";
                                txtSearchCust.Text = "";
                                txtArea.SelectedIndex=-1;
                                cmbEmployee.SelectedIndex = -1;
                                cmbCustType.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.ToString());
                }
            }
        }
            customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
            dataGridView1.Invalidate();
            dataGridView1.Refresh();
            MessageBox.Show("Record Updated","JalPak");
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
                        txtSearchCust.Text = "";
                        this.btnSearch.PerformClick();
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
            customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
            dataGridView1.Invalidate();
            dataGridView1.Refresh();           
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
                   
                    SqlCommand cmd8 = new SqlCommand("DELETE FROM CustomerDetails WHERE Cust_ID = '" + code + "'", con8);
                    con8.Open();
                    cmd8.ExecuteNonQuery();
                    

                    // rdr.Close();
                    MessageBox.Show("Record Deleted!", "JalPak");

                    customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
                    dataGridView1.Invalidate();
                    dataGridView1.Refresh();                                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row;
                row = this.dataGridView1.Rows[e.RowIndex];
                txtAddCust_ID.Text = row.Cells["Cust_ID"].Value.ToString();
                cmbCustType.Text = row.Cells["Cust_Type"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DealStartDate"].Value.ToString();
                txtAddCompany.Text = row.Cells["Company"].Value.ToString();
                txtArea.Text = row.Cells["Area"].Value.ToString();
                cmbEmployee.Text = row.Cells["DealingEmployee"].Value.ToString();
                txtAddFName.Text = row.Cells["Cust_Name"].Value.ToString();
                txtAddContact.Text = row.Cells["ContactNO"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtAddEmail.Text = row.Cells["Email"].Value.ToString();
                cmbPackage.Text = row.Cells["Package"].Value.ToString();
                txtAddSecurityDeposit.Text = row.Cells["SecurityDeposit"].Value.ToString();
            }
        }
        
        
        
        //////////////////// This Function is used to Reset or Clear all input fields/////////////
        
        private void ClearInput()
        {
            InvoiceData();
            //customerDetailsTableAdapter.Fill(customerDetailsDataSet7.CustomerDetails);
            //dataGridView1.Invalidate();
            //dataGridView1.Refresh();
            txtAddCompany.Text = "";
            txtAddFName.Text = "";
            txtAddContact.Text = "";
            txtAddEmail.Text = "";
            txtAddSecurityDeposit.Text = "";
            txtAddress.Text = "";
            txtSearchCust.Text = "";
            txtArea.SelectedIndex=-1;
            cmbEmployee.SelectedIndex = -1;
            cmbCustType.SelectedIndex = 0;
        }


        // calculate bonus on new employee creation
        private void EmployeeCreationBonus()
        {
            // select employee id from Employee table                    
            try
            {
            using (SqlConnection con51 = new SqlConnection(gr))
            {
                SqlCommand cmd51 = new SqlCommand("SELECT Emp_ID FROM Employee WHERE Emp_Name = '" + cmbEmployee.SelectedItem.ToString() + "'", con51);
                con51.Open();
                cmd51.ExecuteNonQuery();
                SqlDataReader rdr51 = cmd51.ExecuteReader();
                if (rdr51.HasRows)
                {
                    while (rdr51.Read())
                    {
                        empID = Convert.ToInt32(rdr51["Emp_ID"]);
                    }
                   // MessageBox.Show("Employee id selected");
                    rdr51.Close();
                }
            }
             }
            catch(Exception exx)
            {
                MessageBox.Show("Failed due to : "+ exx.Message);
            }
            /////////////////////////////////////////////////////////////

            // Select Rs on new customer creation from commission table
            try
            {
            using (SqlConnection con52 = new SqlConnection(gr))
            {
                SqlCommand cmd52 = new SqlCommand("SELECT NewSale FROM Commission", con52);
                con52.Open();
                cmd52.ExecuteNonQuery();
                SqlDataReader rdr52 = cmd52.ExecuteReader();
                if (rdr52.HasRows)
                {
                    while (rdr52.Read())
                    {
                        rsOnNewSale = Convert.ToInt32(rdr52["NewSale"]);
                    }
                  //  MessageBox.Show("new sale value selected frm commission");
                    rdr52.Close();
                }
            }
             }
            catch(Exception exx)
            {
                MessageBox.Show("Failed due to : "+ exx.Message);
            }
            /////////////////////////////////////////////////////////////

            // Select new sale value from payroll table for addition
            try
            {
                using (SqlConnection con53 = new SqlConnection(gr))
                {
                    SqlCommand cmd53 = new SqlCommand("SELECT NewCust FROM PayRoll", con53);
                    con53.Open();
                    cmd53.ExecuteNonQuery();
                    SqlDataReader rdr53 = cmd53.ExecuteReader();
                    if (rdr53.HasRows)
                    {
                        while (rdr53.Read())
                        {
                            NewCreation = Convert.ToInt32(rdr53["NewCust"]);
                        }
                        //  MessageBox.Show("value selected frm payroll");
                        rdr53.Close();
                    }
                }
            }
            catch(Exception exx)
            {
                MessageBox.Show("Failed due to : "+ exx.Message);
            }
            /////////////////////////////////////////////////////////////

            // Update  payroll table : Rupees on new customer creation 
            int addition;   //  store addition of value on new customer creation 
            addition = NewCreation + rsOnNewSale;
            using (SqlConnection con54 = new SqlConnection(gr))
            {
                SqlCommand cmd54 = new SqlCommand("UPDATE PayRoll SET NewCust='" + addition + "' where Emp_ID='" + empID + "'", con54);
                con54.Open();
                cmd54.ExecuteNonQuery();
             //   MessageBox.Show("Commission Added to Employee", "JalPak");
            }
            /////////////////////////////////////////////////////////////
        }

       

       

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rAddress = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9., ]+$");

            if (txtAddress.Text.Length > 0)
            {

                if (!rAddress.IsMatch(txtAddress.Text))
                {
                    txtAddress.BackColor = System.Drawing.Color.Red;
                    txtAddress.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtAddress.SelectAll();

                    e.Cancel = true;

                }
                else
                {
                    txtAddress.BackColor = System.Drawing.Color.White;
                    txtAddress.ForeColor = System.Drawing.Color.Black;
                }
            }
        }


    }
}
