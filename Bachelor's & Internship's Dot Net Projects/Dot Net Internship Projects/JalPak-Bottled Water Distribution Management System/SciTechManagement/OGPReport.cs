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
    public partial class OGPReport : Form
    {
        int id;
        public OGPReport()
        {
            InitializeComponent();
        }

        private void OGPReport_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Warehouse.OutwardGatePass.ogpid);
            // TODO: This line of code loads data into the 'OGPDS.OutwardGatePass' table. You can move, or remove it, as needed.
            this.OutwardGatePassTableAdapter.Fill(this.OGPDS.OutwardGatePass,id);

            this.reportViewer1.RefreshReport();
        }

        private void OGPReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
