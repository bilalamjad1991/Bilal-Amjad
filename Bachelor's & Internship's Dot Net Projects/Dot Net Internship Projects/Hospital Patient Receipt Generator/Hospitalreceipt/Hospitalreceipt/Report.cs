using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospitalreceipt
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PatientReceiptDataSet.PatientRecord' table. You can move, or remove it, as needed.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 =(dateTimePicker1.Value.Date);
            DateTime date2 =(dateTimePicker2.Value.Date);


            this.PatientRecordTableAdapter.Fill(this.PatientReceiptDataSet.PatientRecord, date1, date2);

            this.reportViewer1.RefreshReport();
        }
    }
}
