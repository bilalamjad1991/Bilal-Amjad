using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SciTechManagement.List
{
    public partial class OrderdList : Form
    {       
        public OrderdList()
        {
            InitializeComponent();
        }

        private void OrderdList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'orderdListDataSet.OrderDetails' table. You can move, or remove it, as needed.
            this.orderDetailsTableAdapter.Fill(this.orderdListDataSet.OrderDetails);

        }
      
    }
}
