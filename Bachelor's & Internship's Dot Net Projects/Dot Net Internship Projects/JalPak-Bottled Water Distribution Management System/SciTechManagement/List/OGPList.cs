﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SciTechManagement.List
{
    public partial class OGPList : Form
    {
        public OGPList()
        {
            InitializeComponent();
        }

        private void OGPList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oGPListDataSet.OutwardGatePass' table. You can move, or remove it, as needed.
            this.outwardGatePassTableAdapter.Fill(this.oGPListDataSet.OutwardGatePass);

        }
    }
}
