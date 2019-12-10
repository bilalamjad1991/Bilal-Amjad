namespace SciTechManagement.Warehouse
{
    partial class DeliveryCardList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.custIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveredDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliverdMonthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bottlesDeliveredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bottlesRecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceBottleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountRecievedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryDataSet10 = new SciTechManagement.InventoryDataSet10();
            this.deliveryDetailsTableAdapter = new SciTechManagement.InventoryDataSet10TableAdapters.DeliveryDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet10)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.custIDDataGridViewTextBoxColumn,
            this.deliveredDateDataGridViewTextBoxColumn,
            this.deliverdMonthDataGridViewTextBoxColumn,
            this.bottlesDeliveredDataGridViewTextBoxColumn,
            this.bottlesRecDataGridViewTextBoxColumn,
            this.balanceBottleDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.amountRecievedDataGridViewTextBoxColumn,
            this.amountBalanceDataGridViewTextBoxColumn,
            this.signatureDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.deliveryDetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1043, 384);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // custIDDataGridViewTextBoxColumn
            // 
            this.custIDDataGridViewTextBoxColumn.DataPropertyName = "Cust_ID";
            this.custIDDataGridViewTextBoxColumn.HeaderText = "Cust_ID";
            this.custIDDataGridViewTextBoxColumn.Name = "custIDDataGridViewTextBoxColumn";
            // 
            // deliveredDateDataGridViewTextBoxColumn
            // 
            this.deliveredDateDataGridViewTextBoxColumn.DataPropertyName = "Delivered_Date";
            this.deliveredDateDataGridViewTextBoxColumn.HeaderText = "Delivered_Date";
            this.deliveredDateDataGridViewTextBoxColumn.Name = "deliveredDateDataGridViewTextBoxColumn";
            // 
            // deliverdMonthDataGridViewTextBoxColumn
            // 
            this.deliverdMonthDataGridViewTextBoxColumn.DataPropertyName = "Deliverd_Month";
            this.deliverdMonthDataGridViewTextBoxColumn.HeaderText = "Deliverd_Month";
            this.deliverdMonthDataGridViewTextBoxColumn.Name = "deliverdMonthDataGridViewTextBoxColumn";
            // 
            // bottlesDeliveredDataGridViewTextBoxColumn
            // 
            this.bottlesDeliveredDataGridViewTextBoxColumn.DataPropertyName = "Bottles_Delivered";
            this.bottlesDeliveredDataGridViewTextBoxColumn.HeaderText = "Bottles_Delivered";
            this.bottlesDeliveredDataGridViewTextBoxColumn.Name = "bottlesDeliveredDataGridViewTextBoxColumn";
            // 
            // bottlesRecDataGridViewTextBoxColumn
            // 
            this.bottlesRecDataGridViewTextBoxColumn.DataPropertyName = "Bottles_Rec";
            this.bottlesRecDataGridViewTextBoxColumn.HeaderText = "Bottles_Rec";
            this.bottlesRecDataGridViewTextBoxColumn.Name = "bottlesRecDataGridViewTextBoxColumn";
            // 
            // balanceBottleDataGridViewTextBoxColumn
            // 
            this.balanceBottleDataGridViewTextBoxColumn.DataPropertyName = "Balance_Bottle";
            this.balanceBottleDataGridViewTextBoxColumn.HeaderText = "Balance_Bottle";
            this.balanceBottleDataGridViewTextBoxColumn.Name = "balanceBottleDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // amountRecievedDataGridViewTextBoxColumn
            // 
            this.amountRecievedDataGridViewTextBoxColumn.DataPropertyName = "Amount_Recieved";
            this.amountRecievedDataGridViewTextBoxColumn.HeaderText = "Amount_Recieved";
            this.amountRecievedDataGridViewTextBoxColumn.Name = "amountRecievedDataGridViewTextBoxColumn";
            // 
            // amountBalanceDataGridViewTextBoxColumn
            // 
            this.amountBalanceDataGridViewTextBoxColumn.DataPropertyName = "Amount_Balance";
            this.amountBalanceDataGridViewTextBoxColumn.HeaderText = "Amount_Balance";
            this.amountBalanceDataGridViewTextBoxColumn.Name = "amountBalanceDataGridViewTextBoxColumn";
            // 
            // signatureDataGridViewTextBoxColumn
            // 
            this.signatureDataGridViewTextBoxColumn.DataPropertyName = "Signature";
            this.signatureDataGridViewTextBoxColumn.HeaderText = "Signature";
            this.signatureDataGridViewTextBoxColumn.Name = "signatureDataGridViewTextBoxColumn";
            // 
            // deliveryDetailsBindingSource
            // 
            this.deliveryDetailsBindingSource.DataMember = "DeliveryDetails";
            this.deliveryDetailsBindingSource.DataSource = this.inventoryDataSet10;
            // 
            // inventoryDataSet10
            // 
            this.inventoryDataSet10.DataSetName = "InventoryDataSet10";
            this.inventoryDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // deliveryDetailsTableAdapter
            // 
            this.deliveryDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 383);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DeliveryCardList";
            this.Text = "DeliveryCardList";
            this.Load += new System.EventHandler(this.DeliveryCardList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private InventoryDataSet10 inventoryDataSet10;
        private System.Windows.Forms.BindingSource deliveryDetailsBindingSource;
        private InventoryDataSet10TableAdapters.DeliveryDetailsTableAdapter deliveryDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn custIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveredDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliverdMonthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bottlesDeliveredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bottlesRecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceBottleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountRecievedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureDataGridViewTextBoxColumn;
    }
}