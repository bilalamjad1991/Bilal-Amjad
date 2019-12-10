namespace SciTechManagement.Reports
{
    partial class Form1
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
            this.InwardGatePassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IGPDataSet1 = new SciTechManagement.Reports.IGPDataSet1();
            this.InwardGatePassTableAdapter = new SciTechManagement.Reports.IGPDataSet1TableAdapters.InwardGatePassTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InwardGatePassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGPDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InwardGatePassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(551, 293);
            this.reportViewer1.TabIndex = 0;
            // 
            // InwardGatePassBindingSource
            // 
            this.InwardGatePassBindingSource.DataMember = "InwardGatePass";
            this.InwardGatePassBindingSource.DataSource = this.IGPDataSet1;
            // 
            // IGPDataSet1
            // 
            this.IGPDataSet1.DataSetName = "IGPDataSet1";
            this.IGPDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InwardGatePassTableAdapter
            // 
            this.InwardGatePassTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 293);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InwardGatePassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGPDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InwardGatePassBindingSource;
        private IGPDataSet1 IGPDataSet1;
        private IGPDataSet1TableAdapters.InwardGatePassTableAdapter InwardGatePassTableAdapter;
    }
}