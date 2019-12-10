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
    public partial class DeliveryCard : Form
    {
        public DeliveryCard()
        {
            InitializeComponent();
        }

        private void DeliveryCard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet.Items' table. You can move, or remove it, as needed.

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
