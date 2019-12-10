namespace SciTechManagement.List
{
    partial class IGPList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGPList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iGPListDataSet = new SciTechManagement.IGPListDataSet();
            this.inwardGatePassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inwardGatePassTableAdapter = new SciTechManagement.IGPListDataSetTableAdapters.InwardGatePassTableAdapter();
            this.iGPIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPThroughDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPParticularsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGPQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iGTRemarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGPListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inwardGatePassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iGPIDDataGridViewTextBoxColumn,
            this.iGPDateDataGridViewTextBoxColumn,
            this.iGPThroughDataGridViewTextBoxColumn,
            this.iGPByDataGridViewTextBoxColumn,
            this.iGPForDataGridViewTextBoxColumn,
            this.iGPParticularsDataGridViewTextBoxColumn,
            this.iGPQtyDataGridViewTextBoxColumn,
            this.iGTRemarksDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inwardGatePassBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(993, 454);
            this.dataGridView1.TabIndex = 0;
            // 
            // iGPListDataSet
            // 
            this.iGPListDataSet.DataSetName = "IGPListDataSet";
            this.iGPListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inwardGatePassBindingSource
            // 
            this.inwardGatePassBindingSource.DataMember = "InwardGatePass";
            this.inwardGatePassBindingSource.DataSource = this.iGPListDataSet;
            // 
            // inwardGatePassTableAdapter
            // 
            this.inwardGatePassTableAdapter.ClearBeforeFill = true;
            // 
            // iGPIDDataGridViewTextBoxColumn
            // 
            this.iGPIDDataGridViewTextBoxColumn.DataPropertyName = "IGP_ID";
            this.iGPIDDataGridViewTextBoxColumn.HeaderText = "IGP_ID";
            this.iGPIDDataGridViewTextBoxColumn.Name = "iGPIDDataGridViewTextBoxColumn";
            this.iGPIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iGPDateDataGridViewTextBoxColumn
            // 
            this.iGPDateDataGridViewTextBoxColumn.DataPropertyName = "IGP_Date";
            this.iGPDateDataGridViewTextBoxColumn.HeaderText = "IGP_Date";
            this.iGPDateDataGridViewTextBoxColumn.Name = "iGPDateDataGridViewTextBoxColumn";
            this.iGPDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iGPThroughDataGridViewTextBoxColumn
            // 
            this.iGPThroughDataGridViewTextBoxColumn.DataPropertyName = "IGP_Through";
            this.iGPThroughDataGridViewTextBoxColumn.HeaderText = "IGP_Through";
            this.iGPThroughDataGridViewTextBoxColumn.Name = "iGPThroughDataGridViewTextBoxColumn";
            this.iGPThroughDataGridViewTextBoxColumn.ReadOnly = true;
            this.iGPThroughDataGridViewTextBoxColumn.Width = 150;
            // 
            // iGPByDataGridViewTextBoxColumn
            // 
            this.iGPByDataGridViewTextBoxColumn.DataPropertyName = "IGP_By";
            this.iGPByDataGridViewTextBoxColumn.HeaderText = "IGP_By";
            this.iGPByDataGridViewTextBoxColumn.Name = "iGPByDataGridViewTextBoxColumn";
            this.iGPByDataGridViewTextBoxColumn.ReadOnly = true;
            this.iGPByDataGridViewTextBoxColumn.Width = 150;
            // 
            // iGPForDataGridViewTextBoxColumn
            // 
            this.iGPForDataGridViewTextBoxColumn.DataPropertyName = "IGP_For";
            this.iGPForDataGridViewTextBoxColumn.HeaderText = "IGP_For";
            this.iGPForDataGridViewTextBoxColumn.Name = "iGPForDataGridViewTextBoxColumn";
            this.iGPForDataGridViewTextBoxColumn.ReadOnly = true;
            this.iGPForDataGridViewTextBoxColumn.Width = 150;
            // 
            // iGPParticularsDataGridViewTextBoxColumn
            // 
            this.iGPParticularsDataGridViewTextBoxColumn.DataPropertyName = "IGP_Particulars";
            this.iGPParticularsDataGridViewTextBoxColumn.HeaderText = "IGP_Particulars";
            this.iGPParticularsDataGridViewTextBoxColumn.Name = "iGPParticularsDataGridViewTextBoxColumn";
            this.iGPParticularsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iGPQtyDataGridViewTextBoxColumn
            // 
            this.iGPQtyDataGridViewTextBoxColumn.DataPropertyName = "IGP_Qty";
            this.iGPQtyDataGridViewTextBoxColumn.HeaderText = "IGP_Qty";
            this.iGPQtyDataGridViewTextBoxColumn.Name = "iGPQtyDataGridViewTextBoxColumn";
            this.iGPQtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iGTRemarksDataGridViewTextBoxColumn
            // 
            this.iGTRemarksDataGridViewTextBoxColumn.DataPropertyName = "IGT_Remarks";
            this.iGTRemarksDataGridViewTextBoxColumn.HeaderText = "IGT_Remarks";
            this.iGTRemarksDataGridViewTextBoxColumn.Name = "iGTRemarksDataGridViewTextBoxColumn";
            this.iGTRemarksDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IGPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 454);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IGPList";
            this.Text = "IGPList";
            this.Load += new System.EventHandler(this.IGPList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iGPListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inwardGatePassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private IGPListDataSet iGPListDataSet;
        private System.Windows.Forms.BindingSource inwardGatePassBindingSource;
        private IGPListDataSetTableAdapters.InwardGatePassTableAdapter inwardGatePassTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPThroughDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPParticularsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGPQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iGTRemarksDataGridViewTextBoxColumn;
    }
}