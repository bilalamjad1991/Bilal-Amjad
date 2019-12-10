using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciTechManagement
{
    public partial class AllItemsInventoriedForm : Form
    {
        public AllItemsInventoriedForm()
        {
            InitializeComponent();
        }

        private void AllItemsInventoriedForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'InventoryDataSet.Items' table. You can move, or remove it, as needed.
            this.ItemsTableAdapter.Fill(this.InventoryDataSet.Items);

            this.reportViewer1.RefreshReport();
        }
    }
}
