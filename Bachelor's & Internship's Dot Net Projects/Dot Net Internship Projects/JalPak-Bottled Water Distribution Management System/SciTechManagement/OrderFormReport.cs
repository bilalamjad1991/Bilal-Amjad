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
    public partial class OrderFormReport : Form
    {
        int x;
        public OrderFormReport()
        {
            InitializeComponent();
        }

        private void OrderFormReport_Load(object sender, EventArgs e)
        {
            x = Convert.ToInt32(OrderForm.oid);   
            // TODO: This line of code loads data into the 'NewOrderDataSet4.OrderDetails' table. You can move, or remove it, as needed.
            this.OrderDetailsTableAdapter.Fill(this.NewOrderDataSet4.OrderDetails,x);

            this.reportViewer1.RefreshReport();
        }

        private void OrderFormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
