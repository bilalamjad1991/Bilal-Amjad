using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SciTechManagement.Reports
{
    public partial class InwardGatePassReport : Form
    {
        public InwardGatePassReport()
        {
            InitializeComponent();
        }

        private void InwardGatePassReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
