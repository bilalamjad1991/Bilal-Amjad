using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement.Database_Backup
{
    public partial class DatabaseBackup : Form
    {
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionstring = "";
        public DatabaseBackup()
        {
            InitializeComponent();
        }

        private void DatabaseBackup_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            cmbDatabases.Enabled = false;
            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
            txtDataSource.Focus();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtDataSource.Text == "")
            {
                MessageBox.Show("Please Enter Data Source.", "JalPak");
                txtDataSource.Focus();
                return;
            }
            else
            {
                try
                {
                    // connectionstring = "Data Source = "+txtDataSource.Text + "; User Id=" + txtUserId.Text +"; Password="+txtPassword.Text+"";
                    connectionstring = "Data Source = " + txtDataSource.Text + ";Integrated Security=True";
                    conn = new SqlConnection(connectionstring);
                    conn.Open();
                    // sql = "sp_databases";
                    sql = "SELECT * FROM sys.databases d WHERE d.database_id>4";
                    command = new SqlCommand(sql, conn);
                    reader = command.ExecuteReader();
                    cmbDatabases.Items.Clear();
                    while (reader.Read())
                    {
                        cmbDatabases.Items.Add(reader[0].ToString());
                    }

                    reader.Dispose();
                    conn.Close();
                    conn.Dispose();

                    txtDataSource.Enabled = false;
                    txtPassword.Enabled = false;
                    txtUserId.Enabled = false;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;

                    btnBackup.Enabled = true;
                    btnRestore.Enabled = true;
                    cmbDatabases.Enabled = true;
                    cmbDatabases.Focus();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            txtDataSource.Enabled = true;
            txtUserId.Enabled = true;
            txtPassword.Enabled = true;
            cmbDatabases.Text = "";
            cmbDatabases.Enabled = false;
            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            txtBackupFileloc.Text = "";
            txtRestoreFileloc.Text = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackupFileloc.Text = dlg.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtBackupFileloc.Text == "")
            {
                MessageBox.Show("Select the File Location.", "JalPak");
                return;
            }
            else
            {
                try
                {
                    if (cmbDatabases.Text.CompareTo("") == 0)
                    {
                        MessageBox.Show("Please Select a Database.", "JalPak");
                        return;
                    }
                    else
                    {
                        conn = new SqlConnection(connectionstring);
                        conn.Open();
                        sql = "BACKUP DATABASE " + cmbDatabases.Text + " TO DISK = '" + txtBackupFileloc.Text + "\\" + cmbDatabases.Text + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                        command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        MessageBox.Show("Successfully Database Backup Completed.", "JalPak");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
            
        }

        private void btnDBFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestoreFileloc.Text = dlg.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtRestoreFileloc.Text == "")
            {
                MessageBox.Show("Select the File Location.", "JalPak");
                return;
            }
            else
            {
                try
                {
                    if (cmbDatabases.Text.CompareTo("") == 0)
                    {
                        MessageBox.Show("Please Select a Database.", "JalPak");
                        return;
                    }
                    else
                    {
                        conn = new SqlConnection(connectionstring);
                        conn.Open();
                        sql = "Alter Database " + cmbDatabases.Text + " Set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += "Restore Database " + cmbDatabases.Text + " FROM Disk = '" + txtRestoreFileloc.Text + "' WITH REPLACE;";
                        command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        MessageBox.Show("Successfully Restore Database", "JalPak");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
        }      
    }
}
