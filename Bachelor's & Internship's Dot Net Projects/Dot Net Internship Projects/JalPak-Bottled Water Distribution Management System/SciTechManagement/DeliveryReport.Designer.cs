namespace SciTechManagement
{
    partial class DeliveryReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryReport));
            this.DeliveryDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventoryDataSet4 = new SciTechManagement.InventoryDataSet4();
            this.Customer_PackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventoryDataSet5 = new SciTechManagement.InventoryDataSet5();
            this.CustomerDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventoryDataSet6 = new SciTechManagement.InventoryDataSet6();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DeliveryDetailsTableAdapter = new SciTechManagement.InventoryDataSet4TableAdapters.DeliveryDetailsTableAdapter();
            this.Customer_PackageTableAdapter = new SciTechManagement.InventoryDataSet5TableAdapters.Customer_PackageTableAdapter();
            this.CustomerDetailsTableAdapter = new SciTechManagement.InventoryDataSet6TableAdapters.CustomerDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_PackageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // DeliveryDetailsBindingSource
            // 
            this.DeliveryDetailsBindingSource.DataMember = "DeliveryDetails";
            this.DeliveryDetailsBindingSource.DataSource = this.InventoryDataSet4;
            // 
            // InventoryDataSet4
            // 
            this.InventoryDataSet4.DataSetName = "InventoryDataSet4";
            this.InventoryDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Customer_PackageBindingSource
            // 
            this.Customer_PackageBindingSource.DataMember = "Customer_Package";
            this.Customer_PackageBindingSource.DataSource = this.InventoryDataSet5;
            // 
            // InventoryDataSet5
            // 
            this.InventoryDataSet5.DataSetName = "InventoryDataSet5";
            this.InventoryDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomerDetailsBindingSource
            // 
            this.CustomerDetailsBindingSource.DataMember = "CustomerDetails";
            this.CustomerDetailsBindingSource.DataSource = this.InventoryDataSet6;
            // 
            // InventoryDataSet6
            // 
            this.InventoryDataSet6.DataSetName = "InventoryDataSet6";
            this.InventoryDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DeliveryDetailsBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.Customer_PackageBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.CustomerDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(728, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // DeliveryDetailsTableAdapter
            // 
            this.DeliveryDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // Customer_PackageTableAdapter
            // 
            this.Customer_PackageTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerDetailsTableAdapter
            // 
            this.CustomerDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 494);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeliveryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryReport_FormClosing);
            this.Load += new System.EventHandler(this.DeliveryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_PackageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataSet6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DeliveryDetailsBindingSource;
        private InventoryDataSet4 InventoryDataSet4;
        private System.Windows.Forms.BindingSource Customer_PackageBindingSource;
        private InventoryDataSet5 InventoryDataSet5;
        private System.Windows.Forms.BindingSource CustomerDetailsBindingSource;
        private InventoryDataSet6 InventoryDataSet6;
        private InventoryDataSet4TableAdapters.DeliveryDetailsTableAdapter DeliveryDetailsTableAdapter;
        private InventoryDataSet5TableAdapters.Customer_PackageTableAdapter Customer_PackageTableAdapter;
        private InventoryDataSet6TableAdapters.CustomerDetailsTableAdapter CustomerDetailsTableAdapter;
    }
}