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
    public partial class Form1 : Form
    {
        int igpNo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            igpNo = Convert.ToInt32(Warehouse.InwardGatePass.igptext);
            // TODO: This line of code loads data into the 'IGPDataSet1.InwardGatePass' table. You can move, or remove it, as needed.
            this.InwardGatePassTableAdapter.Fill(this.IGPDataSet1.InwardGatePass,igpNo);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }
    }
}
