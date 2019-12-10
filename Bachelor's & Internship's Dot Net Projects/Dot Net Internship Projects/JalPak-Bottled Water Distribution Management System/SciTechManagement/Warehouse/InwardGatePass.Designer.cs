namespace SciTechManagement.Warehouse
{
    partial class InwardGatePass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InwardGatePass));
            this.label2 = new System.Windows.Forms.Label();
            this.txtIGPNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIGPThrough = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIGPBy = new System.Windows.Forms.TextBox();
            this.txtIGPFor = new System.Windows.Forms.TextBox();
            this.igpDataGridView1 = new System.Windows.Forms.DataGridView();
            this.S_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddIGPItem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIGPQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbIGPRemarks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIGPParticulars = new System.Windows.Forms.ComboBox();
            this.btnPrintInwardGatepass = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iGPListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IGPdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.igpDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date:";
            // 
            // txtIGPNo
            // 
            this.txtIGPNo.Location = new System.Drawing.Point(86, 38);
            this.txtIGPNo.Name = "txtIGPNo";
            this.txtIGPNo.ReadOnly = true;
            this.txtIGPNo.Size = new System.Drawing.Size(124, 20);
            this.txtIGPNo.TabIndex = 1;
            this.txtIGPNo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please allow to enter the following quantity of Bottles/Equipments.";
            // 
            // txtIGPThrough
            // 
            this.txtIGPThrough.Location = new System.Drawing.Point(86, 94);
            this.txtIGPThrough.Name = "txtIGPThrough";
            this.txtIGPThrough.Size = new System.Drawing.Size(176, 20);
            this.txtIGPThrough.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "through";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "by";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "for";
            // 
            // txtIGPBy
            // 
            this.txtIGPBy.Location = new System.Drawing.Point(327, 94);
            this.txtIGPBy.Name = "txtIGPBy";
            this.txtIGPBy.Size = new System.Drawing.Size(144, 20);
            this.txtIGPBy.TabIndex = 2;
            // 
            // txtIGPFor
            // 
            this.txtIGPFor.Location = new System.Drawing.Point(86, 127);
            this.txtIGPFor.Name = "txtIGPFor";
            this.txtIGPFor.Size = new System.Drawing.Size(385, 20);
            this.txtIGPFor.TabIndex = 3;
            // 
            // igpDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.igpDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.igpDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.igpDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_No,
            this.Particulars,
            this.Quantity,
            this.Remarks});
            this.igpDataGridView1.Location = new System.Drawing.Point(25, 243);
            this.igpDataGridView1.Name = "igpDataGridView1";
            this.igpDataGridView1.ReadOnly = true;
            this.igpDataGridView1.Size = new System.Drawing.Size(446, 243);
            this.igpDataGridView1.TabIndex = 20;
            this.igpDataGridView1.TabStop = false;
            // 
            // S_No
            // 
            this.S_No.HeaderText = "S.No.";
            this.S_No.Name = "S_No";
            this.S_No.ReadOnly = true;
            this.S_No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.S_No.Width = 50;
            // 
            // Particulars
            // 
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.Name = "Particulars";
            this.Particulars.ReadOnly = true;
            this.Particulars.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // btnAddIGPItem
            // 
            this.btnAddIGPItem.Location = new System.Drawing.Point(377, 202);
            this.btnAddIGPItem.Name = "btnAddIGPItem";
            this.btnAddIGPItem.Size = new System.Drawing.Size(94, 35);
            this.btnAddIGPItem.TabIndex = 7;
            this.btnAddIGPItem.Text = "Add";
            this.btnAddIGPItem.UseVisualStyleBackColor = true;
            this.btnAddIGPItem.Click += new System.EventHandler(this.btnAddIGPItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "for";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Particulars:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Quantity:";
            // 
            // txtIGPQuantity
            // 
            this.txtIGPQuantity.Location = new System.Drawing.Point(327, 168);
            this.txtIGPQuantity.Name = "txtIGPQuantity";
            this.txtIGPQuantity.Size = new System.Drawing.Size(144, 20);
            this.txtIGPQuantity.TabIndex = 5;
            this.txtIGPQuantity.TextChanged += new System.EventHandler(this.txtIGPQuantity_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Remarks:";
            // 
            // cmbIGPRemarks
            // 
            this.cmbIGPRemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIGPRemarks.FormattingEnabled = true;
            this.cmbIGPRemarks.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cmbIGPRemarks.Location = new System.Drawing.Point(86, 204);
            this.cmbIGPRemarks.Name = "cmbIGPRemarks";
            this.cmbIGPRemarks.Size = new System.Drawing.Size(121, 21);
            this.cmbIGPRemarks.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. IGP:";
            // 
            // cmbIGPParticulars
            // 
            this.cmbIGPParticulars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIGPParticulars.FormattingEnabled = true;
            this.cmbIGPParticulars.Location = new System.Drawing.Point(86, 167);
            this.cmbIGPParticulars.Name = "cmbIGPParticulars";
            this.cmbIGPParticulars.Size = new System.Drawing.Size(176, 21);
            this.cmbIGPParticulars.TabIndex = 4;
            // 
            // btnPrintInwardGatepass
            // 
            this.btnPrintInwardGatepass.Location = new System.Drawing.Point(277, 202);
            this.btnPrintInwardGatepass.Name = "btnPrintInwardGatepass";
            this.btnPrintInwardGatepass.Size = new System.Drawing.Size(94, 35);
            this.btnPrintInwardGatepass.TabIndex = 8;
            this.btnPrintInwardGatepass.Text = "Print";
            this.btnPrintInwardGatepass.UseVisualStyleBackColor = true;
            this.btnPrintInwardGatepass.Click += new System.EventHandler(this.btnPrintInwardGatepass_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(265, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(477, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(477, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(208, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 10);
            this.label14.TabIndex = 21;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(477, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(263, 173);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 10);
            this.label16.TabIndex = 21;
            this.label16.Text = "*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iGPListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iGPListToolStripMenuItem
            // 
            this.iGPListToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.iGPListToolStripMenuItem.Name = "iGPListToolStripMenuItem";
            this.iGPListToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.iGPListToolStripMenuItem.Text = "IGP List";
            this.iGPListToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.iGPListToolStripMenuItem.Click += new System.EventHandler(this.iGPListToolStripMenuItem_Click);
            // 
            // IGPdateTimePicker1
            // 
            this.IGPdateTimePicker1.Location = new System.Drawing.Point(327, 37);
            this.IGPdateTimePicker1.Name = "IGPdateTimePicker1";
            this.IGPdateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.IGPdateTimePicker1.TabIndex = 23;
            // 
            // InwardGatePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(506, 498);
            this.Controls.Add(this.IGPdateTimePicker1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPrintInwardGatepass);
            this.Controls.Add(this.cmbIGPParticulars);
            this.Controls.Add(this.cmbIGPRemarks);
            this.Controls.Add(this.txtIGPQuantity);
            this.Controls.Add(this.btnAddIGPItem);
            this.Controls.Add(this.igpDataGridView1);
            this.Controls.Add(this.txtIGPFor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIGPBy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIGPThrough);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIGPNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "InwardGatePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inward Gatepass";
            this.Load += new System.EventHandler(this.InwardGatePass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.igpDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIGPNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIGPThrough;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIGPBy;
        private System.Windows.Forms.TextBox txtIGPFor;
        private System.Windows.Forms.DataGridView igpDataGridView1;
        private System.Windows.Forms.Button btnAddIGPItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIGPQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIGPRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIGPParticulars;
        private System.Windows.Forms.Button btnPrintInwardGatepass;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iGPListToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker IGPdateTimePicker1;
    }
}