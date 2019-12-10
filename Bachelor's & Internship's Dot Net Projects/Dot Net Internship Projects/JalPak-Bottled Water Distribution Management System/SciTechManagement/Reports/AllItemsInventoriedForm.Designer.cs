namespace SciTechManagement
{
    partial class AllItemsInventoriedForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InventoryDataSet = new SciTechManagement.InventoryDataSet();
            this.ItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemsTableAdapter = new SciTechManagement.InventoryDataSetTableAdapters.ItemsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.Silver;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InventoryReportDataSet1";
            reportDataSource1.Value = this.ItemsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.AllItemsInventoried.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(719, 401);
            this.reportViewer1.TabIndex = 0;
            // 
            // InventoryDataSet
            // 
            this.InventoryDataSet.DataSetName = "InventoryDataSet";
            this.InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ItemsBindingSource
            // 
            this.ItemsBindingSource.DataMember = "Items";
            this.ItemsBindingSource.DataSource = this.InventoryDataSet;
            // 
            // ItemsTableAdapter
            // 
            this.ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // AllItemsInventoriedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 401);
            this.Controls.Add(this.reportViewer1);
            this.Name = "AllItemsInventoriedForm";
            this.Text = "AllItemsInventoriedForm";
            this.Load += new System.EventHandler(this.AllItemsInventoriedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ItemsBindingSource;
        private InventoryDataSet InventoryDataSet;
        private InventoryDataSetTableAdapters.ItemsTableAdapter ItemsTableAdapter;
    }
}