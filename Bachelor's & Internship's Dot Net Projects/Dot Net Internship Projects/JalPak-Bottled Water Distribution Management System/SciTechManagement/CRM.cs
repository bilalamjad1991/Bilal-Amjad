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
    public partial class CRM : Form
    {
        public CRM()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSciTech about = new AboutSciTech();
            about.ShowDialog();
        }

        private void inwardGatepassToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Warehouse.InwardGatePass inwardGatepass = new Warehouse.InwardGatePass();
            inwardGatepass.ShowDialog();
        }

        private void outwardGatepassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse.OutwardGatePass outwardGatepass = new Warehouse.OutwardGatePass();
            outwardGatepass.ShowDialog();
        }

        private void deliveryCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse.DeliveryCard deliveryCard = new Warehouse.DeliveryCard();
            deliveryCard.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerDetails CD = new CustomerDetails();
            CD.ShowDialog();
        }

        private void CRM_Load(object sender, EventArgs e)
        {
            
            
        }
      
        private void allItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AllItemsInventoriedForm allitemsreport = new AllItemsInventoriedForm();
            //allitemsreport.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           this.Close();
            //Admin admin = new Admin();
            //admin.Show();
        }
      
        private void packageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackageDetails PD = new PackageDetails();
            PD.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            PackageDetails PD = new PackageDetails();
            PD.ShowDialog();
            //CustomerList custList = new CustomerList();
            //custList.ShowDialog();

            //MessageBox.Show(" Under Construction :) :) ","JalPak");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm();
            of.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            CustomerDetails custDetail = new CustomerDetails();
            custDetail.ShowDialog();
        }                

        private void rectangleShape1_Click_1(object sender, EventArgs e)
        {            
            Inventory inventory = new Inventory();
            inventory.ShowDialog();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm();
            of.ShowDialog();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {
            PackageDetails PD = new PackageDetails();
            PD.ShowDialog();
        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {
            CustomerDetails custDetail = new CustomerDetails();
            custDetail.ShowDialog();
        }

        private void CRM_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Close();
            Admin ad = new Admin();
            ad.Show();

        }

        private void bonusCommissionToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            PayRoll.BonusAndCommision bac = new PayRoll.BonusAndCommision();
            bac.ShowDialog();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayRoll.Department d = new PayRoll.Department();
            d.ShowDialog();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayRoll.Employee ee = new PayRoll.Employee();
            ee.ShowDialog();
        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.Attendance  aa = new Attendance.Attendance();
            aa.ShowDialog();
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceForm af = new AttendanceForm();
            af.ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database_Backup.DatabaseBackup db = new Database_Backup.DatabaseBackup();
            db.ShowDialog();
        }

        private void grossSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayRoll.GrossSalary gs = new PayRoll.GrossSalary();
            gs.ShowDialog();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts ac = new Accounts();
            ac.ShowDialog();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction tr = new Transaction();
            tr.ShowDialog();
        }

        private void searchTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchTransaction st = new SearchTransaction();
            st.ShowDialog();
        }

        private void deliveryCardListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouse.DeliveryCardList dcl= new Warehouse.DeliveryCardList();
            dcl.ShowDialog();
        }

            
    }
}
