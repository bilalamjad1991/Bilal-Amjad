namespace SciTechManagement
{
    partial class OGPReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OGPReport));
            this.OutwardGatePassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OGPDS = new SciTechManagement.OGPDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OutwardGatePassTableAdapter = new SciTechManagement.OGPDSTableAdapters.OutwardGatePassTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.OutwardGatePassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OGPDS)).BeginInit();
            this.SuspendLayout();
            // 
            // OutwardGatePassBindingSource
            // 
            this.OutwardGatePassBindingSource.DataMember = "OutwardGatePass";
            this.OutwardGatePassBindingSource.DataSource = this.OGPDS;
            // 
            // OGPDS
            // 
            this.OGPDS.DataSetName = "OGPDS";
            this.OGPDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OGPDataSet";
            reportDataSource1.Value = this.OutwardGatePassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(710, 495);
            this.reportViewer1.TabIndex = 0;
            // 
            // OutwardGatePassTableAdapter
            // 
            this.OutwardGatePassTableAdapter.ClearBeforeFill = true;
            // 
            // OGPReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 495);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OGPReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OGPReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OGPReport_FormClosing);
            this.Load += new System.EventHandler(this.OGPReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutwardGatePassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OGPDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OutwardGatePassBindingSource;
        private OGPDS OGPDS;
        private OGPDSTableAdapters.OutwardGatePassTableAdapter OutwardGatePassTableAdapter;
    }
}