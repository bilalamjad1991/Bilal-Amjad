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

namespace SciTechManagement.Warehouse
{
    public partial class DeliveryCard : Form
    {
        string empType;
        string Dlvermonth;
        int empID;
        int NewSale;
          
        int count = 0;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public DeliveryCard()
        {
            InitializeComponent();
        }

        private void DeliveryCard_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////
            cmbCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            cmbCustomerName.AutoCompleteCustomSource = combData;
            //////////////////////////////////////////////////////
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM";

            Dlvermonth = dateTimePicker1.Text;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

            using (SqlConnection conn = new SqlConnection(gr))
            {
                //SqlCommand cmd = new SqlCommand("SELECT Emp_Name FROM Employee where Emp_Type='Commission' OR Emp_Type='Fixed Salary + Commission' ", conn);
                SqlCommand cmd = new SqlCommand("SELECT Emp_Name FROM Employee ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                       cmbEmployee.Items.Add(rdr[0]);
                    }
                }
            }                        
        }

        //////////////////////combo Box fetching data////////////////////////////////////////////
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            string sql = "SELECT DISTINCT [Cust_Name] FROM [CustomerDetails]";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////combo Box fetching data///////////////////////////////////////////////////

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBottlesDelivered.Text == string.Empty)
            {
                MessageBox.Show("Enter Delivered Quantity...!","JalPak");
                txtBottlesDelivered.BackColor = System.Drawing.Color.Red;
                txtBottlesDelivered.Focus();
            }
            else if (txtBottleReceived.Text == string.Empty)
            {

                MessageBox.Show("Enter Received Quantity...!","JalPak");
                txtBottleReceived.BackColor = System.Drawing.Color.Red;
                txtBottleReceived.Focus();
            }
            else if (txtAmountReceived.Text == string.Empty)
            {
                MessageBox.Show("Enter Received Amount...!","JalPak");
                txtAmountReceived.BackColor = System.Drawing.Color.Red;
                txtAmountReceived.Focus();
            }
            else if(txtRatePerBottle.Text=="")
            {
                MessageBox.Show("Enter Bottle Rate...!", "JalPak");
                txtRatePerBottle.BackColor = System.Drawing.Color.Red;
                txtRatePerBottle.Focus();
            }
            else if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Select an Employee!", "JalPak");
                cmbEmployee.Focus();
            }
            else
            {
                try
                {
                    using (SqlConnection con5 = new SqlConnection(gr))
                    {

                        //SqlCommand cmd2 = new SqlCommand("SELECT MAX(Quantity) FROM Items WHERE ItemName = '" + cmbOGPParticulars.SelectedItem.ToString() + "' ", con2);
                        SqlCommand cmd5 = new SqlCommand("SELECT Cust_ID,BottlesAllowed,BottleConsumed,DateDeal,DateExpire FROM Customer_Package WHERE Cust_ID = '" + txtCustomerNo.Text.Trim() + "'", con5);
                        con5.Open();
                        cmd5.ExecuteNonQuery();
                        SqlDataReader rdr5 = cmd5.ExecuteReader();
                        if (rdr5.HasRows)
                        {
                            while (rdr5.Read())
                            {
                                int AllowedBottles = Convert.ToInt32(rdr5["BottlesAllowed"].ToString());
                                int ConsumedBottles = Convert.ToInt32(rdr5["BottleConsumed"].ToString());
                                string DealDate = Convert.ToString(rdr5["DateDeal"].ToString());
                                int DBDaysToExpire = Convert.ToInt32(rdr5["DateExpire"].ToString());

                                ////////////////////////////////edited 19 Jan////////////////////////////////////////////
                                DateTime exp=Convert.ToDateTime(DealDate);

                                string expiryDate = Convert.ToString(exp.AddDays(DBDaysToExpire));
                              //  string expiryDate = Convert.ToString(dateTimePicker1.Value.AddDays(DBDaysToExpire));//edite 19 Jan
                              /////////////////////////////////////////////////////////////////////////////////////////

                               //19Jan MessageBox.Show(" Deal Expiry Date:  " + expiryDate,"JalPak");
                               // DateTime startDate = dateTimePicker1.Value;
                                DateTime expiry = Convert.ToDateTime(expiryDate); //deal expiry date
                                DateTime today = DateTime.Now;

                                int result = DateTime.Compare(today, expiry);
                                if (result < 0)
                                {
                                   

                                    if (ConsumedBottles < AllowedBottles)
                                    {
                                        try
                                        {
                                            MessageBox.Show("Deal Continues","JalPak");
                                            //int maxBtl=AllowedBottles-ConsumedBottles;
                                            //MessageBox.Show("MaximizeBox Available bottles:"+ maxBtl);
                                            //conn.Open();
                                            string CustomerID = txtCustomerNo.Text.Trim().ToString();
                                            string DeliverdDate = dateTimePicker1.Text;
                                            string BottleRate = txtRatePerBottle.Text.ToString();
                                            string DeliveryMonth = Dlvermonth;
                                            string BottlesDeliverd = Convert.ToString(Convert.ToInt32(txtBottlesDelivered.Text.Trim().ToString()) + ConsumedBottles);
                                            //string BottlesDeliverd = txtBottlesDelivered.Text.Trim().ToString();// addition perform   ConsumedBottles
                                            string BottleReceived = txtBottleReceived.Text.Trim();
                                            string RecievedAmount = txtAmountReceived.Text.ToString();
                                            string BalanceBottles = txtBalanceBottles.Text;
                                            string Amount = txtAmount.Text.ToString();
                                            string BalanceAmount = txtBalanceAmount.Text;

                                            using (SqlConnection conn = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("INSERT INTO DeliveryDetails(Cust_ID,Delivered_Date,Bottles_Delivered,Bottles_Rec,Balance_Bottle,Amount,Amount_Recieved,Deliverd_Month,Amount_Balance)VALUES('" + CustomerID + "','" + dateTimePicker1.Value + "','" + BottlesDeliverd + "','" + BottleReceived + "','" + BalanceBottles + "','" + Amount + "','" + RecievedAmount + "','" + DeliveryMonth + "','" + BalanceAmount + "')", conn);                                              
                                                SqlCommand cmd3 = new SqlCommand("UPDATE Customer_Package SET [BottleConsumed]='" + BottlesDeliverd + "' where Cust_ID='" + CustomerID + "'", conn);
                                                conn.Open();
                                                cmdd.ExecuteNonQuery();
                                                cmd3.ExecuteNonQuery();
                                                EmpSale(); // function used to add commission on new sale  into payroll table
                                               // MessageBox.Show("Record Saved...!");

                                                int RowIndex = 0;
                                                dataGridView1.Rows.Add();
                                                RowIndex = dataGridView1.Rows.Count - 2;

                                                // insert values from textboxes to DataGridView
                                                dataGridView1[0, RowIndex].Value = dateTimePicker1.Text;
                                                dataGridView1[1, RowIndex].Value = txtBottlesDelivered.Text;
                                                dataGridView1[2, RowIndex].Value = txtBottleReceived.Text;
                                                dataGridView1[3, RowIndex].Value = txtBalanceBottles.Text;
                                                dataGridView1[4, RowIndex].Value = txtAmount.Text;
                                                dataGridView1[5, RowIndex].Value = txtAmountReceived.Text;
                                                dataGridView1[6, RowIndex].Value = txtBalanceAmount.Text;
                                                dataGridView1.Refresh();

                                                txtBottlesDelivered.Text = "";
                                                txtBottleReceived.Text = "";
                                                txtBalanceAmount.Text = "";
                                                txtBalanceBottles.Text = "";
                                                txtAmount.Text = "";
                                                txtAmountReceived.Text = "";
                                                //count++;
                                                cmbCustomerName.Focus();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Failed due to : " + ex.Message);
                                        }
                                        finally
                                        {
                                            //conn.Close();
                                        }
                                    }
                                        //////////////////////////// bottles consumed code ////////////////////////////////////
                                    else
                                    {
                                          //19Jan     MessageBox.Show("Your Bottles has been Consumed and Deal has expired", "JalPak");
                                        try
                                        {
                                            txtRatePerBottle.Enabled = true;//edited 19 Jan

                                            string CustomerID = txtCustomerNo.Text.Trim();
                                            string DeliverdDate = dateTimePicker1.Text;
                                            string BottleRate = txtRatePerBottle.Text.ToString();
                                            string DeliveryMonth = Dlvermonth;
                                            string BottlesDeliverd = txtBottlesDelivered.Text.Trim().ToString();
                                            string BottleReceived = txtBottleReceived.Text.Trim();
                                            string RecievedAmount = txtAmountReceived.Text.ToString();
                                            string BalanceBottles = txtBalanceBottles.Text;
                                            string Amount = txtAmount.Text.ToString();
                                            string BalanceAmount = txtBalanceAmount.Text;

                                            using (SqlConnection conn = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("INSERT INTO DeliveryDetails(Cust_ID,Delivered_Date,Bottles_Delivered,Bottles_Rec,Balance_Bottle,Amount,Amount_Recieved,Deliverd_Month,Amount_Balance)VALUES('" + CustomerID + "','" + dateTimePicker1.Value + "','" + BottlesDeliverd + "','" + BottleReceived + "','" + BalanceBottles + "','" + Amount + "','" + RecievedAmount + "','" + DeliveryMonth + "','" + BalanceAmount + "')", conn);
                                               
                                                conn.Open();
                                                cmdd.ExecuteNonQuery();
                                                EmpSale(); // function used to add commission on new sale  into payroll table

                                              //  MessageBox.Show("Record Saved...!", "JalPak");

                                                int RowIndex = 0;
                                                dataGridView1.Rows.Add();
                                                RowIndex = dataGridView1.Rows.Count - 2;

                                                // insert values from textboxes to DataGridView
                                                dataGridView1[0, RowIndex].Value = dateTimePicker1.Text;
                                                dataGridView1[1, RowIndex].Value = txtBottlesDelivered.Text;
                                                dataGridView1[2, RowIndex].Value = txtBottleReceived.Text;
                                                dataGridView1[3, RowIndex].Value = txtBalanceBottles.Text;
                                                dataGridView1[4, RowIndex].Value = txtAmount.Text;
                                                dataGridView1[5, RowIndex].Value = txtAmountReceived.Text;
                                                dataGridView1[6, RowIndex].Value = txtBalanceAmount.Text;
                                                dataGridView1.Refresh();

                                                txtBottlesDelivered.Text = "";
                                                txtBottleReceived.Text = "";
                                                txtBalanceAmount.Text = "";
                                                txtBalanceBottles.Text = "";
                                                txtAmount.Text = "";
                                                txtAmountReceived.Text = "";
                                                //count++;
                                                //cmbCustomerName.Focus();//19jan
                                                txtRatePerBottle.Focus();//19jan
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
                                        }
                                    }
                                }
                                else if (result == 0)
                                {
                                   // MessageBox.Show("Deal has Expired Buy or Renew a Deal!", "JalPak");
                                    //19Jan MessageBox.Show("Deal has Expired.Buy At Specified Rate!", "JalPak");
                                    try
                                    {

                                        string CustomerID = txtCustomerNo.Text.Trim();
                                        string DeliverdDate = dateTimePicker1.Text;
                                        string BottleRate = txtRatePerBottle.Text.ToString();
                                        string DeliveryMonth = Dlvermonth;
                                        string BottlesDeliverd = txtBottlesDelivered.Text.Trim().ToString();
                                        string BottleReceived = txtBottleReceived.Text.Trim();
                                        string RecievedAmount = txtAmountReceived.Text.ToString();
                                        string BalanceBottles = txtBalanceBottles.Text;
                                        string Amount = txtAmount.Text.ToString();
                                        string BalanceAmount = txtBalanceAmount.Text;

                                        using (SqlConnection conn = new SqlConnection(gr))
                                        {

                                            SqlCommand cmdd = new SqlCommand("INSERT INTO DeliveryDetails(Cust_ID,Delivered_Date,Bottles_Delivered,Bottles_Rec,Balance_Bottle,Amount,Amount_Recieved,Deliverd_Month,Amount_Balance)VALUES('" + CustomerID + "','" + dateTimePicker1.Value + "','" + BottlesDeliverd + "','" + BottleReceived + "','" + BalanceBottles + "','" + Amount + "','" + RecievedAmount + "','" + DeliveryMonth + "','" + BalanceAmount + "')", conn);

                                            conn.Open();
                                            cmdd.ExecuteNonQuery();
                                            EmpSale(); // function used to add commission on new sale  into payroll table

                                            //  MessageBox.Show("Record Saved...!", "JalPak");

                                            int RowIndex = 0;
                                            dataGridView1.Rows.Add();
                                            RowIndex = dataGridView1.Rows.Count - 2;

                                            // insert values from textboxes to DataGridView
                                            dataGridView1[0, RowIndex].Value = dateTimePicker1.Text;
                                            dataGridView1[1, RowIndex].Value = txtBottlesDelivered.Text;
                                            dataGridView1[2, RowIndex].Value = txtBottleReceived.Text;
                                            dataGridView1[3, RowIndex].Value = txtBalanceBottles.Text;
                                            dataGridView1[4, RowIndex].Value = txtAmount.Text;
                                            dataGridView1[5, RowIndex].Value = txtAmountReceived.Text;
                                            dataGridView1[6, RowIndex].Value = txtBalanceAmount.Text;
                                            dataGridView1.Refresh();

                                            txtBottlesDelivered.Text = "";
                                            txtBottleReceived.Text = "";
                                            txtBalanceAmount.Text = "";
                                            txtBalanceBottles.Text = "";
                                            txtAmount.Text = "";
                                            txtAmountReceived.Text = "";
                                            //count++;
                                            cmbCustomerName.Focus();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
                                    }
                                }
                                else
                                {
                                    //MessageBox.Show("Deal has Expired Buy or Renew a Deal!", "JalPak");
                                    //19Jan  MessageBox.Show("Deal has Expired.Buy At Specified Rate!", "JalPak");
                                    try
                                    {

                                        string CustomerID = txtCustomerNo.Text.Trim();
                                        string DeliverdDate = dateTimePicker1.Text;
                                        string BottleRate = txtRatePerBottle.Text.ToString();
                                        string DeliveryMonth = Dlvermonth;
                                        string BottlesDeliverd = txtBottlesDelivered.Text.Trim().ToString();
                                        string BottleReceived = txtBottleReceived.Text.Trim();
                                        string RecievedAmount = txtAmountReceived.Text.ToString();
                                        string BalanceBottles = txtBalanceBottles.Text;
                                        string Amount = txtAmount.Text.ToString();
                                        string BalanceAmount = txtBalanceAmount.Text;

                                        using (SqlConnection conn = new SqlConnection(gr))
                                        {

                                            SqlCommand cmdd = new SqlCommand("INSERT INTO DeliveryDetails(Cust_ID,Delivered_Date,Bottles_Delivered,Bottles_Rec,Balance_Bottle,Amount,Amount_Recieved,Deliverd_Month,Amount_Balance)VALUES('" + CustomerID + "','" + dateTimePicker1.Value + "','" + BottlesDeliverd + "','" + BottleReceived + "','" + BalanceBottles + "','" + Amount + "','" + RecievedAmount + "','" + DeliveryMonth + "','" + BalanceAmount + "')", conn);

                                            conn.Open();
                                            cmdd.ExecuteNonQuery();
                                            EmpSale(); // function used to add commission on new sale  into payroll table

                                            //  MessageBox.Show("Record Saved...!", "JalPak");

                                            int RowIndex = 0;
                                            dataGridView1.Rows.Add();
                                            RowIndex = dataGridView1.Rows.Count - 2;

                                            // insert values from textboxes to DataGridView
                                            dataGridView1[0, RowIndex].Value = dateTimePicker1.Text;
                                            dataGridView1[1, RowIndex].Value = txtBottlesDelivered.Text;
                                            dataGridView1[2, RowIndex].Value = txtBottleReceived.Text;
                                            dataGridView1[3, RowIndex].Value = txtBalanceBottles.Text;
                                            dataGridView1[4, RowIndex].Value = txtAmount.Text;
                                            dataGridView1[5, RowIndex].Value = txtAmountReceived.Text;
                                            dataGridView1[6, RowIndex].Value = txtBalanceAmount.Text;
                                            dataGridView1.Refresh();

                                            txtBottlesDelivered.Text = "";
                                            txtBottleReceived.Text = "";
                                            txtBalanceAmount.Text = "";
                                            txtBalanceBottles.Text = "";
                                            txtAmount.Text = "";
                                            txtAmountReceived.Text = "";
                                            //count++;
                                            cmbCustomerName.Focus();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Failed due to : " + ex.Message, "JalPak");
                                    }
                                }
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Customer not in Deal.","JalPak");
                             
                                    //if (count == 1)
                                    //{
                                        try
                                        {
                                            //conn.Open();
                                            string CustomerID = txtCustomerNo.Text.Trim();
                                            string DeliverdDate = dateTimePicker1.Text;
                                            string BottleRate = txtRatePerBottle.Text.ToString();
                                            string DeliveryMonth = Dlvermonth;
                                            string BottlesDeliverd = txtBottlesDelivered.Text.Trim().ToString();
                                            string BottleReceived = txtBottleReceived.Text.Trim();
                                            string RecievedAmount = txtAmountReceived.Text.ToString();
                                            string BalanceBottles = txtBalanceBottles.Text;
                                            string Amount = txtAmount.Text.ToString();
                                            string BalanceAmount = txtBalanceAmount.Text;

                                            using (SqlConnection conn = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("INSERT INTO DeliveryDetails(Cust_ID,Delivered_Date,Bottles_Delivered,Bottles_Rec,Balance_Bottle,Amount,Amount_Recieved,Deliverd_Month,Amount_Balance)VALUES('" + CustomerID + "','" + dateTimePicker1.Value + "','" + BottlesDeliverd + "','" + BottleReceived + "','" + BalanceBottles + "','" + Amount + "','" + RecievedAmount + "','" + DeliveryMonth + "','" + BalanceAmount + "')", conn); 
                                               // SqlCommand cmd3 = new SqlCommand("UPDATE Customer_Package SET [BottleConsumed]='"  + Bottles_Delivered + "where Cust_ID='" + CustomerID + "'", conn);
                                                conn.Open();
                                                cmdd.ExecuteNonQuery();
                                                EmpSale(); // function used to add commission on new sale  into payroll table
                                                
                                             //   MessageBox.Show("Record Saved...!","JalPak");

                                                int RowIndex = 0;
                                                dataGridView1.Rows.Add();
                                                RowIndex = dataGridView1.Rows.Count - 2;

                                                // insert values from textboxes to DataGridView
                                                dataGridView1[0, RowIndex].Value = dateTimePicker1.Text;
                                                dataGridView1[1, RowIndex].Value = txtBottlesDelivered.Text;
                                                dataGridView1[2, RowIndex].Value = txtBottleReceived.Text;
                                                dataGridView1[3, RowIndex].Value = txtBalanceBottles.Text;
                                                dataGridView1[4, RowIndex].Value = txtAmount.Text;
                                                dataGridView1[5, RowIndex].Value = txtAmountReceived.Text;
                                                dataGridView1[6, RowIndex].Value = txtBalanceAmount.Text;
                                                dataGridView1.Refresh();

                                                txtBottlesDelivered.Text = "";
                                                txtBottleReceived.Text = "";
                                                txtBalanceAmount.Text = "";
                                                txtBalanceBottles.Text = "";
                                                txtAmount.Text = "";
                                                txtAmountReceived.Text = "";
                                                //count++;
                                                cmbCustomerName.Focus();
                                            }
                                        }
                                        catch(Exception ex)
                                        {
                                            MessageBox.Show("Failed due to : " + ex.Message,"JalPak");
                                        }
                                   // }
                                   // count = 1;                                
                        }
                    }     
                }
                catch(Exception exx)
                    {
                        MessageBox.Show("Failed due to : " + exx.Message ,"JalPak");
                    }                                
            }
        }     
        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(gr))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT Cust_ID,ContactNO,Address FROM CustomerDetails WHERE Cust_Name LIKE '" + cmbCustomerName.SelectedItem.ToString() + "%'", conn);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    if (rdr.HasRows)
            //    {
            //        while (rdr.Read())
            //        {
            //            txtCustomerNo.Text = (rdr["Cust_ID"].ToString());
            //            // txtRatePerBottle.Text = (rdr["Bottle_Rate"].ToString());
            //            txtCustomerContactNo.Text = (rdr["ContactNO"].ToString());
            //            txtCustomerAddress.Text = (rdr["Address"].ToString());
            //        }
            //    }
            //}                              
       }
        int btlallw;
        int maxBttle;
        int btlcnsm;
        
        private void txtBottlesDelivered_Leave(object sender, EventArgs e)
        {
            if (txtBottlesDelivered.Text == "")
            {
               
            }
            else
            {


                ///////////////////////////////////////////////edit 19 Jan///////////////////////////////////////////
                try
                {
                    using (SqlConnection con5 = new SqlConnection(gr))
                    {


                        SqlCommand cmd5 = new SqlCommand("SELECT * FROM Customer_Package WHERE Cust_ID = '" + txtCustomerNo.Text.Trim() + "'", con5);
                        con5.Open();
                        cmd5.ExecuteNonQuery();
                        SqlDataReader rdr5 = cmd5.ExecuteReader();
                        if (rdr5.HasRows)
                        {
                            while (rdr5.Read())
                            {
                                //int AllowedBottles = Convert.ToInt32(rdr5["BottlesAllowed"].ToString());
                                //int ConsumedBottles = Convert.ToInt32(rdr5["BottleConsumed"].ToString());
                                string DealDate = Convert.ToString(rdr5["DateDeal"].ToString());
                                int DBDaysToExpire = Convert.ToInt32(rdr5["DateExpire"].ToString());

                                ////////////////////////////////edited 19 Jan////////////////////////////////////////////
                                DateTime exp = Convert.ToDateTime(DealDate);

                                string expiryDate = Convert.ToString(exp.AddDays(DBDaysToExpire));

                                /////////////////////////////////////////////////////////////////////////////////////////

                                MessageBox.Show(" Deal Expiry Date:  " + expiryDate, "JalPak");

                                DateTime expiry = Convert.ToDateTime(expiryDate); //deal expiry date
                                DateTime today = DateTime.Now;

                                int result = DateTime.Compare(today, expiry);
                                if (result < 0)
                                {
                                    using (SqlConnection con6 = new SqlConnection(gr))
                                    {

                                        SqlCommand cmd6 = new SqlCommand("SELECT Cust_ID,BottlesAllowed,BottleConsumed FROM Customer_Package WHERE Cust_ID = '" + txtCustomerNo.Text.Trim() + "'", con6);
                                        con6.Open();
                                        cmd6.ExecuteNonQuery();
                                        SqlDataReader rdr6 = cmd6.ExecuteReader();
                                        if (rdr6.HasRows)
                                        {
                                            while (rdr6.Read())
                                            {
                                                btlallw = Convert.ToInt32(rdr6["BottlesAllowed"]);
                                                btlcnsm = Convert.ToInt32(rdr6["BottleConsumed"]);
                                                maxBttle = btlallw - btlcnsm;

                                            }
                                            int bttlDlvrd = Convert.ToInt32(txtBottlesDelivered.Text);
                                            string mxBttle;
                                            ////////////   if bottles allowed and consumed equals than allow to continue to sell as regular///////////////
                                            if (btlallw == btlcnsm)
                                            {
                                                mxBttle = Convert.ToString(maxBttle);
                                                MessageBox.Show("Max Available Bottles Are: " + mxBttle, "JalPak");
                                                MessageBox.Show("Your Bottles has been Consumed and Deal has expired", "JalPak");//edit 19 jan
                                                txtRatePerBottle.Enabled = true;//edit 19 jan

                                            }
                                            else
                                            {
                                                if (bttlDlvrd > maxBttle)
                                                {
                                                    mxBttle = Convert.ToString(maxBttle);
                                                    MessageBox.Show("Max Available Bottles Are: " + mxBttle, "JalPak");
                                                    txtBottlesDelivered.Focus();
                                                }
                                            }
                                        }//if rdr has rows
                                        else
                                        {
                                            // txtRatePerBottle.Text = "";
                                        }
                                        //int bttlDlvrd=Convert.ToInt32(txtBottlesDelivered.Text);
                                        //if (bttlDlvrd>maxBttle)
                                        //{
                                        //    string mxBttle = Convert.ToString(maxBttle);
                                        //    txtBottlesDelivered.Focus();
                                        //    MessageBox.Show("Max Available Bottles Are: " + mxBttle,"JalPak");
                                        //}

                                    }//using stmnt
                                }
                                else if (result == 0)
                                {
                                    MessageBox.Show("Deal Has Expired.Sale At Specified Rate!");
                                    txtRatePerBottle.Enabled = true;
                                }
                                else 
                                {

                                    MessageBox.Show("Deal Has Expired.Sale At Specified Rate!");
                                    txtRatePerBottle.Enabled = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to:"+ex);
                }
                      


                
                /////////////////////////////////////////////////////19 Jan/////////////////////////////////////////////////

                /////////////////////////////////////////////////////19 Jan/////////////////////////////////////////////////

                //using (SqlConnection con6 = new SqlConnection(gr))
                //{
                    
                //    SqlCommand cmd6 = new SqlCommand("SELECT Cust_ID,BottlesAllowed,BottleConsumed FROM Customer_Package WHERE Cust_ID = '" + txtCustomerNo.Text.Trim() + "'", con6);
                //    con6.Open();
                //    cmd6.ExecuteNonQuery();
                //    SqlDataReader rdr6 = cmd6.ExecuteReader();
                //    if (rdr6.HasRows)
                //    {
                //        while (rdr6.Read())
                //        {
                //             btlallw = Convert.ToInt32(rdr6["BottlesAllowed"]);
                //             btlcnsm = Convert.ToInt32(rdr6["BottleConsumed"]);
                //            maxBttle = btlallw - btlcnsm;

                //        }
                //        int bttlDlvrd = Convert.ToInt32(txtBottlesDelivered.Text);
                //        string mxBttle;
                //        ////////////   if bottles allowed and consumed equals than allow to continue to sell as regular///////////////
                //        if (btlallw == btlcnsm)
                //        {
                //            mxBttle = Convert.ToString(maxBttle);
                //            MessageBox.Show("Max Available Bottles Are: " + mxBttle, "JalPak");
                //            txtRatePerBottle.Enabled = true;//edit 19 jan
                           
                //        }
                //        else
                //        {
                //        if (bttlDlvrd > maxBttle)
                //        {
                //            mxBttle = Convert.ToString(maxBttle);                          
                //            MessageBox.Show("Max Available Bottles Are: " + mxBttle, "JalPak");
                //            txtBottlesDelivered.Focus();                           
                //        }
                //        }                        
                //    }//if rdr has rows
                //    else
                //    {
                //       // txtRatePerBottle.Text = "";
                //    }
                //    //int bttlDlvrd=Convert.ToInt32(txtBottlesDelivered.Text);
                //    //if (bttlDlvrd>maxBttle)
                //    //{
                //    //    string mxBttle = Convert.ToString(maxBttle);
                //    //    txtBottlesDelivered.Focus();
                //    //    MessageBox.Show("Max Available Bottles Are: " + mxBttle,"JalPak");
                //    //}
                   
                //}//using stmnt
                /////////////////////////////////////////////////////19 Jan/////////////////////////////////////////////////
                /////////////////////
                if (txtRatePerBottle.Text == "")
                {
                    MessageBox.Show("Enter the Bottle Rate", "JalPak");
                    txtRatePerBottle.Focus();
                    
                }
                else
                {
                    int rate = Convert.ToInt32(txtRatePerBottle.Text);
                    int qty = Convert.ToInt32(txtBottlesDelivered.Text);
                    int T_Amount = rate * qty;
                    txtAmount.Text = T_Amount.ToString();
                }                              
            }
            
        }

        private void txtAmountReceived_Leave(object sender, EventArgs e)
        {
            if (txtAmountReceived.Text == "")
            {
              
            }
            else
            {
                int recivedAmount = Convert.ToInt32(txtAmountReceived.Text);
                int Amount = Convert.ToInt32(txtAmount.Text);
                //int balanceAmount = recivedAmount - Amount;
                int balanceAmount = Amount - recivedAmount;
                if (balanceAmount < 0)
                {
                    //balanceAmount = balanceAmount * (-1);
                    txtBalanceAmount.Text = balanceAmount.ToString();
                }
                else
                {
                    txtBalanceAmount.Text = balanceAmount.ToString();
                }
                
            }
        }

        private void txtBalanceAmount_TextChanged(object sender, EventArgs e)
        {
            //if(txtBalanceAmount.Text.Length>=1)
            //{
            //    int temp = Convert.ToInt32(txtBalanceAmount.Text);
            //    if(temp>0)
            //    {
            //        txtBalanceAmount.Text = "";
            //       // MessageBox.Show("Full Amount Not Paid!");                    
            //    }
            //}
        }

        string oldText3 = string.Empty;
        string oldText4 = string.Empty;
        string oldText5 = string.Empty;
        private void txtBottlesDelivered_TextChanged(object sender, EventArgs e)
        {
            if (txtBottlesDelivered.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtBottlesDelivered.Text;
                txtBottlesDelivered.Text = oldText3;

                txtBottlesDelivered.BackColor = System.Drawing.Color.White;
                txtBottlesDelivered.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtBottlesDelivered.Text = oldText3;
                txtBottlesDelivered.BackColor = System.Drawing.Color.Red;
                txtBottlesDelivered.ForeColor = System.Drawing.Color.White;
            }
            txtBottlesDelivered.SelectionStart = txtBottlesDelivered.Text.Length;                        
        }

        private void txtBottleReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtBottleReceived.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtBottleReceived.Text;
                txtBottleReceived.Text = oldText4;

                txtBottleReceived.BackColor = System.Drawing.Color.White;
                txtBottleReceived.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtBottleReceived.Text = oldText4;
                txtBottleReceived.BackColor = System.Drawing.Color.Red;
                txtBottleReceived.ForeColor = System.Drawing.Color.White;
            }
            txtBottleReceived.SelectionStart = txtBottleReceived.Text.Length;
        }

        private void txtAmountReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountReceived.Text.All(chr => char.IsNumber(chr)))
            {
                oldText5 = txtAmountReceived.Text;
                txtAmountReceived.Text = oldText5;

                txtAmountReceived.BackColor = System.Drawing.Color.White;
                txtAmountReceived.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtAmountReceived.Text = oldText5;
                txtAmountReceived.BackColor = System.Drawing.Color.Red;
                txtAmountReceived.ForeColor = System.Drawing.Color.White;
            }
            txtAmountReceived.SelectionStart = txtAmountReceived.Text.Length;
        }

        string oldText7 = string.Empty;
        private void txtBalanceBottles_TextChanged(object sender, EventArgs e)
        {
            //if (txtBalanceBottles.Text.All(chr => char.IsNumber(chr)))
            //{
            //    oldText7 = txtBalanceBottles.Text;
            //    txtBalanceBottles.Text = oldText7;

            //    txtBalanceBottles.BackColor = System.Drawing.Color.White;
            //    txtBalanceBottles.ForeColor = System.Drawing.Color.Black;
            //}
            //else
            //{
            //    txtBalanceBottles.Text = oldText7;
            //    txtBalanceBottles.BackColor = System.Drawing.Color.Red;
            //    txtBalanceBottles.ForeColor = System.Drawing.Color.White;
            //}
            //txtBalanceBottles.SelectionStart = txtBalanceBottles.Text.Length;
        }

        private void txtBottleReceived_Leave(object sender, EventArgs e)
        {
            if (txtBottleReceived.Text == "")
            {
              
            }
            else
            {
                int receivedBottles = Convert.ToInt32(txtBottleReceived.Text);
                int deliveredBottles = Convert.ToInt32(txtBottlesDelivered.Text);
                //int balanceBottles = receivedBottles - deliveredBottles;
                int balanceBottles = deliveredBottles - receivedBottles;
                if (balanceBottles < 0)
                {
                    //balanceBottles = balanceBottles * (-1);
                    txtBalanceBottles.Text = balanceBottles.ToString();
                }
                else
                {
                    txtBalanceBottles.Text = balanceBottles.ToString();
                }

            }
        }

        string tempID;
        private void cmbCustomerName_Leave(object sender, EventArgs e)
        {
            if (cmbCustomerName.Text == "")
            {
                MessageBox.Show("Please Select a Customer Name");
                cmbCustomerName.Focus();
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Cust_ID,ContactNO,Address FROM CustomerDetails WHERE Cust_Name LIKE '" + cmbCustomerName.Text.ToString() + "%'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //if (rdr.Read())
                    //{
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                tempID = txtCustomerNo.Text = (rdr["Cust_ID"].ToString());
                                txtCustomerContactNo.Text = (rdr["ContactNO"].ToString());
                                txtCustomerAddress.Text = (rdr["Address"].ToString());

                                using (SqlConnection con7 = new SqlConnection(gr))
                                {
                                    SqlCommand cmd7 = new SqlCommand("SELECT Rate FROM Customer_Package WHERE Cust_ID = '" + tempID + "'", con7);
                                    con7.Open();
                                    cmd7.ExecuteNonQuery();
                                    SqlDataReader rdr7 = cmd7.ExecuteReader();
                                    if (rdr7.HasRows)
                                    {
                                        while (rdr7.Read())
                                        {
                                            string PackageRate = Convert.ToString(rdr7["Rate"].ToString());
                                            txtRatePerBottle.Text = PackageRate;
                                        }
                                    }
                                }
                            } 

                            ////////////////////////////////

                            using (SqlConnection con8 = new SqlConnection(gr))
                            {
                                SqlCommand cmd8 = new SqlCommand("SELECT * FROM Customer_Package WHERE Cust_ID = '" + txtCustomerNo.Text.ToString() + "'", con8);
                                con8.Open();
                                cmd8.ExecuteNonQuery();
                                SqlDataReader rdr8 = cmd8.ExecuteReader();
                                if (rdr8.HasRows)
                                {
                                    txtRatePerBottle.Enabled = false;

                                }
                                else 
                                {
                                    txtRatePerBottle.Enabled = true;                                
                                }
                            }                                                      
                        }
                        else
                        {
                            MessageBox.Show("Customer Does Not Exist","JalPak");  
                            txtCustomerNo.Text = "";
                            cmbCustomerName.Text = "";
                            txtCustomerContactNo.Text = "";
                            txtRatePerBottle.Text = "";
                            txtCustomerContactNo.Text = "";
                            txtCustomerAddress.Text = "";
                            cmbCustomerName.Focus();
                            //MessageBox.Show("Customer Does not exist");                                                     
                        }
                }
                

            }
            ///////////////////////////////////////////
            //if (cmbCustomerName.Text == "")
            //{
            //    MessageBox.Show("Please Select a Customer Name");
            //    cmbCustomerName.Focus();
            //}
            //else
            //{
            //    try
            //    {
            //        string connetionString = null;
            //        connetionString = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";



            //        using (SqlConnection con = new SqlConnection(connetionString))
            //        {
            //            SqlCommand cmd = new SqlCommand("SELECT * FROM CustomerDetails WHERE Cust_Name LIKE '" + cmbCustomerName.Text.ToString() + "%'", con);
            //            con.Open();

            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            if (rdr.Read())
            //            {

            //                MessageBox.Show("Customer exists");


            //                SqlConnection con2 = new SqlConnection(connetionString);
            //                SqlCommand cmd2 = new SqlCommand("SELECT Cust_ID,ContactNO,Address FROM CustomerDetails WHERE Cust_Name LIKE '" + cmbCustomerName.Text.ToString() + "%'", con2);

            //                con2.Open();
            //                SqlDataReader rdr2 = cmd2.ExecuteReader();
            //                if (rdr2.HasRows)
            //                {
            //                    while (rdr2.Read())
            //                    {
            //                        txtCustomerNo.Text = (rdr["Cust_ID"].ToString());

            //                    }
            //                    rdr2.Close();
            //                }

            //                con2.Close();


            //            }

            //            else
            //            {
            //                MessageBox.Show("Customer does not exists");


            //            }


            //        }    ///using end






            //    }     //// try
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //} 
        }

        public static string CustNo;
      
        public static string CustMonth;
        
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MMMM";
            //Dlvermonth = dateTimePicker1.Text;



            ////////////////
            CustNo = txtCustomerNo.Text;
        
            CustMonth = Dlvermonth;
           

            DeliveryReport dr = new DeliveryReport();
            dr.ShowDialog();




        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM";

            Dlvermonth = dateTimePicker1.Text;
            MessageBox.Show(Dlvermonth);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

        }


        private void EmpSale()
        {
            // select employee id from Employee table                    
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
            /////////////////////////////////////////////////////////////

            using (SqlConnection con53 = new SqlConnection(gr))
            {
                SqlCommand cmd53 = new SqlCommand("SELECT Emp_Sales FROM PayRoll", con53);
                con53.Open();
                cmd53.ExecuteNonQuery();
                SqlDataReader rdr53 = cmd53.ExecuteReader();
                if (rdr53.HasRows)
                {
                    while (rdr53.Read())
                    {
                        NewSale = Convert.ToInt32(rdr53["Emp_Sales"]);
                    }
                    //  MessageBox.Show("value selected frm payroll");
                    rdr53.Close();
                }
            }           
            /////////////////////////////////////////////////////////today

            using (SqlConnection con51 = new SqlConnection(gr))
            {
                SqlCommand cmd51 = new SqlCommand("SELECT Emp_Type FROM Employee WHERE Emp_Name = '" + cmbEmployee.SelectedItem.ToString() + "'", con51);
                con51.Open();
                cmd51.ExecuteNonQuery();
                SqlDataReader rdr51 = cmd51.ExecuteReader();
                if (rdr51.HasRows)
                {
                    while (rdr51.Read())
                    {
                        empType = Convert.ToString(rdr51["Emp_Type"]);
                    }
                    // MessageBox.Show("Employee id selected");
                    rdr51.Close();
                }
            }
            /////////////////////////////////////////////////////////////
            if (empType == "Fixed Salary")
            {
            }
            else
            {
                // Update  payroll table : Rupees on new customer creation 
                int addition;   //  store addition of value on new customer creation 
                addition = NewSale + Convert.ToInt32(txtAmount.Text);
                using (SqlConnection con54 = new SqlConnection(gr))
                {
                    SqlCommand cmd54 = new SqlCommand("UPDATE PayRoll SET Emp_Sales='" + addition + "' where Emp_ID='" + empID + "'", con54);
                    con54.Open();
                    cmd54.ExecuteNonQuery();
                    //   MessageBox.Show("Sales  Added to Employee table", "JalPak");
                }


                /////////////////////////////////////////////////////////////
            }
        }

        private void deliveryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse.DeliveryCardList dcl = new DeliveryCardList();
            dcl.ShowDialog();
        }

        private void txtRatePerBottle_TextChanged(object sender, EventArgs e)
        {
            txtRatePerBottle.BackColor = System.Drawing.Color.White;
        }

        private void txtRatePerBottle_Leave(object sender, EventArgs e)
        {
            if (txtRatePerBottle.Text == "")
            {
                MessageBox.Show("Enter the Bottle Rate", "JalPak");

                txtRatePerBottle.BackColor = System.Drawing.Color.Red;
                txtRatePerBottle.Focus();
            }
        }

                      
    }         
}
