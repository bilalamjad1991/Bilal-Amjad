using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciTechManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnCloseAdmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "admin" && txtPwd.Text.Trim() == "admin")
            {
                
                CRM crm = new CRM();
                crm.Show();
                this.Hide();
                
            }
                
            else
            {

                lblErrorMsg.Text = "Incorrect User Name or Password...!";
                txtUserName.Text = null;
                txtPwd.Text = null;
                txtUserName.Focus();
            }
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAdminLogin;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "admin" && txtPwd.Text.Trim() == "admin")
            {

                CRM crm = new CRM();
                crm.Show();
                this.Hide();

            }

            else
            {

                lblErrorMsg.Text = "Incorrect User Name or Password...!";
                txtUserName.Text = null;
                txtPwd.Text = null;
                txtUserName.Focus();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
                                            
        }
    
}
