using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SciTechManagement.Warehouse
{
    public partial class DeliveryCardList : Form
    {
        public DeliveryCardList()
        {
            InitializeComponent();
        }

        private void DeliveryCardList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet10.DeliveryDetails' table. You can move, or remove it, as needed.
            this.deliveryDetailsTableAdapter.Fill(this.inventoryDataSet10.DeliveryDetails);
            // TODO: This line of code loads data into the 'deliveryListDataSet9.DeliveryDetails' table. You can move, or remove it, as needed.
            //this.deliveryDetailsTableAdapter.Fill(this.deliveryListDataSet9.DeliveryDetails);
            //////////////////////////////////////////////////////////////////////
            // dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
           // MergeCells();

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            //    for (int i = dataGridView1.Rows.Count - 1; i > 0; i--)
            //    {
            //        DataGridViewRow row = dataGridView1.Rows[i];
            //        DataGridViewRow previousRow = dataGridView1.Rows[i - 1];
            //        for (int j = 0; j < row.Cells.Count; j++)
            //        {
            //            if (row.Cells[j].Value == previousRow.Cells[j].Value)
            //            {
            //                if (previousRow.Cells[j].RowSpan == 0)
            //                {
            //                    if (row.Cells[j].RowSpan == 0)
            //                    {
            //                        previousRow.Cells[j].RowSpan += 2;
            //                    }
            //                    else
            //                    {
            //                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
            //                    }
            //                    row.Cells[j].Visible = false;
            //                }
            //            }
            //        }
            //    }


            //}
            /////////////////////////////



        }

        //private void MergeCells()
        //{
        //    int i = dataGridView1.Rows.Count - 2;
        //    while (i >= 0)
        //    {
        //        DataGridViewRow curRow = dataGridView1.Rows[i];
        //        DataGridViewRow preRow = dataGridView1.Rows[i + 1];

        //        int j = 0;
        //        while (j < curRow.Cells.Count)
        //        {
        //            if (curRow.Cells[j].Text == preRow.Cells[j].Text)
        //            {
        //                if (preRow.Cells[j].RowSpan < 2)
        //                {
        //                    curRow.Cells[j].RowSpan = 2;
        //                    preRow.Cells[j].Visible = false;
        //                }
        //                else
        //                {
        //                    curRow.Cells[j].RowSpan = preRow.Cells[j].RowSpan + 1;
        //                    preRow.Cells[j].Visible = false;
        //                }
        //            }
        //            j++;
        //        }
        //        i--;
        //    }
        //}

     
    }
}

