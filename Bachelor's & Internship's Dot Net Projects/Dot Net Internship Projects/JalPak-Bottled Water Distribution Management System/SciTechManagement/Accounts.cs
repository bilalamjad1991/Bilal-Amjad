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
    public partial class Accounts : Form
    {

        public static int id;
        public static int idaccount;
        public static int idtitle;
        public static string active;
        public static string leaf;
        public Accounts()
        {
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name FROM FirstLevelAcct", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            cmbMainAccounts.Items.Add(rdr[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }
        }

        private void btnAddAccounts_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = Convert.ToInt32(rdr["ID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }

            AddAccounts add = new AddAccounts();
            add.ShowDialog();

        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = cmbAccounts.Items.Count;

            for (int i = 0; i < num; i++)
            {
                if (cmbAccounts.SelectedIndex == i)
                {
                    cmbTitle.Items.Clear();
                    string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT ID FROM SecLevelAcct where Name='" + cmbAccounts.SelectedItem + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    idaccount = Convert.ToInt32(rdr["ID"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }


                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT Name FROM ThirdLevelAcct where SID='" + idaccount + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    cmbTitle.Items.Add(Convert.ToString(rdr["Name"]));
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Accounts Not found");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                }

            }
        }

        private void cmbMainAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainAccounts.SelectedIndex == 0)
            {
                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
            else if (cmbMainAccounts.SelectedIndex == 1)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 2)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 3)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 4)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
        }

        private void Accounts_Activated(object sender, EventArgs e)
        {

            cmbAccounts.Items.Clear();
            cmbAccounts.ResetText();
            cmbTitle.Items.Clear();
            cmbTitle.ResetText();

            int num2 = cmbAccounts.Items.Count;

            for (int i = 0; i < num2; i++)
            {
                if (cmbAccounts.SelectedIndex == i)
                {
                    // cmbTitle.Items.Clear();
                    string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT ID FROM SecLevelAcct where Name='" + cmbAccounts.SelectedItem + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    idaccount = Convert.ToInt32(rdr["ID"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }


                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT Name FROM ThirdLevelAcct where SID='" + idaccount + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    cmbTitle.Items.Add(Convert.ToString(rdr["Name"]));
                                }
                            }
                            else
                            {
                                //MessageBox.Show("Accounts Not found");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to22 : " + ex.Message);
                    }
                }

            }
            /////////////////////////////////////////////////
            if (cmbMainAccounts.SelectedIndex == 0)
            {
                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
            else if (cmbMainAccounts.SelectedIndex == 1)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 2)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 3)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            // MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }

            else if (cmbMainAccounts.SelectedIndex == 4)
            {

                cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }


                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM SecLevelAcct where FID='" + id + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                cmbAccounts.Items.Add(Convert.ToString(rdr["Name"]));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Accounts Not found");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }
            }
            /////////////////////////////////for title updated list after adding new title


            //int num2 = cmbAccounts.Items.Count;

            //for (int i = 0; i < num2; i++)
            //{
            //    if (cmbAccounts.SelectedIndex == i)
            //    {
            //       // cmbTitle.Items.Clear();
            //        string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            //        try
            //        {
            //            using (SqlConnection conn = new SqlConnection(gr))
            //            {
            //                SqlCommand cmd = new SqlCommand("SELECT ID FROM SecLevelAcct where Name='" + cmbAccounts.SelectedItem + "'", conn);
            //                conn.Open();
            //                cmd.ExecuteNonQuery();
            //                SqlDataReader rdr = cmd.ExecuteReader();
            //                if (rdr.HasRows)
            //                {
            //                    while (rdr.Read())
            //                    {
            //                        idaccount = Convert.ToInt32(rdr["ID"]);
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Failed due to : " + ex.Message);
            //        }


            //        try
            //        {
            //            using (SqlConnection conn = new SqlConnection(gr))
            //            {
            //                SqlCommand cmd = new SqlCommand("SELECT Name FROM ThirdLevelAcct where SID='" + idaccount + "'", conn);
            //                conn.Open();
            //                cmd.ExecuteNonQuery();
            //                SqlDataReader rdr = cmd.ExecuteReader();
            //                if (rdr.HasRows)
            //                {
            //                    while (rdr.Read())
            //                    {
            //                        cmbTitle.Items.Add(Convert.ToString(rdr["Name"]));
            //                    }
            //                }
            //                else
            //                {
            //                    //MessageBox.Show("Accounts Not found");
            //                }

            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Failed due to22 : " + ex.Message);
            //        }
            //    }

            //}




        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(gr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID FROM SecLevelAcct where Name='" + cmbAccounts.SelectedItem + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            idaccount = Convert.ToInt32(rdr["ID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to : " + ex.Message);
            }

            AddTitle adt = new AddTitle();

            adt.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMainAccounts.SelectedIndex==-1 && cmbAccounts.SelectedIndex==-1)
            {
                MessageBox.Show("Please Select Main Accounts And Accounts!");
            }
            else if (cmbMainAccounts.SelectedIndex != -1 && cmbAccounts.SelectedIndex == -1)
            {

                MessageBox.Show("Please Select Accounts!");
            
            }
            else{
            
            
            /////////////////////////////////////////////////////
            if (cmbMainAccounts.SelectedIndex == 0)
            {
                //cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }



            }
            else if (cmbMainAccounts.SelectedIndex == 1)
            {

                //cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }



            }

            else if (cmbMainAccounts.SelectedIndex == 2)
            {

                //cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }



            }

            else if (cmbMainAccounts.SelectedIndex == 3)
            {

                // cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }



            }

            else if (cmbMainAccounts.SelectedIndex == 4)
            {

                // cmbAccounts.Items.Clear();
                string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                try
                {
                    using (SqlConnection conn = new SqlConnection(gr))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT ID FROM FirstLevelAcct where Name='" + cmbMainAccounts.SelectedItem + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                id = Convert.ToInt32(rdr["ID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to : " + ex.Message);
                }



            }
            ///////////////////////////////////////////////////////for cmbAccounts////////////////


            int num3 = cmbAccounts.Items.Count;

            for (int i = 0; i < num3; i++)
            {
                if (cmbAccounts.SelectedIndex == i)
                {

                    string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT ID FROM SecLevelAcct where Name='" + cmbAccounts.SelectedItem + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    idaccount = Convert.ToInt32(rdr["ID"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                }
            }




            ////////////////////////////////////////////////////////for getting idtitle of cmbTitle////////////////////////////////////////////////

            int num4 = cmbAccounts.Items.Count;

            for (int i = 0; i < num4; i++)
            {
                if (cmbAccounts.SelectedIndex == i)
                {

                    string gr = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(gr))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT ID FROM ThirdLevelAcct where Name='" + cmbTitle.SelectedItem + "'", conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    idtitle = Convert.ToInt32(rdr["ID"]);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to : " + ex.Message);
                    }
                }
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
            string str = "Data Source=.\\sqlexpress;Initial Catalog=Inventory;Integrated Security=True";

            if (ActYes.Checked)
            {
                active = ActYes.Text;

            }
            else if (ActNo.Checked)
            {
                active = ActNo.Text;


            }

            if (LeafYes.Checked)
            {
                leaf = LeafYes.Text;

            }
            else if (LeafNo.Checked)
            {
                leaf = LeafNo.Text;


            }







            if (cmbTitle.SelectedIndex == -1)
            {



                using (SqlConnection con113 = new SqlConnection(str))
                {
                    SqlCommand cmd13 = new SqlCommand("INSERT INTO ActiveTree(FID,SID,Acct_Name,Active,Leaf)VALUES('" + id + "','" + idaccount + "','" + cmbAccounts.SelectedItem + "','" + active + "','" + leaf + "' )", con113);
                    con113.Open();
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Saved successfully!");

                    cmbAccounts.Items.Clear();
                    cmbAccounts.ResetText();
                    cmbTitle.Items.Clear();
                    cmbTitle.ResetText();
                }
            }
            else
            {

                try
                {
                    using (SqlConnection con114 = new SqlConnection(str))
                    {
                        SqlCommand cmd13 = new SqlCommand("INSERT INTO ActiveTree(FID,SID,TID,Acct_Name,Active,Leaf)VALUES('" + id + "','" + idaccount + "','" + idtitle + "','" + cmbTitle.SelectedItem + "','" + active + "','" + leaf + "' )", con114);
                        con114.Open();
                        cmd13.ExecuteNonQuery();
                        MessageBox.Show("Saved successfully!");

                        cmbAccounts.Items.Clear();
                        cmbAccounts.ResetText();
                        cmbTitle.Items.Clear();
                        cmbTitle.ResetText();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }



            }

            }//else part of first if end here
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbAccounts.Items.Clear();
            cmbAccounts.ResetText();
            cmbTitle.Items.Clear();
            cmbTitle.ResetText();
        }
    }
}
