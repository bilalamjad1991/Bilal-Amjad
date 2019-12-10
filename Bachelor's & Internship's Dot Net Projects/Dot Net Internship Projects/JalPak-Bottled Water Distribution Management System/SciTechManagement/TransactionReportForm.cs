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
    public partial class TransactionReportForm : Form
    {
        public TransactionReportForm()
        {
            InitializeComponent();
        }

        private void TransactionReportForm_Load(object sender, EventArgs e)
        {
            string df = SearchTransaction.dateFrom;
            string dt = SearchTransaction.dateTo;
            int rid = SearchTransaction.RefID;
            
            // TODO: This line of code loads data into the 'TransactionDataSet9.Trnsctns' table. You can move, or remove it, as needed.
            this.TrnsctnsTableAdapter.Fill(this.TransactionDataSet9.Trnsctns, df, dt, rid);

            this.reportViewer1.RefreshReport();
        }
    }
}
