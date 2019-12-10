namespace SciTechManagement.Warehouse
{
    partial class OutwardGatePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutwardGatePass));
            this.cmbOGPRemarks = new System.Windows.Forms.ComboBox();
            this.txtOGPQuantity = new System.Windows.Forms.TextBox();
            this.btnAddOGPItem = new System.Windows.Forms.Button();
            this.txtOGPFor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOGPBy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOGPThrough = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOGPNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ogpDataGridView1 = new System.Windows.Forms.DataGridView();
            this.S_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintOutwardGatepass = new System.Windows.Forms.Button();
            this.cmbOGPParticulars = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oGPListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OGPdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ogpDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbOGPRemarks
            // 
            this.cmbOGPRemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOGPRemarks.FormattingEnabled = true;
            this.cmbOGPRemarks.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cmbOGPRemarks.Location = new System.Drawing.Point(86, 203);
            this.cmbOGPRemarks.Name = "cmbOGPRemarks";
            this.cmbOGPRemarks.Size = new System.Drawing.Size(121, 21);
            this.cmbOGPRemarks.TabIndex = 6;
            // 
            // txtOGPQuantity
            // 
            this.txtOGPQuantity.Location = new System.Drawing.Point(327, 167);
            this.txtOGPQuantity.Name = "txtOGPQuantity";
            this.txtOGPQuantity.Size = new System.Drawing.Size(144, 20);
            this.txtOGPQuantity.TabIndex = 5;
            this.txtOGPQuantity.TextChanged += new System.EventHandler(this.txtOGPQuantity_TextChanged);
            // 
            // btnAddOGPItem
            // 
            this.btnAddOGPItem.Location = new System.Drawing.Point(377, 201);
            this.btnAddOGPItem.Name = "btnAddOGPItem";
            this.btnAddOGPItem.Size = new System.Drawing.Size(94, 35);
            this.btnAddOGPItem.TabIndex = 7;
            this.btnAddOGPItem.Text = "Add";
            this.btnAddOGPItem.UseVisualStyleBackColor = true;
            this.btnAddOGPItem.Click += new System.EventHandler(this.btnAddOGPItem_Click);
            // 
            // txtOGPFor
            // 
            this.txtOGPFor.Location = new System.Drawing.Point(86, 126);
            this.txtOGPFor.Name = "txtOGPFor";
            this.txtOGPFor.Size = new System.Drawing.Size(385, 20);
            this.txtOGPFor.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Remarks:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Particulars:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "for";
            // 
            // txtOGPBy
            // 
            this.txtOGPBy.Location = new System.Drawing.Point(327, 93);
            this.txtOGPBy.Name = "txtOGPBy";
            this.txtOGPBy.Size = new System.Drawing.Size(144, 20);
            this.txtOGPBy.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "for";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "through";
            // 
            // txtOGPThrough
            // 
            this.txtOGPThrough.Location = new System.Drawing.Point(86, 93);
            this.txtOGPThrough.Name = "txtOGPThrough";
            this.txtOGPThrough.Size = new System.Drawing.Size(175, 20);
            this.txtOGPThrough.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Please allow to enter the following quantity of Bottles/Equipments.";
            // 
            // txtOGPNo
            // 
            this.txtOGPNo.Location = new System.Drawing.Point(86, 38);
            this.txtOGPNo.Name = "txtOGPNo";
            this.txtOGPNo.ReadOnly = true;
            this.txtOGPNo.Size = new System.Drawing.Size(124, 20);
            this.txtOGPNo.TabIndex = 15;
            this.txtOGPNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "No. OGP:";
            // 
            // ogpDataGridView1
            // 
            this.ogpDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ogpDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ogpDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ogpDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_No,
            this.Particulars,
            this.Quantity,
            this.Remarks});
            this.ogpDataGridView1.Location = new System.Drawing.Point(28, 242);
            this.ogpDataGridView1.Name = "ogpDataGridView1";
            this.ogpDataGridView1.ReadOnly = true;
            this.ogpDataGridView1.Size = new System.Drawing.Size(443, 243);
            this.ogpDataGridView1.TabIndex = 34;
            this.ogpDataGridView1.TabStop = false;
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
            // btnPrintOutwardGatepass
            // 
            this.btnPrintOutwardGatepass.Location = new System.Drawing.Point(279, 201);
            this.btnPrintOutwardGatepass.Name = "btnPrintOutwardGatepass";
            this.btnPrintOutwardGatepass.Size = new System.Drawing.Size(94, 35);
            this.btnPrintOutwardGatepass.TabIndex = 8;
            this.btnPrintOutwardGatepass.Text = "Print";
            this.btnPrintOutwardGatepass.UseVisualStyleBackColor = true;
            this.btnPrintOutwardGatepass.Click += new System.EventHandler(this.btnPrintOutwardGatepass_Click);
            // 
            // cmbOGPParticulars
            // 
            this.cmbOGPParticulars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOGPParticulars.FormattingEnabled = true;
            this.cmbOGPParticulars.Location = new System.Drawing.Point(86, 166);
            this.cmbOGPParticulars.Name = "cmbOGPParticulars";
            this.cmbOGPParticulars.Size = new System.Drawing.Size(175, 21);
            this.cmbOGPParticulars.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(263, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(473, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(473, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(474, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(209, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(267, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 10);
            this.label16.TabIndex = 35;
            this.label16.Text = "*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oGPListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oGPListToolStripMenuItem
            // 
            this.oGPListToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.oGPListToolStripMenuItem.Name = "oGPListToolStripMenuItem";
            this.oGPListToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.oGPListToolStripMenuItem.Text = "OGP List";
            this.oGPListToolStripMenuItem.Click += new System.EventHandler(this.oGPListToolStripMenuItem_Click);
            // 
            // OGPdateTimePicker1
            // 
            this.OGPdateTimePicker1.Location = new System.Drawing.Point(327, 38);
            this.OGPdateTimePicker1.Name = "OGPdateTimePicker1";
            this.OGPdateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.OGPdateTimePicker1.TabIndex = 37;
            // 
            // OutwardGatePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(506, 498);
            this.Controls.Add(this.OGPdateTimePicker1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbOGPParticulars);
            this.Controls.Add(this.btnPrintOutwardGatepass);
            this.Controls.Add(this.ogpDataGridView1);
            this.Controls.Add(this.cmbOGPRemarks);
            this.Controls.Add(this.txtOGPQuantity);
            this.Controls.Add(this.btnAddOGPItem);
            this.Controls.Add(this.txtOGPFor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOGPBy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOGPThrough);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOGPNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OutwardGatePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outward Gate Pass";
            this.Load += new System.EventHandler(this.OutwardGatePass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ogpDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOGPRemarks;
        private System.Windows.Forms.TextBox txtOGPQuantity;
        private System.Windows.Forms.Button btnAddOGPItem;
        private System.Windows.Forms.TextBox txtOGPFor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOGPBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOGPThrough;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOGPNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ogpDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button btnPrintOutwardGatepass;
        private System.Windows.Forms.ComboBox cmbOGPParticulars;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oGPListToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker OGPdateTimePicker1;
    }
}