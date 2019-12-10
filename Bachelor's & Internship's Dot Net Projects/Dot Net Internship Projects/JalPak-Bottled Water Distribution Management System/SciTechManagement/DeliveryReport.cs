using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SciTechManagement
{
    public partial class DeliveryReport : Form
    {
        int id;
        string month;
         
        public DeliveryReport()
        {
            InitializeComponent();
        }

        private void DeliveryReport_Load(object sender, EventArgs e)
        {

            id =Convert.ToInt32( Warehouse.DeliveryCard.CustNo);
            month = Warehouse.DeliveryCard.CustMonth;
           
            this.DeliveryDetailsTableAdapter.Fill(this.InventoryDataSet4.DeliveryDetails,id,month);
          
            this.Customer_PackageTableAdapter.Fill(this.InventoryDataSet5.Customer_Package,id);
            
            this.CustomerDetailsTableAdapter.Fill(this.InventoryDataSet6.CustomerDetails,id);

            this.reportViewer1.RefreshReport();
        }

        private void DeliveryReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
