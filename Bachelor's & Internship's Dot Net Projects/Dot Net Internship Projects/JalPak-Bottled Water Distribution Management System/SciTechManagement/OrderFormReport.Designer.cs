namespace SciTechManagement
{
    partial class OrderFormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderFormReport));
            this.OrderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewOrderDataSet4 = new SciTechManagement.NewOrderDataSet4();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrderDetailsTableAdapter = new SciTechManagement.NewOrderDataSet4TableAdapters.OrderDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewOrderDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderDetailsBindingSource
            // 
            this.OrderDetailsBindingSource.DataMember = "OrderDetails";
            this.OrderDetailsBindingSource.DataSource = this.NewOrderDataSet4;
            // 
            // NewOrderDataSet4
            // 
            this.NewOrderDataSet4.DataSetName = "NewOrderDataSet4";
            this.NewOrderDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "NewOrderDataSet4";
            reportDataSource1.Value = this.OrderDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(734, 525);
            this.reportViewer1.TabIndex = 0;
            // 
            // OrderDetailsTableAdapter
            // 
            this.OrderDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // OrderFormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 525);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrderFormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderFormReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderFormReport_FormClosing);
            this.Load += new System.EventHandler(this.OrderFormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewOrderDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OrderDetailsBindingSource;
        private NewOrderDataSet4 NewOrderDataSet4;
        private NewOrderDataSet4TableAdapters.OrderDetailsTableAdapter OrderDetailsTableAdapter;
    }
}