namespace SciTechManagement
{
    partial class TransactionReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionReportForm));
            this.TrnsctnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TransactionDataSet9 = new SciTechManagement.TransactionDataSet9();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TrnsctnsTableAdapter = new SciTechManagement.TransactionDataSet9TableAdapters.TrnsctnsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TrnsctnsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataSet9)).BeginInit();
            this.SuspendLayout();
            // 
            // TrnsctnsBindingSource
            // 
            this.TrnsctnsBindingSource.DataMember = "Trnsctns";
            this.TrnsctnsBindingSource.DataSource = this.TransactionDataSet9;
            // 
            // TransactionDataSet9
            // 
            this.TransactionDataSet9.DataSetName = "TransactionDataSet9";
            this.TransactionDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TrnsctnsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SciTechManagement.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(734, 350);
            this.reportViewer1.TabIndex = 0;
            // 
            // TrnsctnsTableAdapter
            // 
            this.TrnsctnsTableAdapter.ClearBeforeFill = true;
            // 
            // TransactionReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 350);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TransactionReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionReportForm";
            this.Load += new System.EventHandler(this.TransactionReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrnsctnsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataSet9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TrnsctnsBindingSource;
        private TransactionDataSet9 TransactionDataSet9;
        private TransactionDataSet9TableAdapters.TrnsctnsTableAdapter TrnsctnsTableAdapter;
    }
}