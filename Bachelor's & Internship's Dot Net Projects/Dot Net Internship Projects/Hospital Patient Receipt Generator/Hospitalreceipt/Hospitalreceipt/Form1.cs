using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace Hospitalreceipt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InvoiceData();  // function calling

            lblSystemDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            lblDateOfAdmission.Text = DateTime.Now.ToShortDateString(); //2014/02/01
            //lblDateOfAdmission.Text = DateTime.Now.ToShortDateString(); //2014/02/01

            // combox items 
            cmbDeprtName.Items.Add("ENT");
            cmbDeprtName.Items.Add("Pathalogy");
            cmbDeprtName.Items.Add("Gynacalogist");
            cmbDeprtName.Items.Add("Dentistry");
            cmbDeprtName.Items.Add("Cardiology");
            cmbDeprtName.Items.Add("Neurology");
            cmbDeprtName.Items.Add("Ophthalmology");
            cmbDeprtName.Items.Add("Orthopaedics");
            cmbDeprtName.Items.Add("Pharmacy");
            cmbDeprtName.Items.Add("Urology");
            cmbDeprtName.SelectedIndex = 0;
        }
        private void InvoiceData()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PatientReceipt.accdb";
            try
            {
                conn.Open();
                string my_querry = "Select Max(Emg_No)+1 from PatientRecord '";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();

                OleDbDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        lblEmgNo.Text = rdr[0].ToString();
                    }
                    else
                    {
                        lblEmgNo.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtbxP_Name.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Name...!");
                txtbxP_Name.BackColor = System.Drawing.Color.Red;
                txtbxP_Name.Focus();
            }
            else if (txtbxP_F_Name.Text == string.Empty)
            {

                MessageBox.Show("Enter Patient Father Name...!");
                txtbxP_F_Name.BackColor = System.Drawing.Color.Red;
                txtbxP_F_Name.Focus();
            }
            else if (txtbxP_Age.Text == string.Empty)
            {
                MessageBox.Show("Enter Patient Age...!");
                txtbxP_Age.BackColor = System.Drawing.Color.Red;
                txtbxP_Age.Focus();
            }
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PatientReceipt.accdb";
                conn.Open();
                string my_querry = "SELECT *FROM PatientRecord WHERE Emg_No Like'" + lblEmgNo.Text.Trim()+ "%'";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                OleDbDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    try
                    {

                        //  Associate PrintPreviewDialog with PrintDocument.
                        printPreviewDialog1.Document = printDocument1;
                        //Show PrintPreview Dialog
                        printPreviewDialog1.ShowDialog();
                        InvoiceData();

                        //my_querry = "Update [PatientRecord] Set [P_Name] = ?, [P_FName] = ?, [AdmsnDate] = ?, [P_Age] = ?, [Hsptl_Deprt] = ? WHERE Emg_No = ?";
                        //   OleDbCommand cmddd = new OleDbCommand(my_querry, conn);

                        //   cmddd.Parameters.AddWithValue("P_Name", txtbxP_Name.Text);
                        //   cmddd.Parameters.AddWithValue("P_FName", txtbxP_F_Name.Text);
                        //   cmddd.Parameters.AddWithValue("AdmsnDate", lblDateOfAdmission.Text);
                        //   cmddd.Parameters.AddWithValue("P_Age", txtbxP_Age.Text);
                        //   cmddd.Parameters.AddWithValue("Hsptl_Deprt", cmbDeprtName.SelectedItem.ToString());
                        //   cmddd.Parameters.AddWithValue("Emg_No", lblEmgNo.Text);

                        //   int rowseffected= cmddd.ExecuteNonQuery();                    
                        //   MessageBox.Show("Data Updated successfuly...! Effected Rows "+ rowseffected);
                        //   InvoiceData();
                        //  // conn.Close();
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Failed  due to : " + exx.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    txtbxP_Name.Text = null;
                    txtbxP_F_Name.Text = null;
                    txtbxP_Age.Text = null;
                    txtbxSearchRecord.Text = null;
                    cmbDeprtName.SelectedIndex = 0;
                    txtbxP_Name.Focus();
                    lblSystemDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    lblDateOfAdmission.Text = DateTime.Now.ToShortDateString(); //2014/02/01
                }

                else
                {
                    try
                    {
                        //conn.Open();
                        string dbEmergencyNo = lblEmgNo.Text.Trim();
                        string dbPatientName = txtbxP_Name.Text.ToUpperInvariant().Trim().ToString();
                        string dbP_FName = txtbxP_F_Name.Text.ToUpperInvariant().Trim().ToString();
                        string dbAdmissionDate = lblDateOfAdmission.Text.ToString();
                        string dbAge = txtbxP_Age.Text.Trim();
                        string dbDepartment = cmbDeprtName.SelectedItem.ToString();
                        my_querry = "INSERT INTO PatientRecord(Emg_No,P_Name,P_FName,AdmsnDate,P_Age,Hsptl_Deprt)VALUES('" + dbEmergencyNo + "','" + dbPatientName + "','" + dbP_FName + "','" + dbAdmissionDate + "','" + dbAge + "','" + dbDepartment + "')";
                        OleDbCommand cmdd = new OleDbCommand(my_querry, conn);
                        cmdd.ExecuteNonQuery();

                        //  Associate PrintPreviewDialog with PrintDocument.
                        printPreviewDialog1.Document = printDocument1;
                        //Show PrintPreview Dialog
                        printPreviewDialog1.ShowDialog();

                        //  MessageBox.Show("Data saved successfuly!");
                        InvoiceData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                txtbxP_Name.Text = null;
                txtbxP_F_Name.Text = null;
                txtbxP_Age.Text = null;
                txtbxSearchRecord.Text = null;
                cmbDeprtName.SelectedIndex = 0;
                txtbxP_Name.Focus();
                lblSystemDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                lblDateOfAdmission.Text = DateTime.Now.ToShortDateString(); //2014/02/01
            }
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PatientReceipt.accdb";
            try
            {
                conn.Open();
                string my_querry = "SELECT  [Emg_No], [P_Name], [P_FName], [AdmsnDate], [P_Age], [Hsptl_Deprt] FROM PatientRecord WHERE Emg_No = '" + txtbxSearchRecord.Text.Trim().ToString() + "'";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                OleDbDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lblEmgNo.Text = (rdr["Emg_No"].ToString());
                        txtbxP_Name.Text = (rdr["P_Name"].ToString());
                        txtbxP_F_Name.Text = (rdr["P_FName"].ToString());
                        lblDateOfAdmission.Text = (rdr["AdmsnDate"].ToString());
                        txtbxP_Age.Text = (rdr["P_Age"].ToString());
                        cmbDeprtName.SelectedItem = (rdr["Hsptl_Deprt"].ToString());
                        //  cmbDeprtName.Enabled = false;                       
                        // txtbxTempDepartment.Visible = true;
                    }
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Record Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InvoiceData();
            txtbxP_Name.Text = null;
            txtbxP_F_Name.Text = null;
            txtbxP_Age.Text = null;
            txtbxSearchRecord.Text = null;
            cmbDeprtName.Enabled = true;
            cmbDeprtName.SelectedIndex = 0;
            txtbxP_Name.BackColor = System.Drawing.Color.White;
            txtbxP_F_Name.BackColor = System.Drawing.Color.White;
            txtbxP_Age.BackColor = System.Drawing.Color.White;

            lblSystemDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            lblDateOfAdmission.Text = DateTime.Now.ToString("MM/dd/yyy"); //2014/02/01
            txtbxP_Name.Focus();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.pictureBox2.Image, 280, 80, 246, 40);
            e.Graphics.DrawImage(this.pictureBox1.Image, 600, 50, 85, 91);
            e.Graphics.DrawString(cmbDeprtName.Text, cmbDeprtName.Font, Brushes.Black, 180, 295);
            e.Graphics.DrawString(label1.Text, label1.Font, Brushes.Black, 200, 20);
            e.Graphics.DrawString(label2.Text, label2.Font, Brushes.Black, 250, 49);
            e.Graphics.DrawString(label3.Text, label3.Font, Brushes.Black, 50, 100);
            e.Graphics.DrawString(label4.Text, label4.Font, Brushes.Black, 50, 150);
            e.Graphics.DrawString(label8.Text, label8.Font, Brushes.Black, 500, 150);
            e.Graphics.DrawString(lblEmgNo.Text, lblEmgNo.Font, Brushes.Black, 170, 150);
            e.Graphics.DrawString(lblSystemDateTime.Text, lblSystemDateTime.Font, Brushes.Black, 550, 150);
            e.Graphics.DrawString(label5.Text, label5.Font, Brushes.Black, 50, 190);
            e.Graphics.DrawString(txtbxP_Name.Text, txtbxP_Name.Font, Brushes.Black, 170, 190);
            e.Graphics.DrawString(label6.Text, label6.Font, Brushes.Black, 50, 227);
            e.Graphics.DrawString(txtbxP_F_Name.Text, txtbxP_F_Name.Font, Brushes.Black, 170, 228);
            e.Graphics.DrawString(label12.Text, label12.Font, Brushes.Black, 500, 232);
            e.Graphics.DrawString(txtbxP_Age.Text, txtbxP_Age.Font, Brushes.Black, 544, 236);
            e.Graphics.DrawString(lblYear.Text, lblYear.Font, Brushes.Black, 570, 234);
            e.Graphics.DrawString(label7.Text, label7.Font, Brushes.Black, 50, 259);
            e.Graphics.DrawString(lblDateOfAdmission.Text, lblDateOfAdmission.Font, Brushes.Black, 200, 259);
            e.Graphics.DrawString(label9.Text, label9.Font, Brushes.Black, 50, 291);
            e.Graphics.DrawString(lblUrduInstruction.Text, lblUrduInstruction.Font, Brushes.Black, 80, 325);
            e.Graphics.DrawString(lblUrduInstruction2.Text, lblUrduInstruction2.Font, Brushes.Black, 60, 360);
            e.Graphics.DrawString(lblEnglishInstructions.Text, lblEnglishInstructions.Font, Brushes.Black, 50, 400);
            e.Graphics.DrawString(lblEnglishInstructions2.Text, lblEnglishInstructions2.Font, Brushes.Black, 50, 425);
            e.Graphics.DrawString(lblPrecautions.Text, lblPrecautions.Font, Brushes.Black, 70, 461);
            e.Graphics.DrawString(lblPrecautions2.Text, lblPrecautions2.Font, Brushes.Black, 100, 480);
            e.Graphics.DrawString(lblIdentity.Text, lblIdentity.Font, Brushes.Black, 110, 500);


            e.Graphics.PageUnit = GraphicsUnit.Inch;
            e.PageSettings.PaperSize = new PaperSize("Custom", 800, 500);
            e.PageSettings.PaperSize.Height = 161;
            e.PageSettings.PaperSize.Width = 537;
        }
        string oldText1 = string.Empty;
        string oldText2 = string.Empty;
        string oldText3 = string.Empty;
        string oldText4 = string.Empty;

        private void txtbxP_Name_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^([a-zA-Z' ]+)$");
            if (txtbxP_Name.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtbxP_Name.Text))
                {
                    txtbxP_Name.BackColor = System.Drawing.Color.Red;
                    txtbxP_Name.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtbxP_Name.SelectAll();
                    //e.Cancel = true;

                }
                else
                {
                    txtbxP_Name.BackColor = System.Drawing.Color.White;
                    txtbxP_Name.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void txtbxP_F_Name_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^([a-zA-Z' ]+)$");
            if (txtbxP_F_Name.Text.Length > 0)
            {

                if (!rEMail.IsMatch(txtbxP_F_Name.Text))
                {
                    txtbxP_F_Name.BackColor = System.Drawing.Color.Red;
                    txtbxP_F_Name.ForeColor = System.Drawing.Color.White;
                    //MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtbxP_F_Name.SelectAll();
                    //e.Cancel = true;

                }
                else
                {
                    txtbxP_F_Name.BackColor = System.Drawing.Color.White;
                    txtbxP_F_Name.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void txtbxP_Age_TextChanged(object sender, EventArgs e)
        {
            if (txtbxP_Age.Text.All(chr => char.IsNumber(chr)))
            {
                oldText3 = txtbxP_Age.Text;
                txtbxP_Age.Text = oldText3;

                txtbxP_Age.BackColor = System.Drawing.Color.White;
                txtbxP_Age.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtbxP_Age.Text = oldText3;
                txtbxP_Age.BackColor = System.Drawing.Color.Red;
                txtbxP_Age.ForeColor = System.Drawing.Color.White;
            }
            txtbxP_Age.SelectionStart = txtbxP_Age.Text.Length;
        }

        private void txtbxSearchRecord_TextChanged(object sender, EventArgs e)
        {
            if (txtbxSearchRecord.Text.All(chr => char.IsNumber(chr)))
            {
                oldText4 = txtbxSearchRecord.Text;
                txtbxSearchRecord.Text = oldText4;

                txtbxSearchRecord.BackColor = System.Drawing.Color.White;
                txtbxSearchRecord.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtbxSearchRecord.Text = oldText4;
                txtbxSearchRecord.BackColor = System.Drawing.Color.Red;
                txtbxSearchRecord.ForeColor = System.Drawing.Color.White;
            }
            txtbxSearchRecord.SelectionStart = txtbxSearchRecord.Text.Length;
        }

        private void txtbxSearchRecord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.AcceptButton = btnSearchRecord;
            }       
        }

        private void txtbxP_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.AcceptButton = btnPrint;
            }       
        }
       
    }
}
