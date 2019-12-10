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
    public partial class IGPReport : Form
    {
        int id;
        public IGPReport()
        {
            InitializeComponent();
        }

        private void IGPReport_Load(object sender, EventArgs e)
        {            
            id = Convert.ToInt32(Warehouse.InwardGatePass.igptext);
            // TODO: This line of code loads data into the 'IGPDS.InwardGatePass' table. You can move, or remove it, as needed.
            this.InwardGatePassTableAdapter.Fill(this.IGPDS.InwardGatePass,id);

            this.reportViewer1.RefreshReport();
        }

        private void IGPReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
