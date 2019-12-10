namespace SciTechManagement.List
{
    partial class OGPList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OGPList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.oGPListDataSet = new SciTechManagement.OGPListDataSet();
            this.outwardGatePassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outwardGatePassTableAdapter = new SciTechManagement.OGPListDataSetTableAdapters.OutwardGatePassTableAdapter();
            this.oGPIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPThroughDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPParticularsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGPQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oGTRemarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGPListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outwardGatePassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oGPIDDataGridViewTextBoxColumn,
            this.oGPDateDataGridViewTextBoxColumn,
            this.oGPThroughDataGridViewTextBoxColumn,
            this.oGPByDataGridViewTextBoxColumn,
            this.oGPForDataGridViewTextBoxColumn,
            this.oGPParticularsDataGridViewTextBoxColumn,
            this.oGPQtyDataGridViewTextBoxColumn,
            this.oGTRemarksDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.outwardGatePassBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(993, 444);
            this.dataGridView1.TabIndex = 0;
            // 
            // oGPListDataSet
            // 
            this.oGPListDataSet.DataSetName = "OGPListDataSet";
            this.oGPListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // outwardGatePassBindingSource
            // 
            this.outwardGatePassBindingSource.DataMember = "OutwardGatePass";
            this.outwardGatePassBindingSource.DataSource = this.oGPListDataSet;
            // 
            // outwardGatePassTableAdapter
            // 
            this.outwardGatePassTableAdapter.ClearBeforeFill = true;
            // 
            // oGPIDDataGridViewTextBoxColumn
            // 
            this.oGPIDDataGridViewTextBoxColumn.DataPropertyName = "OGP_ID";
            this.oGPIDDataGridViewTextBoxColumn.HeaderText = "OGP_ID";
            this.oGPIDDataGridViewTextBoxColumn.Name = "oGPIDDataGridViewTextBoxColumn";
            this.oGPIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oGPDateDataGridViewTextBoxColumn
            // 
            this.oGPDateDataGridViewTextBoxColumn.DataPropertyName = "OGP_Date";
            this.oGPDateDataGridViewTextBoxColumn.HeaderText = "OGP_Date";
            this.oGPDateDataGridViewTextBoxColumn.Name = "oGPDateDataGridViewTextBoxColumn";
            this.oGPDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oGPThroughDataGridViewTextBoxColumn
            // 
            this.oGPThroughDataGridViewTextBoxColumn.DataPropertyName = "OGP_Through";
            this.oGPThroughDataGridViewTextBoxColumn.HeaderText = "OGP_Through";
            this.oGPThroughDataGridViewTextBoxColumn.Name = "oGPThroughDataGridViewTextBoxColumn";
            this.oGPThroughDataGridViewTextBoxColumn.ReadOnly = true;
            this.oGPThroughDataGridViewTextBoxColumn.Width = 150;
            // 
            // oGPByDataGridViewTextBoxColumn
            // 
            this.oGPByDataGridViewTextBoxColumn.DataPropertyName = "OGP_By";
            this.oGPByDataGridViewTextBoxColumn.HeaderText = "OGP_By";
            this.oGPByDataGridViewTextBoxColumn.Name = "oGPByDataGridViewTextBoxColumn";
            this.oGPByDataGridViewTextBoxColumn.ReadOnly = true;
            this.oGPByDataGridViewTextBoxColumn.Width = 150;
            // 
            // oGPForDataGridViewTextBoxColumn
            // 
            this.oGPForDataGridViewTextBoxColumn.DataPropertyName = "OGP_For";
            this.oGPForDataGridViewTextBoxColumn.HeaderText = "OGP_For";
            this.oGPForDataGridViewTextBoxColumn.Name = "oGPForDataGridViewTextBoxColumn";
            this.oGPForDataGridViewTextBoxColumn.ReadOnly = true;
            this.oGPForDataGridViewTextBoxColumn.Width = 150;
            // 
            // oGPParticularsDataGridViewTextBoxColumn
            // 
            this.oGPParticularsDataGridViewTextBoxColumn.DataPropertyName = "OGP_Particulars";
            this.oGPParticularsDataGridViewTextBoxColumn.HeaderText = "OGP_Particulars";
            this.oGPParticularsDataGridViewTextBoxColumn.Name = "oGPParticularsDataGridViewTextBoxColumn";
            this.oGPParticularsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oGPQtyDataGridViewTextBoxColumn
            // 
            this.oGPQtyDataGridViewTextBoxColumn.DataPropertyName = "OGP_Qty";
            this.oGPQtyDataGridViewTextBoxColumn.HeaderText = "OGP_Qty";
            this.oGPQtyDataGridViewTextBoxColumn.Name = "oGPQtyDataGridViewTextBoxColumn";
            this.oGPQtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oGTRemarksDataGridViewTextBoxColumn
            // 
            this.oGTRemarksDataGridViewTextBoxColumn.DataPropertyName = "OGT_Remarks";
            this.oGTRemarksDataGridViewTextBoxColumn.HeaderText = "OGT_Remarks";
            this.oGTRemarksDataGridViewTextBoxColumn.Name = "oGTRemarksDataGridViewTextBoxColumn";
            this.oGTRemarksDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // OGPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 444);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OGPList";
            this.Text = "OGPList";
            this.Load += new System.EventHandler(this.OGPList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oGPListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outwardGatePassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private OGPListDataSet oGPListDataSet;
        private System.Windows.Forms.BindingSource outwardGatePassBindingSource;
        private OGPListDataSetTableAdapters.OutwardGatePassTableAdapter outwardGatePassTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPThroughDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPParticularsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGPQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oGTRemarksDataGridViewTextBoxColumn;
    }
}