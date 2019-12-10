namespace SciTechManagement
{
    partial class IGPReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGPReport));
            this.InwardGatePassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IGPDS = new SciTechManagement.IGPDS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InwardGatePassTableAdapter = new SciTechManagement.IGPDSTableAdapters.InwardGatePassTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InwardGatePassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGPDS)).BeginInit();
            this.SuspendLayout();
            // 
            // InwardGatePassBindingSource
            // 
            this.InwardGatePassBindingSource.DataMember = "InwardGatePass";
            this.InwardGatePassBindingSource.DataSource = this.IGPDS;
            // 
            // IGPDS
            // 
            this.IGPDS.DataSetName = "IGPDS";
            this.IGPDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "IGPDataSet";
            reportDataSource1.Value = this.InwardGatePassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(640, 446);
            this.reportViewer1.TabIndex = 0;
            // 
            // InwardGatePassTableAdapter
            // 
            this.InwardGatePassTableAdapter.ClearBeforeFill = true;
            // 
            // IGPReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 446);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IGPReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IGPReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IGPReport_FormClosing);
            this.Load += new System.EventHandler(this.IGPReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InwardGatePassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGPDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InwardGatePassBindingSource;
        private IGPDS IGPDS;
        private IGPDSTableAdapters.InwardGatePassTableAdapter InwardGatePassTableAdapter;
    }
}