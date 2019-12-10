using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SciTechManagement.List
{
    public partial class IGPList : Form
    {
        public IGPList()
        {
            InitializeComponent();
        }

        private void IGPList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iGPListDataSet.InwardGatePass' table. You can move, or remove it, as needed.
            this.inwardGatePassTableAdapter.Fill(this.iGPListDataSet.InwardGatePass);

        }
    }
}
