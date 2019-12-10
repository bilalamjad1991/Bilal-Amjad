using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement.Attendance
{
    public partial class Attendance : Form
    {
        int count = 0;
        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
        public Attendance()
        {
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.attendanceDataSet.Employee);

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

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Attendance";
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 10;
            cmb.Items.Add("Present");
            cmb.Items.Add("Casual");
            cmb.Items.Add("Paid");
            cmb.Items.Add("Medical");
            cmb.Items.Add("Absent");
            dataGridView1.Columns.Add(cmb);

            DataGridViewLinkColumn mark = new DataGridViewLinkColumn();
            dataGridView1.Columns.Add(mark);
            mark.Name = "Mark";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                this.dataGridView1.Rows[i].Cells["Mark"].Value = Convert.ToString("mark");
            }

            //////////////////for onload attd/


              for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                using (SqlConnection con3 = new SqlConnection(gr))
                {

                    SqlCommand cmd3 = new SqlCommand("SELECT * from Attendance where EmpId='" + dataGridView1.Rows[i].Cells[0].Value + "'" + " and cast(dateToday as date) ='" + dataGridView1.Rows[i].Cells[3].Value + "' ", con3);
                    con3.Open();
                    SqlDataReader rdr3 = cmd3.ExecuteReader();

                    if (rdr3.HasRows)
                    {
                        while (rdr3.Read())
                        {
                            dataGridView1.Rows[i].Cells[4].Value = Convert.ToString(rdr3["LeaveType"]);
                        }
                    }
                    else
                    {
                        rdr3.Close();
                    }

                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, e.Exception.Message, "Error");
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)  ///check whether attndnce is marked before clicking mark
            {
                using (SqlConnection con3 = new SqlConnection(gr))
                {
                    SqlCommand cmd3 = new SqlCommand("SELECT * from Attendance where EmpId='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'" + " and cast(dateToday as date) ='" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "'", con3);
                    con3.Open();
                    SqlDataReader rdr3 = cmd3.ExecuteReader();

                    if (rdr3.HasRows)  // check if attendance is already marked
                    {
                        MessageBox.Show("Attendance Already Marked!","JalPak");
                        //////////////////for returning attd staus already marked////////////////
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            using (SqlConnection con30 = new SqlConnection(gr))
                            {
                                SqlCommand cmd30 = new SqlCommand("SELECT * from Attendance where EmpId='" + dataGridView1.Rows[i].Cells[0].Value + "'" + " and dateToday ='" + dataGridView1.Rows[i].Cells[3].Value + "' ", con30);
                                con30.Open();
                                SqlDataReader rdr30 = cmd30.ExecuteReader();

                                if (rdr30.HasRows)
                                {
                                    while (rdr30.Read())
                                    {
                                        dataGridView1.Rows[i].Cells[4].Value = Convert.ToString(rdr30["LeaveType"]);
                                    }
                                }
                                else
                                {
                                    rdr30.Close();
                                }

                            }
                        }
                        ////////////////////////////////////////////////////////////////////////
                    }
                    else             //check if attendance is not already marked
                    {
                        rdr3.Close();
                        ///////////////////////////////////////////////////////////
                        if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Casual")
                        {
                            try
                            {
                                using (SqlConnection con21 = new SqlConnection(gr))
                                {
                                    SqlCommand cmd21 = new SqlCommand("SELECT * from Attendance where EmpId ='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "' AND LeaveType='" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "'" + " AND month ='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "'", con21);
                                    con21.Open();
                                    SqlDataReader reader = cmd21.ExecuteReader();
                                    while (reader.Read())
                                    {

                                        count++;
                                    }
                                    if (count < 10)
                                    {
                                        try
                                        {
                                            using (SqlConnection con2 = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("Insert into Attendance(EmpId,EmpName,month,dateToday,LeaveType) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "', '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "')", con2);
                                                con2.Open();
                                                cmdd.ExecuteNonQuery();
                                            }
                                            MessageBox.Show("Attendance Marked...!","JalPak");
                                        }
                                        catch (Exception ex)
                                        {

                                            MessageBox.Show(" Insert failed due to : " + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(" Your Casual leaves are over the limit.Try other Leave Type","JalPak");
                                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";

                                    }
                                   // MessageBox.Show("count " + count);
                                    count = 0;
                                    reader.Close();

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(" COUNT FAILED DUE TO : " + ex.Message);
                            }
                        }
                        else if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Paid")
                        {
                            try
                            {
                                using (SqlConnection con21 = new SqlConnection(gr))
                                {

                                    SqlCommand cmd21 = new SqlCommand("SELECT * from Attendance where EmpId ='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "' AND LeaveType='" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "'" + " AND month ='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", con21);
                                    con21.Open();
                                    SqlDataReader reader = cmd21.ExecuteReader();
                                    while (reader.Read())
                                    {

                                        count++;
                                    }
                                    if (count < 14)
                                    {
                                        try
                                        {
                                            using (SqlConnection con2 = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("Insert into Attendance(EmpId,EmpName,month,dateToday,LeaveType) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "', '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "')", con2);
                                                con2.Open();
                                                cmdd.ExecuteNonQuery();
                                            }
                                            MessageBox.Show(" Attendance Marked...!","JalPak");
                                        }
                                        catch (Exception ex)
                                        {

                                            MessageBox.Show(" Insert failed due to : " + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(" Your Medical leaves are over the limit.Try other Leave Type","JalPak");
                                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";

                                    }
                                    // MessageBox.Show("count " + count);
                                    count = 0;
                                    reader.Close();

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(" COUNT FAILED DUE TO : " + ex.Message);
                            }
                        }
                        ///////////////////////////////tosend
                        else if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Medical")
                        {
                            try
                            {
                                using (SqlConnection con21 = new SqlConnection(gr))
                                {

                                    SqlCommand cmd21 = new SqlCommand("SELECT * from Attendance where EmpId ='" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "' AND LeaveType='" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "'" + " AND month ='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", con21);
                                    con21.Open();
                                    SqlDataReader reader = cmd21.ExecuteReader();
                                    while (reader.Read())
                                    {

                                        count++;
                                    }
                                    if (count < 10)
                                    {
                                        try
                                        {
                                            using (SqlConnection con2 = new SqlConnection(gr))
                                            {

                                                SqlCommand cmdd = new SqlCommand("Insert into Attendance(EmpId,EmpName,month,dateToday,LeaveType) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "', '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "')", con2);
                                                con2.Open();
                                                cmdd.ExecuteNonQuery();
                                            }
                                            MessageBox.Show(" Attendance Marked...!","JalPak");
                                        }
                                        catch (Exception ex)
                                        {

                                            MessageBox.Show(" Insert failed due to : " + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(" Your Medical leaves are over the limit.Try other Leave Type ", "JalPak");
                                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";

                                    }
                                  //  MessageBox.Show("count " + count);
                                    count = 0;
                                    reader.Close();

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(" COUNT FAILED DUE TO : " + ex.Message);
                            }
                        }

                        else if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Present")
                        {

                            try
                            {
                                using (SqlConnection con2 = new SqlConnection(gr))
                                {

                                    SqlCommand cmdd = new SqlCommand("Insert into Attendance(EmpId,EmpName,month,dateToday,LeaveType) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "', '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "')", con2);
                                    con2.Open();
                                    cmdd.ExecuteNonQuery();
                                }
                                MessageBox.Show(" Attendance Marked...!", "JalPak");
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(" Insert failed due to : " + ex.Message);
                            }

                        }

                        else if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Absent")
                        {

                            try
                            {
                                using (SqlConnection con2 = new SqlConnection(gr))
                                {

                                    SqlCommand cmdd = new SqlCommand("Insert into Attendance(EmpId,EmpName,month,dateToday,LeaveType) values ('" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "', '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[2].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[3].Value + "','" + dataGridView1.Rows[e.RowIndex].Cells[4].Value + "')", con2);
                                    con2.Open();
                                    cmdd.ExecuteNonQuery();
                                }
                                MessageBox.Show(" Attendance Marked...!", "JalPak");
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(" Insert failed due to : " + ex.Message);
                            }
                        }                       
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Mark Your Attendance...!", "JalPak");
            }

        }
    }    
}
